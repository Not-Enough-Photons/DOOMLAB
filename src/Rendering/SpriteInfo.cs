using NEP.BWDOOM.WAD;

namespace NEP.BWDOOM.Rendering
{
    public class SpriteInfo
    {
        public SpriteLump[] lumps;
        public bool[] flip;

        public SpriteInfo()
        {
            this.lumps = new SpriteLump[8];
            this.flip = new bool[8];
        }

        public bool CheckCompletion()
        {
            for(int i = 0; i < lumps.Length; i++)
            {
                if(lumps[i] == null)
                {
                    return false;
                }
            }

            return true;
        }

        public bool HasRotation()
        {
            for(int i = 0; i < lumps.Length; i++)
            {
                if(lumps[i] != lumps[0])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
