using MelonLoader;
using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Game;
using NEP.DOOMLAB.Sound;
using SLZ.AI;
using SLZ.Combat;
using SLZ.Marrow.Data;
using SLZ.Marrow.Pool;
using SLZ.Marrow.Warehouse;

using System;
using System.Diagnostics;
using UnityEngine;

namespace NEP.DOOMLAB.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class Mobj : MonoBehaviour
    {
        public Mobj(System.IntPtr ptr) : base(ptr) { }

        public static Instances<Mobj> ComponentCache { get; private set; }

        public static Action<Mobj> OnDeath;

        public enum MoveDirection
        {
            EAST,
            NORTHEAST,
            NORTH,
            NORTHWEST,
            WEST,
            SOUTHWEST,
            SOUTH,
            SOUTHEAST,
            NODIR
        }

        public MobjInfo info;
        public State state;
        public StateNum currentState;
        public MobjType type;
        public MobjFlags flags;

        public Vector3 position;
        public Quaternion rotation;

        public SpriteNum sprite;
        public int frame;
        public float radius;
        public float height;

        public MobjBrain brain;
        public MobjProxy proxy;

        public Mobj target;
        public static Mobj player => Main.player;
        public Mobj tracer;
        public bool sightedPlayer = false;

        public Vector3 momentum;

        public int validCount;

        public float health;
        public int tics;
        public MoveDirection moveDirection;
        public int moveCount;
        public int reactionTime;
        public int threshold;
        public int lastLook;

        public Rigidbody rigidbody;
        public BoxCollider collider;

        public Player_Health playerHealth;
        public TriggerRefProxy triggerRefProxy;

        public AudioSource audioSource;

        public Action<Mobj> CurrentAction { get; private set; }
        public Stopwatch ActionStopwatch { get; private set; } = new Stopwatch();

        private void Awake()
        {
            info = Info.MobjInfos[(int)type];
            playerHealth = BoneLib.Player.rigManager.GetComponent<Player_Health>();

            if(ComponentCache == null)
            {
                ComponentCache = new Instances<Mobj>();
            }
            else
            {
                ComponentCache.AddInstance(GetInstanceID(), this);
            }
        }

        private void Start()
        {
            player.health = player.playerHealth.curr_Health;
            DoomGame.Instance.OnTick += WorldTick;
        }

        private void OnDestroy()
        {
            DoomGame.Instance.OnTick -= WorldTick;
        }

        private void WorldTick()
        {
            position = transform.position;
            UpdateThinker();
        }

        public void UpdateThinker()
        {
            if(Settings.DisableAI)
            {
                return;
            }

            if(Settings.NoTarget)
            {
                target = null;
            }

            if(Vector3.Distance(transform.position, player.transform.position) > Settings.ProjectilePruneDistance)
            {
                if(flags.HasFlag(MobjFlags.MF_MISSILE))
                {
                    MobjManager.Instance.RemoveMobj(this);
                    return;
                }
            }

            if (tics != -1)
            {
                tics--;

                if (tics <= 0)
                {
                    if(!SetState(state.nextstate))
                    {
                        return;
                    }
                }
            }
            else
            {
                if(!flags.HasFlag(MobjFlags.MF_COUNTKILL))
                {
                    return;
                }

                if(!Settings.RespawnMonsters)
                {
                    return;
                }

                moveCount++;

                if(moveCount < 12 * 35)
                {
                    return;
                }

                if(DoomGame.RNG.P_Random() > 4)
                {
                    return;
                }

                NightmareRespawn();
            }
        }

        public bool SetState(StateNum state)
        {
            currentState = state;

            State st;

            if (state == StateNum.S_NULL)
            {
                this.state = Info.states[(int)StateNum.S_NULL];
                MobjManager.Instance.RemoveMobj(this);
                return false;
            }

            st = Info.states[(int)state];
            this.state = st;
            this.tics = st.tics;
            this.sprite = st.sprite;
            this.frame = st.frame;

            ActionStopwatch = new Stopwatch();
            ActionStopwatch.Start();
            st.action?.Invoke(this);
            CurrentAction = st.action;
            ActionStopwatch.Stop();

            return true;
        }

        public void OnSpawn(Vector3 position, MobjType type)
        {
            this.info = Info.MobjInfos[(int)type];

            this.type = type;
            this.radius = info.radius;
            this.height = info.height;
            this.flags = info.flags;
            this.health = info.spawnHealth;
            this.reactionTime = info.reactionTime;

            State st = Info.states[(int)info.spawnState];

            this.state = st;
            this.tics = st.tics;
            this.sprite = st.sprite;
            this.frame = st.frame;

            transform.position = position;
        }

        public void OnRemove()
        {
            var spriteRenderer = GetComponentInChildren<Rendering.MobjRenderer>();
            Destroy(spriteRenderer);
            Destroy(gameObject);
        }

        public void SetFlag(MobjFlags flags)
        {
            this.flags ^= flags;

            collider.enabled = flags.HasFlag(MobjFlags.MF_SOLID);
            rigidbody.useGravity = !flags.HasFlag(MobjFlags.MF_NOGRAVITY);
        }

        public void Kill()
        {
            if(this == player)
            {
                return;
            }

            flags &= ~(MobjFlags.MF_SHOOTABLE | MobjFlags.MF_FLOAT | MobjFlags.MF_SKULLFLY);

            if(type != MobjType.MT_SKULL)
            {
                flags &= ~MobjFlags.MF_NOGRAVITY;
            }

            if (!flags.HasFlag(MobjFlags.MF_NOGRAVITY))
            {
                if(rigidbody != null)
                {
                    rigidbody.useGravity = true;
                }
            }

            flags |= MobjFlags.MF_CORPSE | MobjFlags.MF_DROPOFF;
            
            if(collider != null)
            {
                collider.center = Vector3.zero;
                collider.size = new Vector3(radius / 32f, 0.01f, radius / 32f);
            }

            if (health < -info.spawnHealth && info.xDeathState != StateNum.S_NULL)
            {
                SetState(info.xDeathState);
            }
            else
            {
                SetState(info.deathState);
            }

            tics -= DoomGame.RNG.P_Random() & 3;

            if(tics < 1)
            {
                tics = 1;
            }

            if(flags.HasFlag(MobjFlags.MF_COUNTKILL))
            {
                if(Mobj.player.playerHealth.deathIsImminent)
                {
                    Mobj.player.playerHealth.LifeSavingDamgeDealt();
                }
            }

            SpawnMobjAmmo(type);

            sightedPlayer = false;

            OnDeath?.Invoke(this);
        }

        public void NightmareRespawn()
        {
            MobjManager.Instance.SpawnMobj(transform.position, MobjType.MT_TFOG);
            var mo = MobjManager.Instance.SpawnMobj(transform.position, type);
            SoundManager.Instance.PlaySound(SoundType.sfx_telept, transform.position, false);
            mo.reactionTime = 18;
            MobjManager.Instance.RemoveMobj(this);
        }

        public void SpawnMobjAmmo(MobjType type)
        {
            string lightAmmoBarcode = "c1534c5a-683b-4c01-b378-6795416d6d6f";
            string mediumAmmoBarcode = "c1534c5a-57d4-4468-b5f0-c795416d6d6f";
            string heavyAmmoBarcode = "c1534c5a-97a9-43f7-be30-6095416d6d6f";

            string targetBarcode;

            switch(type)
            {
                case MobjType.MT_WOLFSS:
                case MobjType.MT_POSSESSED:
                    targetBarcode = lightAmmoBarcode;
                    break;
                case MobjType.MT_SHOTGUY:
                    targetBarcode = heavyAmmoBarcode;
                    break;
                case MobjType.MT_CHAINGUY:
                    targetBarcode = mediumAmmoBarcode;
                    break;
                default:
                    return;
            }

            SpawnableCrateReference ammoCrateRef = new SpawnableCrateReference(targetBarcode);
            Spawnable ammo = new Spawnable()
            {
                crateRef = ammoCrateRef
            };
            
            AssetSpawner.Register(ammo);
            BoneLib.Nullables.NullableMethodExtensions.PoolManager_Spawn(ammo, transform.position, default, default);
        }
    }
}