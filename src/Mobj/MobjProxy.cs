using UnityEngine;

using SLZ.AI;

namespace NEP.DOOMLAB.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class MobjProxy : MonoBehaviour 
    {
        public MobjProxy(System.IntPtr ptr) : base(ptr) { }

        public AIBrain AIBrain => aiBrain;

        private Mobj mobj;
        private AIBrain aiBrain;
        private TriggerRefProxy triggerRefProxy;
        private SphereCollider sphereCollider;

        private void Awake()
        {
            gameObject.name = "TriggerRefProxy";
            transform.localPosition = Vector3.zero;

            mobj = GetComponentInParent<Mobj>();

            if(GetComponent<TriggerRefProxy>())
            {
                return;
            }

            aiBrain = mobj.gameObject.AddComponent<AIBrain>();
            triggerRefProxy = gameObject.AddComponent<TriggerRefProxy>();
            sphereCollider = gameObject.AddComponent<SphereCollider>();
        }

        private void Start()
        {
            sphereCollider.isTrigger = true;
            sphereCollider.radius = 5f;

            // has to be set, otherwise, other NPCs won't target us
            gameObject.layer = LayerMask.NameToLayer("Trigger");

            InitializeRefProxy();
        }

        private void OnEnable()
        {
            Mobj.OnDeath += (mobj) => OnAIBrainDeath();
        }

        private void OnDisable()
        {
            Mobj.OnDeath -= (mobj) => OnAIBrainDeath();
        }

        private void InitializeRefProxy()
        {
            triggerRefProxy.triggerType = TriggerRefProxy.TriggerType.Npc;
            triggerRefProxy.npcType = TriggerRefProxy.NpcType.FordShortHair;
            triggerRefProxy.root = mobj.gameObject;
            triggerRefProxy.chestTran = mobj.transform;
            triggerRefProxy.targetHead = mobj.rigidbody;
            triggerRefProxy._aiManager = aiBrain;
        }

        private void OnAIBrainDeath()
        {
            aiBrain.onNPC_DeathDelegate?.Invoke(aiBrain);
        }
    }
}