using UnityEngine;

namespace NEP.DOOMLAB.WAD.DataTypes
{
    public struct Sound
    {
        public Sound(byte id, short sampleRate, ushort sampleCount, byte[] soundData)
        {
            this.id = id;
            this.sampleRate = sampleRate;
            this.sampleCount = sampleCount;
            this.soundData = soundData;
            this.output = null;
        }

        public int id;
        public int sampleRate;
        public int sampleCount;
        public byte[] soundData;
        public AudioClip output;
    }
}
