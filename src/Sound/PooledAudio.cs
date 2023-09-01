using UnityEngine;

namespace NEP.DOOMLAB.Sound
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class PooledAudio : MonoBehaviour
    {
        public PooledAudio(System.IntPtr ptr) : base(ptr) { }

        private AudioSource source;
        private float time;

        private void Start()
        {
            source = GetComponent<AudioSource>();
        }

        private void Update()
        {
            time += Time.deltaTime;

            if (time >= source.clip.length)
            {
                gameObject.SetActive(false);
                time = 0f;
            }
        }
    }
}
