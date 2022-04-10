using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace NEP.BWDOOM.Sound
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class SFXManager : MonoBehaviour
    {
        public SFXManager(System.IntPtr ptr) : base(ptr) { }

        public static SFXManager instance;

        public AudioClip[] sounds = new AudioClip[(int)SFXEnum.NUMSFX];

        private const int NUMSFX = (int)SFXEnum.NUMSFX;

        private int poolSize = 10;
        private GameObject audioPrefab;
        private List<AudioSource> pooledSources;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(instance.gameObject);
            }

            DontDestroyOnLoad(instance.gameObject);

            audioPrefab = CreateAudioPrefab(parentToSelf: true);

            PopulateAudioPool(poolSize, audioPrefab);
        }

        private GameObject CreateAudioPrefab(bool parentToSelf)
        {
            GameObject prefab = new GameObject("Pooled Source");
            prefab.AddComponent<AudioSource>();

            if (parentToSelf)
            {
                prefab.transform.parent = transform;
            }

            return prefab;
        }

        private void PopulateAudioPool(int poolSize, GameObject prefab)
        {
            int i = 0;

            for(i = 0; i < poolSize; i++)
            {
                GameObject obj = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
                obj.SetActive(false);
                pooledSources.Add(obj.GetComponent<AudioSource>());
            }
        }

        private GameObject AddToPool()
        {
            GameObject obj = GameObject.Instantiate(audioPrefab, Vector3.zero, Quaternion.identity);
            obj.SetActive(false);
            pooledSources.Add(obj.GetComponent<AudioSource>());
            return obj;
        }

        private AudioClip GetSFXFromEnum(SFXEnum sfx_id)
        {
            int idx = (int)sfx_id;

            if(idx >= NUMSFX)
            {
                return sounds[sounds.Length - 1];
            }

            return sounds[idx];
        }

        private void SpawnFromPool(Vector3 position, AudioClip audio, bool fullVolume)
        {
            GameObject current = pooledSources.FirstOrDefault((first) => !first.isActiveAndEnabled).gameObject;

            if(current == null)
            {
                AddToPool();
            }
            else
            {
                AudioSource source = current.GetComponent<AudioSource>();
                current.transform.position = position;
                source.clip = audio;
                source.spatialBlend = fullVolume ? 0f : 1f;

                source.gameObject.SetActive(true);
            }
        }

        public void S_StartSoundAtVolume(Vector3 origin, SFXEnum sfx_id, bool fullVolume)
        {
            int id = (int)sfx_id;

            // check for a bogus SFXenum
            if(id < 1 || id > NUMSFX)
            {
                Debug.LogError($"Bad SFX index: {id}");
            }

            AudioClip sfx = GetSFXFromEnum(sfx_id);

            if(sfx == null) { return; }

            SpawnFromPool(origin, sfx, fullVolume);
        }
    }
}
