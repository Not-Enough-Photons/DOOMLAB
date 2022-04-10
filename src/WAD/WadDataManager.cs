using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

using Cyotek.Data;

namespace NEP.BWDOOM.WAD
{
    public class WadDataManager
    {
        public WadDataManager()
        {
            _instance = this;
            sprites = new List<SpriteLump>();
            WriteWadInfo(MelonLoader.MelonUtils.BaseDirectory + @"\DOOM2.wad");
        }

        public static WadDataManager _instance;

        public static List<SpriteLump> sprites;

        public static SpriteLump GetSpriteLump(string name)
        {
            return sprites.Find((lmp) => lmp.name == name);
        }

        public static SpriteLump GetSpriteLump(int offset)
        {
            return sprites.Find((lmp) => lmp.offset == offset);
        }

        private void WriteWadInfo(string fileName)
        {
            using (Stream stream = File.OpenRead(fileName))
            {
                using (WadReader reader = new WadReader(stream))
                {
                    WadLump lump;

                    DoomPictureReader spriteReader = new DoomPictureReader();
                    spriteReader.LoadPalette(MelonLoader.MelonUtils.BaseDirectory + @"\PLAYPAL.pal");

                    bool S_START = false;
                    bool S_END = false;

                    while ((lump = reader.GetNextLump()) != null)
                    {
                        if (lump.Name == "S_START")
                        {
                            S_START = true;
                        }

                        if (S_START && !S_END)
                        {
                            if (lump.Name == "S_END")
                            {
                                S_END = true;
                            }

                            if (lump.Name != "S_START" && lump.Name != "S_END")
                            {
                                int lumpOffset = lump.Offset;
                                string name = lump.Name;
                                Texture2D sprite = spriteReader.Read(lump.GetInputStream());

                                SpriteLump lmp = new SpriteLump(lumpOffset, name, sprite);

                                sprites?.Add(lmp);

                                MelonLoader.MelonLogger.Msg($"Loaded sprite lump {lump.Name} with offset {lump.Offset}");
                            }
                        }
                    }
                }
            }
        }
    }

}
