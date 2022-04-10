using UnityEngine;

namespace NEP.BWDOOM.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class Thinker : MonoBehaviour
    {
        public Thinker(System.IntPtr ptr) : base(ptr) { }

        public Thinker prev;
        public Thinker next;
        public ThinkerState thinkerState;

        public virtual void Run()
        {

        }
    }
}
