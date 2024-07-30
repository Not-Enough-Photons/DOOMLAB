using System.Collections.Generic;

using UnityEngine;

using BoneLib;

using NEP.DOOMLAB.WAD;
using NEP.DOOMLAB.Sound;

namespace NEP.DOOMLAB.Sound
{
    public class SoundManager
    {
        public SoundManager()
        {
            Awake();
        }

        public static SoundManager Instance { get; private set; }

        private static WAD.DataTypes.Sound[] soundLumps;

        private void Awake()
        {
            Instance = this;

            LoadWADAudio(WADManager.Instance.LoadedWAD.sounds);
        }

        public void LoadWADAudio(List<WAD.DataTypes.Sound> sounds)
        {
            LoadWADAudio(sounds.ToArray());
        }

        public void LoadWADAudio(WAD.DataTypes.Sound[] sounds)
        {
            soundLumps = sounds;
        }

        public AudioClip GetSound(SoundType soundType)
        {
            string name = soundType.ToString();
            string cleanedName = "DS" + name.Split('_')[1].ToUpper();

            foreach(var lump in soundLumps)
            {
                if(lump.output.name == cleanedName)
                {
                    return lump.output;
                }
            }

            return null;
        }

        public void PlaySound(SoundType soundType, Vector3 position, bool fullVolume)
        {
            if((int)soundType < 1 || soundType == SoundType.sfx_None)
            {
                return;
            }

            AudioClip sound = GetSound(soundType);

            Audio.PlayAtPoint(sound, position, Audio.InHead, 1f, 1f, fullVolume ? 0f : 0.95f);
        }
    }
}
