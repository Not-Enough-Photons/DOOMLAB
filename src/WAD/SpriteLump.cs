using UnityEngine;

namespace NEP.BWDOOM.WAD
{
    public class SpriteLump
    {
        public SpriteLump(int lumpRef, string name, Texture2D sprite)
        {
            this.offset = lumpRef;
            this.name = name;
            this.sprite = sprite;

            this.sprite.hideFlags = HideFlags.DontUnloadUnusedAsset;
        }

        public int offset;
        public string name;
        public Texture2D sprite;
    }
}
