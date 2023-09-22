using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.WAD;
using NEP.DOOMLAB.WAD.DataTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NEP.DOOMLAB.Rendering
{
    // From Managed Doom, by sinshu & Moien Tajik
    // https://github.com/sinshu/managed-doom/blob/master/ManagedDoom/src/Doom/Graphics/SpriteLookup.cs
    public static class FrameBuilder
    {
        public static SpriteDef[] spriteDefs;

        private static string[] spriteNames;
        private static Dictionary<string, List<SpriteFrame>> temp;
        private static Patch[] spritePatches;

        public static void GenerateTable()
        {
            spriteNames = Info.SpriteNames;
            spritePatches = WADManager.Instance.LoadedWAD.patches.ToArray();
            temp = new Dictionary<string, List<SpriteFrame>>();
            for(int i = 0; i < spriteNames.Length; i++)
            {
                temp.Add(spriteNames[i], new List<SpriteFrame>());
            }

            foreach(var spritePatch in spritePatches)
            {
                string name = spritePatch.name;
                string cutName = name.Substring(0, 4);

                if(!temp.ContainsKey(cutName))
                {
                    continue;
                }

                var list = temp[cutName];

                {
                    int frame = name[4] - 'A';
                    int rotation = name[5] - '0';

                    while (list.Count < frame + 1)
                    {
                        list.Add(new SpriteFrame());
                    }

                    if (rotation == 0)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            list[frame].patches[i] = spritePatch;
                            list[frame].flipBits[i] = false;
                        }
                    }
                    else
                    {
                        list[frame].patches[rotation - 1] = spritePatch;
                        list[frame].flipBits[rotation - 1] = false;
                    }
                }

                if (name.Length == 8)
                {
                    int frame = name[6] - 'A';
                    int rotation = name[7] - '0';

                    while(list.Count < frame + 1)
                    {
                        list.Add(new SpriteFrame());
                    }

                    if (rotation == 0)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            list[frame].patches[i] = spritePatch;
                            list[frame].flipBits[i] = true;
                        }
                    }
                    else
                    {
                        list[frame].patches[rotation - 1] = spritePatch;
                        list[frame].flipBits[rotation - 1] = true;
                    }
                }
            }

            spriteDefs = new SpriteDef[spriteNames.Length];

            for (int i = 0; i < spriteDefs.Length; i++)
            {
                var list = temp[spriteNames[i]];
                var frames = new SpriteFrame[list.Count];

                for (int j = 0; j < frames.Length; j++)
                {
                    var frame = new SpriteFrame();
                    frame.patches = list[j].patches;
                    frame.flipBits = list[j].flipBits;
                    frames[j] = frame;
                }

                spriteDefs[i] = new SpriteDef();
                spriteDefs[i].spriteFrames = frames;
            }
        }
    }
}
