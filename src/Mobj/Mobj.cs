using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Game;
using NEP.DOOMLAB.Sound;
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

        public Mobj target;
        public Mobj player;
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
            if (tics != 0)
            {
                tics--;

                if (tics <= 0 && !SetState(state.nextstate))
                {
                    tics = 0;
                    return;
                }
            }
            else
            {

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

            State st = Info.GetState(info.spawnState);

            this.state = st;
            this.tics = st.tics;
            this.sprite = st.sprite;
            this.frame = st.frame;

            transform.position = position;
        }

        public void OnRemove()
        {
            removedMobj = true;

            /* var spriteRenderer = GetComponentInChildren<NEP.DOOMLAB.Rendering.DoomSpriteRenderer>();
            Destroy(spriteRenderer);
            Destroy(gameObject); */
        }

        public void TakeDamage(float damage, Mobj inflictor)
        {
            if (health <= 0f)
            {
                return;
            }

            if (health - damage <= 0 && currentState != info.deathState)
            {
                SetState(info.deathState);
                flags ^= MobjFlags.MF_SHOOTABLE | MobjFlags.MF_CORPSE;

                inflictor.target = null;

                collider.size = new Vector3(collider.size.x, collider.size.y / 2, collider.size.z);

                if(info.deathSound != Sound.SoundType.sfx_None)
                {
                    SoundManager.Instance.PlaySound(info.deathSound, transform.position, false);
                }
            }
            else if (health - damage <= -16 && currentState != info.xDeathState)
            {
                StateNum deathType = info.xDeathState != StateNum.S_NULL ? info.xDeathState : info.deathState;
                SoundType soundType = info.xDeathState != StateNum.S_NULL ? SoundType.sfx_slop : info.deathSound;
                SetState(deathType);
                flags ^= MobjFlags.MF_SHOOTABLE | MobjFlags.MF_CORPSE;

                inflictor.target = null;

                collider.size = new Vector3(collider.size.x, collider.size.y / 2, collider.size.z);

                if (info.deathSound != Sound.SoundType.sfx_None)
                {
                    SoundManager.Instance.PlaySound(soundType, transform.position, false);
                }
            }
            else
            {
                health -= damage;

                SetState(info.painState);

                if (info.painSound != SoundType.sfx_None)
                {
                    SoundManager.Instance.PlaySound(info.painSound, transform.position, false);
                }
            }
        }
    }

}