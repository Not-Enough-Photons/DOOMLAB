using System.Collections;
using System.Collections.Generic;

using System.IO;

using UnityEngine;

using NEP.DOOMLAB.WAD.DataTypes;

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

        private string filePath;

        private FileStream fileStream;
        private BinaryReader reader;

        public char[] ReadCharacters(int count)
        {
            char[] buffer = new char[count];

            for(int i = 0; i < count; i++)
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

                foreach(var c in characters)
                {
                    if(c == '\0')
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

            for(int i = 0; i < entries.Count; i++)
            {
                if (entries[i].name == "PLAYPAL")
                {
                    palette = entries[i];
                }
            }

            reader.BaseStream.Seek(palette.offset, SeekOrigin.Begin);

            for(int i = 0; i < 256; i++)
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

        public void ListSprites()
        {
            int targetIndex = 0;
            WADIndexEntry targetEntry = null;

            for(int i = 0; i < entries.Count; i++)
            {
                if (entries[i].name == "S_START")
                {
                    targetEntry = entries[i];
                    targetIndex = i;
                    break;
                }
            }

            int patchIdx = 0;
            for(int i = targetIndex + 1; i < entries.Count; i++, patchIdx++)
            {
                if (entries[i].name == "S_END")
                {
                    break;
                }

                ReadPatch(entries[i]);
            }
        }

        public void ReadPatch(WADIndexEntry entry)
        {
            reader.BaseStream.Seek(entry.offset, SeekOrigin.Begin);

            var width = reader.ReadInt16();
            var height = reader.ReadInt16();
            var leftOffset = reader.ReadInt16();
            var topOffset = reader.ReadInt16();

            Patch patch = new Patch(entry.name, width, height, leftOffset, topOffset);

            reader.BaseStream.Seek(width * 4, SeekOrigin.Current);

            Texture2D tex = new Texture2D(width, height, TextureFormat.RGBA32, false);
            tex.filterMode = FilterMode.Point;
            tex.alphaIsTransparency = false;
            
            int colIdx = 0;
            while(colIdx != width)
            {
                int row = reader.ReadByte();
                int pixelsInColumn = reader.ReadByte();
                reader.ReadByte();

                for(int i = 0; i < pixelsInColumn; i++)
                {
                    //tex.SetPixel(colIdx, height - row - i - 1, colorPal[reader.ReadByte()]);
                    tex.SetPixel(colIdx, height - row - i - 1, colorPal[reader.ReadByte()]);
                }

                reader.ReadByte();
                
                if(PeekByte() == 255)
                {
                    colIdx++;
                    reader.ReadByte();
                }
            }

            tex.Apply();
            patch.output = tex;
            patches.Add(patch);
        }
    }
}