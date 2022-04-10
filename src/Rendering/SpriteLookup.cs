using System.Collections.Generic;
using UnityEngine;

using NEP.BWDOOM.Entities;
using NEP.BWDOOM.WAD;

namespace NEP.BWDOOM.Rendering
{
    // From Managed Doom by Sinshu
    // Repo: https://github.com/sinshu/managed-doom/blob/master/ManagedDoom/src/Doom/Graphics/SpriteLookup.cs
    public static class SpriteLookup
    {
        public static SpriteDef[] spriteDefs;
        private static Dictionary<int, SpriteLump> cache;

        public static void Start()
        {
            MelonLoader.MelonLogger.Msg(System.ConsoleColor.Green, $"Start sprite def creation");

            var temp = new Dictionary<string, List<SpriteInfo>>();

            for(int i = 0; i < (int)SpriteNum.NUMSPRITES; i++)
            {
                temp.Add(Info.SpriteNames.str_Sprites[i], new List<SpriteInfo>());
            }

            cache = new Dictionary<int, SpriteLump>();

            foreach(var lump in WadDataManager.sprites)
            {
                var name = lump.name.Substring(0, 4);

                if (!temp.ContainsKey(name))
                {
                    continue;
                }

                var list = temp[name];

                {
                    int frame = lump.name[4] - 'A';
                    int rotation = lump.name[5] - '0';

                    while(list.Count < frame + 1)
                    {
                        list.Add(new SpriteInfo());
                    }

                    if(rotation == 0)
                    {
                        for(int i = 0; i < 8; i++)
                        {
                            if(list[frame].lumps[i] == null)
                            {
                                list[frame].lumps[i] = CachedRead(lump.offset, cache);
                                list[frame].flip[i] = false;
                            }
                        }
                    }
                    else
                    {
                        if(list[frame].lumps[rotation - 1] == null)
                        {
                            list[frame].lumps[rotation - 1] = CachedRead(lump.offset, cache);
                            list[frame].flip[rotation - 1] = true;
                        }
                    }
                }
            }

            spriteDefs = new SpriteDef[(int)SpriteNum.NUMSPRITES];

            for(int i = 0; i < spriteDefs.Length; i++)
            {
                var list = temp[Info.SpriteNames.str_Sprites[i]];
                var frames = new SpriteFrame[list.Count];

                for(int j = 0; j < frames.Length; j++)
                {
                    list[j].CheckCompletion();

                    var frame = new SpriteFrame(list[j].HasRotation(), list[j].lumps, list[j].flip);
                    frames[j] = frame;
                }

                spriteDefs[i] = new SpriteDef(frames);
            }

            MelonLoader.MelonLogger.Msg(System.ConsoleColor.Green, $"Sprite def creation done! Size {cache.Count}.");
        }

        private static SpriteLump CachedRead(int lump, Dictionary<int, SpriteLump> cache)
        {
            if (!cache.ContainsKey(lump))
            {
                string name = WadDataManager.GetSpriteLump(lump).name;
                MelonLoader.MelonLogger.Msg($"Cached lump {name}");
                cache.Add(lump, WadDataManager.GetSpriteLump(lump));
            }

            return cache[lump];
        }
    }
}