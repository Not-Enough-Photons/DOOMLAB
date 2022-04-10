using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NEP.BWDOOM.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class ThinkerManager : MonoBehaviour
    {
        public ThinkerManager(System.IntPtr ptr) : base(ptr) { }

        public static ThinkerManager instance;

        private Thinker cap;

        private float delayT = 1f / 35f;
        private float delay;

        public void Add(Thinker thinker)
        {
            cap.prev.next = thinker;
            thinker.next = cap;
            thinker.prev = cap.prev;
            cap.prev = thinker;
        }

        public void Remove(Thinker thinker)
        {
            thinker.thinkerState = ThinkerState.Removed;
        }

        private void Update()
        {
            delay += Time.deltaTime;

            if (delay >= delayT)
            {
                delay = 0f;
                RunTicks(Main.play);
            }
        }

        public void RunTicks(bool play)
        {
            Thinker current = cap.next;

            while (current != cap)
            {
                if (current.thinkerState == ThinkerState.Removed)
                {
                    current.next.prev = current.prev;
                    current.prev.next = current.next;
                }
                else
                {
                    if (current.thinkerState == ThinkerState.Active)
                    {
                        current.Run();
                    }
                }

                current = current.next;
            }
        }

        private void ResetThinkers()
        {
            cap.prev = cap.next = cap;
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(instance.gameObject);
            }

            DontDestroyOnLoad(instance.gameObject);

            cap = new GameObject("Thinker").AddComponent<Thinker>();
            cap.transform.parent = transform;
            cap.prev = cap.next = cap;
        }
    }
}
