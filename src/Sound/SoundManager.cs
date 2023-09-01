using NEP.DOOMLAB.WAD;
using NEP.DOOMLAB.Sound;

using UnityEngine;

namespace NEP.DOOMLAB.Sound
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class SoundManager : MonoBehaviour
    {
        public SoundManager(System.IntPtr ptr) : base(ptr) { }

        public static SoundManager Instance { get; private set; }

        private static WAD.DataTypes.Sound[] soundLumps;

        private void Awake()
        {
            Instance = this;

            soundLumps = WADManager.Instance.file.sounds.ToArray();
        }

        private AudioClip GetSound(SoundType soundType)
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
            AudioSource.PlayClipAtPoint(sound, position, 0.25f);
        }
    }
}
