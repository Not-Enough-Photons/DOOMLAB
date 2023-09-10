using UnityEngine;

using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Rendering;
using NEP.DOOMLAB.Sound;
using NEP.DOOMLAB.Game;

using SLZ.Combat;

using System.Collections.Generic;

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
            { "Commander Keen", MobjType.MT_KEEN },
            { "Icon of Sin", MobjType.MT_BOSSBRAIN}
        };

        public static Dictionary<string, MobjType> itemLookup = new Dictionary<string, MobjType>()
        {
            { "Megasphere", MobjType.MT_MEGA },
            { "Partial Invisibility", MobjType.MT_INV },
        };

        public static Dictionary<string, MobjType> decorationLookup = new Dictionary<string, MobjType>()
        {
            //{ "" }
        };

        public GameObject mobjPrefab;

        public List<Mobj> mobjs;

        private void Awake()
        {
            Instance = this;
            mobjs = new List<Mobj>();
            mobjPrefab = Main.mobjTemplate;
        }

        public bool CheckThing(Mobj thing, Mobj other)
        {
            if(!thing.flags.HasFlag(MobjFlags.MF_SOLID | MobjFlags.MF_SPECIAL | MobjFlags.MF_SHOOTABLE))
            {
                return true;
            }

            if(thing == other)
            {
                return true;
            }

            if(other.flags.HasFlag(MobjFlags.MF_SKULLFLY))
            {
                float damage = ((DoomGame.RNG.P_Random() % 8) + 1) * other.info.damage;

                thing.TakeDamage(damage, other, other);

                other.flags &= ~MobjFlags.MF_SKULLFLY;
                other.rigidbody.velocity = Vector3.zero;
                
                other.SetState(other.info.spawnState);

                return false;
            }

            if (other.flags.HasFlag(MobjFlags.MF_MISSILE))
            {
                if (other.target != null && (
                other.target.type == thing.type ||
                (other.target.type == MobjType.MT_KNIGHT && thing.type == MobjType.MT_BRUISER) ||
                (other.target.type == MobjType.MT_BRUISER && thing.type == MobjType.MT_KNIGHT)))
                {
                    if (thing == other.target)
                    {
                        return true;
                    }

                    if (thing.type != MobjType.MT_PLAYER)
                    {
                        return false;
                    }
                }

                if (!thing.flags.HasFlag(MobjFlags.MF_SHOOTABLE))
                {
                    return !thing.flags.HasFlag(MobjFlags.MF_SOLID);
                }

                float damage = ((DoomGame.RNG.P_Random() % 8) + 1) * other.info.damage;
                thing.TakeDamage(damage, other, other.target);

                return false;
            }

            return !thing.flags.HasFlag(MobjFlags.MF_SOLID);
        }

        public Mobj SpawnMobj(Vector3 position, MobjType type, float angle = 0f)
        {
            if (mobjPrefab == null)
            {
                throw new System.Exception("MOBJ base prefab doesn't exist!");
            }

            GameObject mobjBase = GameObject.Instantiate(mobjPrefab, position, Quaternion.AngleAxis(angle, Vector3.up));
            Mobj mobj = mobjBase.AddComponent<Mobj>();
            mobj.brain = mobjBase.AddComponent<MobjBrain>();

            if(mobj.flags.HasFlag(MobjFlags.MF_SHOOTABLE) || mobj.flags.HasFlag(MobjFlags.MF_COUNTKILL))
            {
                var trpSphere = new GameObject();
                trpSphere.transform.parent = mobj.transform;
                trpSphere.AddComponent<MobjProxy>();
            }

            mobjBase.transform.GetChild(0).gameObject.AddComponent<MobjRenderer>();

            mobj.rigidbody = mobjBase.AddComponent<Rigidbody>();
            mobj.collider = mobjBase.AddComponent<BoxCollider>();
            mobj.audioSource = mobjBase.AddComponent<AudioSource>();

            var impactPropertiesManager = mobj.gameObject.AddComponent<ImpactPropertiesManager>();
            impactPropertiesManager.surfaceData = BoneLib.Player.physicsRig.GetComponent<ImpactPropertiesManager>().surfaceData;

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
                SoundManager.Instance.PlaySound(projectile.info.seeSound, projectile.audioSource, false);
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