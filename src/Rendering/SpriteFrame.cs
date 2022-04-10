using NEP.BWDOOM.Info;
using NEP.BWDOOM.WAD;

namespace NEP.BWDOOM.Rendering
{
    public class SpriteFrame
    {
        public bool rotate;
        public SpriteLump[] lumps;
        public bool[] flip;

        public SpriteFrame(bool rotate, SpriteLump[] lumps, bool[] flip)
        {
            this.rotate = rotate;
            this.lumps = lumps;
            this.flip = flip;
        }
    }
}
