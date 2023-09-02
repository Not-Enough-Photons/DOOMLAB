using UnityEngine;

using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Rendering;
using UnityEngine.AI;
using NEP.DOOMLAB.Sound;
using System;
using SLZ.Marrow.Warehouse;
using System.Collections.Generic;
using SLZ.AI;

namespace NEP.DOOMLAB.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class MobjManager : MonoBehaviour
    {
        public MobjManager(System.IntPtr ptr) : base(ptr) { }

        public static MobjManager Instance { get; private set; }

        public static Dictionary<string, MobjType> npcLookup = new Dictionary<string, MobjType>()
        {
            { "Zombieman", MobjType.MT_POSSESSED },
            { "Shotgun Guy", MobjType.MT_SHOTGUY },
            { "Chaingun Guy", MobjType.MT_CHAINGUY },
            { "Imp", MobjType.MT_TROOP },
            { "Pinky Demon", MobjType.MT_SERGEANT },
            { "Spectre", MobjType.MT_SHADOWS},
            { "Lost Soul", MobjType.MT_SKULL },
            { "Cacodemon", MobjType.MT_HEAD },
            { "Hell Knight", MobjType.MT_KNIGHT },
            { "Baron of Hell", MobjType.MT_BRUISER },
            { "Arachnotron", MobjType.MT_BABY },
            { "Mancubus", MobjType.MT_FATSO },
            { "Revenant", MobjType.MT_UNDEAD },
            { "Pain Elemental", MobjType.MT_PAIN },
            { "Arch-Vile", MobjType.MT_VILE },
            { "Spider Mastermind", MobjType.MT_SPIDER },
            { "Cyberdemon", MobjType.MT_CYBORG },
            { "SS Soldier", MobjType.MT_WOLFSS },
            { "Commander Keen", MobjType.MT_KEEN }
        };

        public GameObject mobjPrefab;

        public List<Mobj> mobjs;

        private bool spawnMenuPopulated;

        private void Awake()
        {
            Instance = this;
            mobjs = new List<Mobj>();
            mobjPrefab = Main.mobjTemplate;
        }

        private void Start()
        {
            SpawnMobj(Vector3.zero, MobjType.MT_POSSESSED);
        }

        public Mobj SpawnMobj(Vector3 position, MobjType type)
        {
            if (mobjPrefab == null)
            {
                throw new System.Exception("MOBJ base prefab doesn't exist!");
            }

            GameObject mobjBase = GameObject.Instantiate(mobjPrefab, position, Quaternion.identity);
            Mobj mobj = mobjBase.AddComponent<Mobj>();
            mobj.brain = mobjBase.AddComponent<MobjBrain>();
            mobj.triggerRefProxy = mobjBase.AddComponent<TriggerRefProxy>();

            mobj.triggerRefProxy.chestTran = mobj.transform;
            mobj.triggerRefProxy.triggerType = TriggerRefProxy.TriggerType.Npc;
            mobj.triggerRefProxy.npcType = TriggerRefProxy.NpcType.FordHair | TriggerRefProxy.NpcType.FordShortHair;
            var trpSphere = mobjBase.AddComponent<SphereCollider>();
            trpSphere.isTrigger = true;
            trpSphere.radius = 5f;
            mobj.triggerRefProxy.targetHead = mobj.rigidbody;
            mobj.triggerRefProxy.root = mobj.gameObject;

            mobjBase.transform.GetChild(0).gameObject.AddComponent<DoomSpriteRenderer>();
            mobjBase.transform.GetChild(0).gameObject.AddComponent<BillboardLookAt>();

            mobj.rigidbody = mobjBase.AddComponent<Rigidbody>();
            mobj.collider = mobjBase.AddComponent<BoxCollider>();

            mobj.gameObject.layer = LayerMask.NameToLayer("EnemyColliders");
            mobj.collider.gameObject.layer = LayerMask.NameToLayer("EnemyColliders");

            mobj.OnSpawn(position, type);

            mobj.name = $"[MOBJ] - {mobj.type}";

            mobj.rigidbody.mass = mobj.info.mass / 32f;
            mobj.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            mobj.collider.size = new Vector3(mobj.radius / 32f, mobj.height / 32f, mobj.radius / 32f);

            if (!mobj.flags.HasFlag(MobjFlags.MF_SOLID))
            {
                mobj.collider.enabled = false;
            }

            if (mobj.flags.HasFlag(MobjFlags.MF_NOGRAVITY))
            {
                mobj.rigidbody.useGravity = false;
            }

            if(mobj.flags.HasFlag(MobjFlags.MF_MISSILE))
            {
                mobj.collider.enabled = true;
                mobj.rigidbody.drag = 0;
            }

            mobjs.Add(mobj);

            return mobj;
        }

        public Mobj SpawnMissile(Mobj source, Mobj destination, MobjType type)
        {
            Vector3 position = source.transform.position;
            Quaternion rotation = source.transform.rotation;
            Mobj projectile = SpawnMobj(position, type);

            projectile.gameObject.AddComponent<MobjCollisionEvents>();

            projectile.target = source;

            projectile.transform.rotation = rotation;

            projectile.rigidbody.velocity = (destination.transform.position - source.transform.position).normalized * projectile.info.speed;

            Physics.IgnoreCollision(source.collider, projectile.collider);

            if (projectile.info.seeSound != Sound.SoundType.sfx_None)
            {
                SoundManager.Instance.PlaySound(projectile.info.seeSound, projectile.transform.position, false);
            }

            return projectile;
        }

        public void RemoveMobj(Mobj mobj)
        {
            mobj.OnRemove();
            mobjs.Remove(mobj);
        }
    }
}