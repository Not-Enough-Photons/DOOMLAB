using NEP.DOOMLAB.WAD;
using NEP.DOOMLAB.Sound;

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace NEP.DOOMLAB.Sound
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class SoundManager : MonoBehaviour
    {
        public SoundManager(System.IntPtr ptr) : base(ptr) { }

        public static SoundManager Instance { get; private set; }

        private static WAD.DataTypes.Sound[] soundLumps;

        private List<GameObject> pooledAudioObjects;

        private void Awake()
        {
            Instance = this;

            soundLumps = WADManager.Instance.file.sounds.ToArray();

            pooledAudioObjects = new List<GameObject>();
            GameObject listObj = new GameObject("Pooled Audio");
            listObj.transform.parent = transform;

            for (int i = 0; i < 64; i++)
            {
                GameObject pooledAudio = new GameObject("Poolee Audio");
                pooledAudio.transform.parent = listObj.transform;

                AudioSource source = pooledAudio.AddComponent<AudioSource>();
                source.playOnAwake = true;
                source.volume = 5f;

                pooledAudio.AddComponent<PooledAudio>();
                pooledAudio.SetActive(false);
                pooledAudioObjects.Add(pooledAudio);
            }
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

            GameObject first = pooledAudioObjects.FirstOrDefault((inactive) => !inactive.activeInHierarchy);
            AudioSource src = first.GetComponent<AudioSource>();

            if (first != null)
            {
                src.clip = sound;
                src.spatialBlend = fullVolume ? 0f : 1f;
                first.transform.position = position;
                first.SetActive(true);
            }
        }
    }
}
