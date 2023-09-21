using UnityEngine;

namespace NEP.DOOMLAB.WAD.DataTypes
{
    public struct Sound
    {
        public Sound(string soundName, byte id, short sampleRate, ushort sampleCount, byte[] soundData)
        {
            this.soundName = soundName;
            this.id = id;
            this.sampleRate = sampleRate;
            this.sampleCount = sampleCount;
            this.soundData = soundData;
            this.output = null;
        }

        public string soundName;
        public int id;
        public int sampleRate;
        public int sampleCount;
        public byte[] soundData;
        public AudioClip output;
    }
}
