using NEP.DOOMLAB.WAD;
using NEP.DOOMLAB.Sound;

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

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

        private List<GameObject> pooledAudioObjects;

        private void Awake()
        {
            Instance = this;

            LoadWADAudio(WADManager.Instance.LoadedWAD.sounds);

            pooledAudioObjects = new List<GameObject>();
            GameObject listObj = new GameObject("Pooled Audio");
            GameObject parent = new GameObject("Sound Manager");
            listObj.transform.parent = parent.transform;

            for (int i = 0; i < 256; i++)
            {
                GameObject pooledAudio = new GameObject("Poolee Audio");
                pooledAudio.transform.parent = listObj.transform;

                AudioSource source = pooledAudio.AddComponent<AudioSource>();
                source.playOnAwake = true;
                source.volume = 0.75f;
                source.dopplerLevel = 0; // no weird pitching based on relative velocity

                pooledAudio.AddComponent<PooledAudio>();
                pooledAudio.SetActive(false);
                pooledAudioObjects.Add(pooledAudio);
            }
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

        public void PlaySound(SoundType soundType, AudioSource source, bool fullVolume)
        {
            if(source == null)
            {
                return;
            }

            if((int)soundType < 1 || soundType == SoundType.sfx_None)
            {
                return;
            }

            AudioClip sound = GetSound(soundType);

            if (sound == null)
            {
                return;
            }

            source.clip = sound;
            source.spatialBlend = fullVolume ? 0f : 0.75f;
            source.Play();
        }

        public void PlaySound(SoundType soundType, Vector3 position, bool fullVolume)
        {
            if((int)soundType < 1 || soundType == SoundType.sfx_None)
            {
                return;
            }

            AudioClip sound = GetSound(soundType);

            if (sound == null)
            {
                return;
            }

            GameObject first = pooledAudioObjects.FirstOrDefault((inactive) => !inactive.activeInHierarchy);

            if (first != null)
            {
                AudioSource src = first.GetComponent<AudioSource>();
                src.clip = sound;
                src.spatialBlend = fullVolume ? 0f : 0.75f;
                first.transform.position = position;
                first.SetActive(true);
            }
        }
    }
}
