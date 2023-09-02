using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Game;
using NEP.DOOMLAB.Sound;
using SLZ.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NEP.DOOMLAB.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class Mobj : MonoBehaviour
    {
        public Mobj(System.IntPtr ptr) : base(ptr) { }

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

        public Mobj target;
        public static Mobj player;
        public Mobj tracer;

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

        public Health playerHealth;
        public TriggerRefProxy triggerRefProxy;

        private bool removedMobj;

        private void Awake()
        {
            info = Info.MobjInfos[(int)type];
        }

        private void Start()
        {
            DoomGame.Instance.OnTick += WorldTick;

            target = Main.player;
        }

        private void OnDestroy()
        {
            DoomGame.Instance.OnTick -= WorldTick;
        }

        private void WorldTick()
        {
            if (!removedMobj)
            {
                UpdateThinker();
            }
        }

        public void UpdateThinker()
        {
            // Too far away, stop updating
            if(Vector3.Distance(transform.position, BoneLib.Player.playerHead.position) > 2048)
            {
                return;
            }

            if (tics != -1)
            {
                tics--;

                if (tics <= 0 && !SetState(state.nextstate))
                {
                    return;
                }
            }
        }

        public bool SetState(StateNum state)
        {
            State st;

            currentState = state;

            if (state == StateNum.S_NULL)
            {
                this.state = Info.GetState(StateNum.S_NULL);
                MobjManager.Instance.RemoveMobj(this);
                return false;
            }

            st = Info.GetState(state);
            this.state = st;
            this.tics = st.tics;
            this.sprite = st.sprite;
            this.frame = st.frame;

            System.Action<Mobj> action = st.action;

            BoneLib.SafeActions.InvokeActionSafe(action, this);

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

            State st = Info.GetState(info.spawnState);

            this.state = st;
            this.tics = st.tics;
            this.sprite = st.sprite;
            this.frame = st.frame;

            transform.position = position;
        }

        public void OnRemove()
        {
            var spriteRenderer = GetComponentInChildren<Rendering.DoomSpriteRenderer>();
            Destroy(spriteRenderer);
            Destroy(gameObject);
        }

        public void TakeDamage(float damage, Mobj inflictor)
        {
            if(!flags.HasFlag(MobjFlags.MF_SHOOTABLE))
            {
                return;
            }

            if (health <= 0f)
            {
                return;
            }

            if(flags.HasFlag(MobjFlags.MF_SKULLFLY))
            {
                rigidbody.velocity = Vector3.zero;
            }

            health -= damage;
            if(health <= 0)
            {
                Kill();
                return;
            }

            if(DoomGame.RNG.P_Random() < info.painChance && !flags.HasFlag(MobjFlags.MF_SKULLFLY))
            {
                flags ^= MobjFlags.MF_JUSTHIT;
                SetState(info.painState);
            }

            reactionTime = 0;

            // TODO: will implement vile logic here later
        }

        public void Kill()
        {
            flags &= ~(MobjFlags.MF_SHOOTABLE | MobjFlags.MF_FLOAT | MobjFlags.MF_SKULLFLY);

            if(type == MobjType.MT_SKULL)
            {
                flags &= ~MobjFlags.MF_NOGRAVITY;
            }
            
            collider.size = new Vector3(radius / 32f, (height / 32f) / 4f, radius / 32f);

            if(health < -info.spawnHealth && info.xDeathState != StateNum.S_NULL)
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
            
            Mobj.player.playerHealth.curr_Health += 100;
        }
    }
}