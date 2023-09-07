
using System.Collections.Generic;
using NEP.DOOMLAB.WAD.DataTypes;

namespace NEP.DOOMLAB.Rendering
{
    public struct SpriteDef
    {
        public int numFrames;
        public SpriteFrame[] spriteFrames;

        public void ResetFrames()
        {
            numFrames = 0;
        }

        public SpriteFrame GetFrame(int frame)
        {
            if(spriteFrames == null)
            {
                // return an empty sprite frame
                return new SpriteFrame();
            }

            if (frame > spriteFrames.Length - 1)
            {
                return spriteFrames[spriteFrames.Length - 1];
            }

            return spriteFrames[frame];
        }
    }
}
