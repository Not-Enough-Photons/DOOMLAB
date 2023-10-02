namespace NEP.DOOMLAB.Rendering
{
    public class SpriteDef
    {
        public int numFrames;
        public SpriteFrame[] spriteFrames;

        public void ResetFrames()
        {
            numFrames = 0;
        }
    }
}
