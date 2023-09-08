using System.Collections;
using System.Collections.Generic;

using System.IO;

using UnityEngine;

using NEP.DOOMLAB.WAD.DataTypes;
using HarmonyLib;

using Patch = NEP.DOOMLAB.WAD.DataTypes.Patch;
using UnhollowerBaseLib;
using MelonLoader;
using System;

namespace NEP.DOOMLAB.WAD
{
    [System.Serializable]
    public class WADFile
    {
        public WADFile(string path)
        {
            entries = new List<WADIndexEntry>();
            filePath = path;

            fileStream = File.OpenRead(filePath);
            reader = new BinaryReader(fileStream);
            sounds = new List<DataTypes.Sound>();
            patches = new List<Patch>();
            colorPal = new List<Color32>();
        }

        public enum WADType
        {
            IWAD,
            PWAD
        }

        public WADType wadType;
        public int indexEntries;
        public int indexOffset;

        public List<WADIndexEntry> entries;
        public static List<Color32> colorPal;

        public List<Patch> patches;
        public List<DataTypes.Sound> sounds;

        private string filePath;

        private FileStream fileStream;
        private BinaryReader reader;

        public char[] ReadCharacters(int count)
        {
            char[] buffer = new char[count];

            for (int i = 0; i < count; i++)
            {
                buffer[i] = reader.ReadChar();
            }

            return buffer;
        }

        public short ReadShort()
        {
            return reader.ReadInt16();
        }

        public ushort ReadUnsignedShort()
        {
            return reader.ReadUInt16();
        }

        public int ReadInt()
        {
            return reader.ReadInt32();
        }

        public byte PeekByte()
        {
            byte value = reader.ReadByte();
            reader.BaseStream.Position--;
            return value;
        }

        public void Close()
        {
            reader.Close();
        }

        public void Dispose()
        {
            reader.Dispose();
        }

        public void CleanUp()
        {
            Close();
            Dispose();
        }

        public void ReadHeader()
        {
            char[] wadChar = ReadCharacters(4);
            wadType = wadChar[0] == 'I' ? WADType.IWAD : WADType.PWAD;
            indexEntries = ReadInt();
            indexOffset = ReadInt();
        }

        public void ReadIndexEntries()
        {
            reader.BaseStream.Seek(indexOffset, SeekOrigin.Begin);

            for (int i = 0; i < indexEntries; i++)
            {
                WADIndexEntry entry = new WADIndexEntry();

                entry.offset = ReadInt();
                entry.size = ReadInt();

                char[] characters = ReadCharacters(8);

                foreach (var c in characters)
                {
                    if (c == '\0')
                    {
                        break;
                    }

                    entry.name += c;
                }

                entries.Add(entry);
            }
        }

        public void ReadPalette()
        {
            WADIndexEntry palette = null;

            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].name == "PLAYPAL")
                {
                    palette = entries[i];
                    break;
                }
            }

            reader.BaseStream.Seek(palette.offset, SeekOrigin.Begin);

            for (int i = 0; i < 256; i++)
            {
                byte red = reader.ReadByte();
                byte green = reader.ReadByte();
                byte blue = reader.ReadByte();

                Color32 color = new Color32();
                color.r = red;
                color.g = green;
                color.b = blue;
                color.a = 255;

                colorPal.Add(color);
            }
        }

        public void ReadAllSounds()
        {
            for (int i = 0; i < entries.Count; i++)
            {
                if (!entries[i].name.StartsWith("DS"))
                {
                    continue;
                }

                ReadSound(entries[i]);
            }
        }

        public void ReadAllSprites()
        {
            int targetIndex = 0;
            WADIndexEntry targetEntry = null;

            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].name == "S_START")
                {
                    targetEntry = entries[i];
                    targetIndex = i;
                    break;
                }
            }

            int patchIdx = 0;
            for (int i = targetIndex + 1; i < entries.Count; i++, patchIdx++)
            {
                if (entries[i].name == "S_END")
                {
                    break;
                }

                ReadPatch(entries[i]);
            }
        }

        public void ReadSound(WADIndexEntry entry)
        {
            if(entry.size <= 4)
            {
                return;
            }

            reader.BaseStream.Seek(entry.offset, SeekOrigin.Begin);

            DataTypes.Sound sound = new DataTypes.Sound();

            sound.id = reader.ReadInt16();
            sound.sampleRate = reader.ReadUInt16();
            sound.sampleCount = reader.ReadUInt16();
            sound.soundData = reader.ReadBytes(sound.sampleCount - 7);
            
            float[] samples = new float[sound.soundData.Length];

            for (int i = 0; i < samples.Length; i++)
            {
                samples[i] = ((float)sound.soundData[i] - 127) / 127;
            }

            var clip = AudioClip.Create(entry.name, sound.sampleCount, 1, sound.sampleRate, false);
            clip.SetData(samples, 0);
            sound.output = clip;
            sound.output.hideFlags = HideFlags.DontUnloadUnusedAsset;
            sounds.Add(sound);
        }

        public void ReadPatch(WADIndexEntry entry)
        {
            reader.BaseStream.Seek(entry.offset, SeekOrigin.Begin);

            var width = reader.ReadInt16();
            var height = reader.ReadInt16();
            var leftOffset = reader.ReadInt16();
            var topOffset = reader.ReadInt16();

            Patch patch = new Patch(entry.name, width, height, leftOffset, topOffset);

            int[] columns = new int[width];

            for(int i = 0; i < width; i++)
            {
                columns[i] = reader.ReadInt32();
            }

            Texture2D tex = new Texture2D(width, height, TextureFormat.RGBA32, false);
            tex.filterMode = FilterMode.Point;

            for(int i = 0; i < width; i++)
            {
                reader.BaseStream.Seek(entry.offset + columns[i], SeekOrigin.Begin);

                int columnY = 0;
                
                while(columnY != 255)
                {
                    columnY = reader.ReadByte();

                    if (columnY == 255)
                    {
                        break;
                    }

                    int pixels = reader.ReadByte();

                    reader.ReadByte();

                    for(int j = 0; j < pixels; j++)
                    {
                        Color32 color = colorPal[reader.ReadByte()];
                        tex.SetPixel(i, height - columnY - j - 1, color);
                    }

                    reader.ReadByte();
                }
            }

            tex.Apply();
            patch.output = tex;
            patch.output.hideFlags = HideFlags.DontUnloadUnusedAsset;
            patches.Add(patch);
        }
    }
}