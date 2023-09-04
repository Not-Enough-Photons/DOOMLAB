using SLZ.Rig;
using UnityEngine;

namespace NEP.DOOMLAB.Player
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class DoomPlayer : MonoBehaviour
    {
        public DoomPlayer(System.IntPtr ptr) : base(ptr) { }

        private PhysicsRig physicsRig;

        private Collider[] playerColliders;

        private void Awake()
        {
            physicsRig = BoneLib.Player.physicsRig;
        }

        private void Start()
        {
            playerColliders = new Collider[physicsRig.selfRbs.Count];
        }
    }
}