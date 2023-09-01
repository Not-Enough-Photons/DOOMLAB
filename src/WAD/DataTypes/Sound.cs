using UnityEngine;

namespace NEP.DOOMLAB.WAD.DataTypes
{
    public struct Sound
    {
        public Sound(int id, int sampleRate, int sampleCount, byte[] soundData)
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
