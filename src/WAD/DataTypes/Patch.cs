using System.Collections.Generic;
using UnityEngine;

namespace NEP.DOOMLAB.WAD.DataTypes
{
    public struct Patch
    {
        public Patch(string name, short width, short height, short leftOffset, short topOffset)
        {
            this.name = name;
            this.width = width;
            this.height = height;
            this.leftOffset = leftOffset;
            this.topOffset = topOffset;
            output = null;
        }

        public string name;
        public short width;
        public short height;
        public short leftOffset;
        public short topOffset;
        public Texture2D output;
    }
}
