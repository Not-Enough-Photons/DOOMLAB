using System.Collections.Generic;
using System.Linq;
using SLZ.Rig;
using UnityEngine;

namespace NEP.DOOMLAB.Player
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class DoomPlayer : MonoBehaviour
    {
        public DoomPlayer(System.IntPtr ptr) : base(ptr) { }

        private PhysicsRig physicsRig;

        private List<Collider> playerColliders;

        private void Awake()
        {
            physicsRig = BoneLib.Player.physicsRig;
        }

        private void Start()
        {
            playerColliders = new List<Collider>();

            foreach(var rigidbody in physicsRig.selfRbs)
            {
                playerColliders.Add(rigidbody.GetComponent<Collider>());
            }
        }

        public Collider GetCollider(Collider collider)
        {
            return playerColliders.First((col) => col == collider);
        }
    }
}