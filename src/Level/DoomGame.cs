using UnityEngine;
using NEP.BWDOOM.Entities;

namespace NEP.BWDOOM.Level
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class DoomGame : MonoBehaviour
    {
        public DoomGame(System.IntPtr ptr) : base(ptr) { }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
