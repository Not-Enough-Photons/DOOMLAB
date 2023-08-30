using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.WAD;
using NEP.DOOMLAB.WAD.DataTypes;

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NEP.DOOMLAB.Rendering
{
    public static class SpriteLumpGenerator
    {
        private static int maxFrames = -1;
        private static int numRotations = -1;

        public static List<Patch> spritePatches;
        public static SpriteDef[] sprites;
        public static List<SpriteFrame> spriteFrames;

        private static SpriteFrame[] temporaryCacheFrames;
        private static SpriteDef temporarySpriteDef;

        public static void InitSpriteDefs()
        {
            sprites = new SpriteDef[Info.SpriteNames.Length];
            spriteFrames = new List<SpriteFrame>();

            for(int i = 0; i < Info.SpriteNames.Length; i++)
            {
                string spriteName = Info.SpriteNames[i];
                temporaryCacheFrames = new SpriteFrame[29];
                temporarySpriteDef = new SpriteDef();

                for(int f = 0; f < temporaryCacheFrames.Length; f++)
                {
                    temporaryCacheFrames[f].patches = new Patch[8];
                    temporaryCacheFrames[f].flipBits = new bool[8];
                }

                maxFrames = -1;
                numRotations = -1;

                for (int j = 0; j < spritePatches.Count; j++)
                {
                    Patch spritePatch = spritePatches[j];
                    string spritePatchName = spritePatch.name;

                    if (spritePatchName.StartsWith(spriteName))
                    {
                        int frame = 0;
                        int rotation = 0;

                        if(spritePatchName.Length == 6)
                        {
                            frame = spritePatchName[4] - 'A';
                            rotation = spritePatchName[5] - '0';
                            BuildSprite(spritePatch, frame, rotation, false);
                        }

                        if (spritePatchName.Length == 8)
                        {
                            frame = spritePatchName[4] - 'A';
                            rotation = spritePatchName[5] - '0';
                            BuildSprite(spritePatch, frame, rotation, true);
                        }
                    }
                }

                if (maxFrames == -1)
                {
                    sprites[i].ResetFrames();
                    continue;
                }

                maxFrames++;

                sprites[i].numFrames = maxFrames;
                sprites[i].spriteFrames = temporaryCacheFrames;
            }
        }

        public static void BuildSprite(Patch spritePatch, int frame, int rotation, bool flipped)
        {
            // we can tell if a sprite has rotations if the rotation is not 0 on the sprite name
            // a sprite can have 8 rotations
            // modern source ports allow for 16 rotEations, but i'll keep it simple for this

            // another thing, if a sprite can be flipped, it will have an additional two characters
            // another frame and another character for tic duration
            // i.e. BAL7 A1 A5 denotes this
            
            if(frame > maxFrames)
            {
                maxFrames = frame;
            }

            if(rotation > numRotations)
            {
                numRotations = rotation;
            }

            // No rotations, use the same lump for all rotations
            if(rotation == 0)
            {
                temporaryCacheFrames[frame].canRotate = false;
                for(int i = 0; i < 8; i++)
                {
                    temporaryCacheFrames[frame].patches[i] = spritePatch;
                    temporaryCacheFrames[frame].flipBits[i] = flipped;
                }

                numRotations = 1;

                return;
            }

            // Has rotations, store the frames into the temp array

            temporaryCacheFrames[frame].canRotate = true;
            
            rotation--;

            temporaryCacheFrames[frame].patches[rotation] = spritePatch;
            temporaryCacheFrames[frame].flipBits[rotation] = flipped;
            temporaryCacheFrames[frame].numRotations = numRotations;
        }
    }
}