using NEP.DOOMLAB.WAD.DataTypes;
using System.Collections.Generic;

namespace NEP.DOOMLAB.Rendering
{
    public struct SpriteFrame
    {
        public int numRotations;
        public bool canRotate;
        public Patch[] patches;
        public bool[] flipBits;
    }
}
