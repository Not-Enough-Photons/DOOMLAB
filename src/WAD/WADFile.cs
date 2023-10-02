using System.Collections;
using System.Collections.Generic;

using System.IO;

using UnityEngine;

using Patch = NEP.DOOMLAB.WAD.DataTypes.Patch;
using MelonLoader;
using System.Linq;

namespace NEP.DOOMLAB.WAD
{
    [System.Serializable]
    public class WADFile
    {
        public WADFile(string path)
        {
            entries = new HashSet<WADIndexEntry>();
            entryTable = new Dictionary<string, WADIndexEntry>();
            filePath = path;

            sounds = new List<DataTypes.Sound>();
            patches = new List<Patch>();
            colorPal = new List<Color32>();

            for(int i = 0; i < 256; i++)
            {
                colorPal.Add(new Color32(0, 0, 0, 255));
            }
        }

        public enum WADType
        {
            IWAD,
            PWAD
        }

        public WADType wadType;
        public int indexEntries;
        public int indexOffset;

        public Dictionary<string, WADIndexEntry> entryTable;
        public HashSet<WADIndexEntry> entries;
        public List<Color32> colorPal;

        public List<Patch> patches;
        public List<DataTypes.Sound> sounds;

        private string filePath;

        private MemoryStream fileStream;
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

        public void Preload()
        {
            var bytes = default(byte[]);

            using(StreamReader reader = new StreamReader(filePath))
            {
                using(var memStream = new MemoryStream())
                {
                    reader.BaseStream.CopyTo(memStream);
                    bytes = memStream.ToArray();
                }
            }

            fileStream = new MemoryStream(bytes);
            reader = new BinaryReader(fileStream);
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

                if(!entryTable.ContainsKey(entry.name))
                {
                    entryTable.Add(entry.name, entry);
                }
            }
        }

        public void ReadPalette()
        {
            WADIndexEntry palette = null;

            if(wadType == WADType.PWAD)
            {
                colorPal = WADManager.Instance.IWAD.colorPal;
                return;
            }

            foreach(var entry in entries)
            {
                if(entry.name == "PLAYPAL")
                {
                    palette = entry;
                    break;
                }
            }

            if(palette == null)
            {
                return;
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

                colorPal[i] = color;
            }
        }

        public void ReadAllSounds()
        {
            foreach(var entry in entries)
            {
                if(!entry.name.StartsWith("DS"))
                {
                    continue;
                }

                ReadSound(entry);
            }

            if (wadType == WADType.PWAD)
            {
                WADFile iwad = WADManager.Instance.IWAD;
                for (int j = 0; j < iwad.sounds.Count; j++)
                {
                    var entry = iwad.sounds[j];
                    if (!entryTable.ContainsKey(entry.soundName))
                    {
                        sounds.Add(entry);
                    }
                }
            }
        }

        public void ReadAllSprites()
        {
            bool inRange = false;

            foreach(var entry in entries)
            {
                if(!inRange)
                {
                    if (entry.name == "S_START" || entry.name == "SS_START")
                    {
                        inRange = true;
                    }
                }
                else
                {
                    if(entry.name == "S_END" || entry.name == "SS_END")
                    {
                        inRange = false;
                        break;
                    }
                    else
                    {
                        ReadPatch(entry);
                    }
                }
            }

            if(wadType == WADType.PWAD)
            {
                WADFile iwad = WADManager.Instance.IWAD;
                for (int j = 0; j < iwad.patches.Count; j++)
                {
                    var entry = iwad.patches[j];
                    if (!entryTable.ContainsKey(entry.name))
                    {
                        patches.Add(entry);
                    }
                }
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

            sound.soundName = entry.name;
            sound.id = reader.ReadInt16();
            sound.sampleRate = reader.ReadUInt16();
            sound.sampleCount = reader.ReadUInt16();
            sound.soundData = reader.ReadBytes(sound.sampleCount - 32);
            
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

            Color32[] colors = new Color32[width * height];

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
                        colors[(height - columnY - j - 1) * width + i] = color;
                    }

                    reader.ReadByte();
                }
            }

            tex.SetPixels32(colors, 0);
            tex.Apply();
            patch.output = tex;
            patch.output.hideFlags = HideFlags.DontUnloadUnusedAsset;
            patches.Add(patch);
        }

        public DataTypes.Patch GetPatch(string name)
        {
            return patches.FirstOrDefault((patch) => patch.name == name);
        }

        public DataTypes.Sound GetSound(string name)
        {
            return sounds.FirstOrDefault((sound) => sound.soundName == name);
        }
    }
}