using NEP.DOOMLAB.WAD.DataTypes;

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
