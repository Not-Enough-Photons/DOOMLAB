using UnityEngine;

using SLZ.AI;
using SLZ.Bonelab;
using SLZ.Data;

namespace NEP.DOOMLAB.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class MobjProxy : MonoBehaviour 
    {
        public MobjProxy(System.IntPtr ptr) : base(ptr) { }

        public AIBrain AIBrain => aiBrain;

        private Mobj mobj;
        private AIBrain aiBrain;
        private SphereCollider sphereCollider;
        private TriggerRefProxy triggerRefProxy;

        private void Awake()
        {
            mobj = GetComponentInParent<Mobj>();

            sphereCollider = GetComponent<SphereCollider>();
        }

        private void Start()
        {
            
        }

        private void OnEnable()
        {
            Mobj.OnDeath += (mobj) => OnAIBrainDeath();
        }

        private void OnDisable()
        {
            Mobj.OnDeath -= (mobj) => OnAIBrainDeath();
        }

        private void OnAIBrainDeath()
        {
            aiBrain.onNPC_DeathDelegate?.Invoke(aiBrain);
        }
    }
}