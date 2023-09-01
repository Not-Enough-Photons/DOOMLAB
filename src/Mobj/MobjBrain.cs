using System;
using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Game;
using NEP.DOOMLAB.Sound;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace NEP.DOOMLAB.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class MobjBrain : MonoBehaviour
    {
        public MobjBrain(System.IntPtr ptr) : base(ptr) { }

        public Mobj mobj;

        private Mobj[] brainTargets = new Mobj[128];

        private float[] directions = new float[]
        {
            0,
            45,
            90,
            135,
            180,
            225,
            270,
            315
        };

        private Mobj.MoveDirection[] opposite = new Mobj.MoveDirection[]
        {
            Mobj.MoveDirection.WEST, Mobj.MoveDirection.SOUTHWEST, Mobj.MoveDirection.SOUTH, Mobj.MoveDirection.SOUTHEAST,
            Mobj.MoveDirection.EAST, Mobj.MoveDirection.NORTHEAST, Mobj.MoveDirection.NORTH, Mobj.MoveDirection.NORTHWEST, Mobj.MoveDirection.NODIR
        };

        private Mobj.MoveDirection[] diags = new Mobj.MoveDirection[]
        {
            Mobj.MoveDirection.NORTHWEST, Mobj.MoveDirection.NORTHEAST, Mobj.MoveDirection.SOUTHWEST, Mobj.MoveDirection.SOUTHEAST
        };

        private bool test_intersect;

        private void Awake()
        {
            mobj = GetComponent<Mobj>();
        }

        private void OnEnable()
        {
            SetMoveDirection(mobj.moveDirection);
        }

        public void SetMoveDirection(Mobj.MoveDirection direction)
        {
            if (mobj == null || direction == Mobj.MoveDirection.NODIR)
            {
                return;
            }

            mobj.moveDirection = direction;
            Quaternion rotation = Quaternion.AngleAxis(directions[(int)direction], Vector3.up);
            mobj.transform.rotation = rotation;
        }

        public bool Move()
        {
            if (mobj.moveDirection == Mobj.MoveDirection.NODIR)
            {
                print("No direction");
                return false;
            }

            if ((int)mobj.moveDirection >= 8)
            {
                print("Weird movedir");
                return false;

            }
            mobj.rigidbody.position += mobj.transform.forward * mobj.info.speed * Time.deltaTime;

            RaycastHit hit;
            bool tryOk = Physics.BoxCast(mobj.transform.position, mobj.collider.size / 2f, mobj.transform.forward, out hit);

            /*if (!tryOk || hit.collider.gameObject.layer == LayerMask.NameToLayer("Static") || !hit.collider.isTrigger)
            {
                print("Move blocked");
                return false;
            }*/

            return true;
        }

        public bool TryWalk()
        {
            if (!Move())
            {
                return false;
            }

            mobj.moveCount = DoomGame.RNG.P_Random() & 15;
            return true;
        }

        public void NewChaseDir()
        {
            float deltaX = mobj.target.transform.position.x - mobj.transform.position.x;
            float deltaZ = mobj.target.transform.position.z - mobj.transform.position.z;

            Mobj.MoveDirection[] possibleDirections = new Mobj.MoveDirection[3];

            if (deltaX > 1f)
            {
                possibleDirections[1] = Mobj.MoveDirection.EAST;
            }
            else if (deltaX < -1f)
            {
                possibleDirections[1] = Mobj.MoveDirection.WEST;
            }
            else
            {
                possibleDirections[1] = Mobj.MoveDirection.NODIR;
            }

            if (deltaZ > 1f)
            {
                possibleDirections[2] = Mobj.MoveDirection.NORTH;
            }
            else if (deltaZ < -1f)
            {
                possibleDirections[2] = Mobj.MoveDirection.SOUTH;
            }
            else
            {
                possibleDirections[2] = Mobj.MoveDirection.NODIR;
            }

            if (possibleDirections[1] != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(possibleDirections[1]);

                if (TryWalk())
                {
                    return;
                }
            }
            else if (possibleDirections[2] != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(possibleDirections[2]);

                if (TryWalk())
                {
                    return;
                }
            }
        }

        public bool CheckMeleeRange()
        {
            if(mobj.target == null)
            {
                return false;
            }

            if(Vector3.Distance(mobj.transform.position, mobj.target.position) >= 0.25f)
            {
                return false;
            }

            if (!CheckSight())
            {
                return false;
            }

            return true;
        }

        public bool CheckMissileRange()
        {
            if (!CheckSight())
            {
                return false;
            }

            float distance = Vector3.Distance(mobj.transform.position, mobj.target.transform.position);

            if(mobj.info.meleeState == StateNum.S_NULL)
            {
                distance -= 4f;
            }

            // too far away
            if(mobj.type == MobjType.MT_VILE && distance > 128f)
            {
                return false;
            }

            if(distance > 6.25f)
            {
                distance = 6.25f;
            }

            if(mobj.type == MobjType.MT_CYBORG && distance > 5f)
            {
                distance = 5f;
            }

            return true;
        }

        public bool CheckSight()
        {
            bool inView = mobj.target != null && Physics.Raycast(transform.position, transform.position + mobj.target.transform.position);
            return inView;
        }

        public bool FindPlayer()
        {
            if(mobj.target == null)
            {
                return false;
            }

            Vector3 directionToTarget = mobj.target.position - mobj.transform.position;
            float angle = Vector3.Angle(directionToTarget, mobj.transform.forward);

            if(angle >= 180f * 0.5f)
            {
                return false;
            }

            if (!CheckSight())
            {
                return false;
            }

            return true;
        }

        public void A_Look()
        {
            if (!FindPlayer())
            {
                return;
            }

            if (mobj.target != null && mobj.flags.HasFlag(MobjFlags.MF_SHOOTABLE))
            {
                A_SeeYou();
            }
        }

        public void A_SeeYou()
        {
            if (mobj.info.seeSound != Sound.SoundType.sfx_None)
            {
                SoundManager.Instance.PlaySound(mobj.info.seeSound, mobj.transform.position, true);
            }

            mobj.SetState(mobj.info.seeState);
        }

        public void A_Chase()
        {
            if (mobj.target == null)
            {
                return;
            }

            if (mobj.reactionTime != 0)
            {
                mobj.reactionTime--;
            }

            if (mobj.threshold != 0)
            {
                if (mobj.target != null && mobj.health <= 0)
                {
                    mobj.threshold = 0;
                }
                else
                {
                    mobj.threshold--;
                }
            }

            if (mobj.target == null || !mobj.target.flags.HasFlag(MobjFlags.MF_SHOOTABLE))
            {
                mobj.SetState(mobj.info.spawnState);
                return;
            }

            if (mobj.flags.HasFlag(MobjFlags.MF_JUSTATTACKED))
            {
                mobj.flags ^= MobjFlags.MF_JUSTATTACKED;
                NewChaseDir();
                return;
            }

            if (mobj.info.meleeState != StateNum.S_NULL && CheckMeleeRange())
            {
                if (mobj.info.attackSound != SoundType.sfx_None)
                {
                    SoundManager.Instance.PlaySound(mobj.info.attackSound, mobj.transform.position, false);
                }

                mobj.SetState(mobj.info.meleeState);
                return;
            }

            if (mobj.info.missileState != StateNum.S_NULL)
            {
                if (mobj.moveCount != 0)
                {
                    mobj.moveCount--;
                    A_NoMissile();
                    return;
                }

                if (!CheckMissileRange())
                {
                    A_NoMissile();
                    return;
                }

                mobj.SetState(mobj.info.missileState);
                mobj.flags ^= MobjFlags.MF_JUSTATTACKED;
                return;
            }
        }

        public void A_NoMissile()
        {
            if (mobj.threshold == 0 && !CheckSight())
            {
                if (FindPlayer())
                {
                    return;
                }
            }

            if (mobj.moveCount-- < 0 || !Move())
            {
                NewChaseDir();
            }

            if (mobj.info.activeSound != SoundType.sfx_None && DoomGame.RNG.P_Random() < 3)
            {
                SoundManager.Instance.PlaySound(mobj.info.activeSound, mobj.transform.position, false);
            }
        }

        public void A_FaceTarget()
        {
            if (mobj.target == null)
            {
                return;
            }

            Quaternion lookAt = Quaternion.LookRotation(mobj.target.transform.position - mobj.transform.position, Vector3.up);
            mobj.transform.rotation = Quaternion.Euler(Vector3.up * lookAt.eulerAngles.y);
        }

        public void A_TroopAttack()
        {
            if (mobj.target == null)
            {
                return;
            }

            A_FaceTarget();

            MobjManager.Instance.SpawnMissile(mobj, mobj.target, Data.MobjType.MT_TROOPSHOT);
        }

        public void A_PosAttack()
        {
            if(mobj.target == null)
            {
                return;
            }

            A_FaceTarget();
            float randomAngle = (DoomGame.RNG.P_Random() - DoomGame.RNG.P_Random() & 20) / 10f;
            float damage = ((DoomGame.RNG.P_Random() % 5) + 1) * 3;
            RaycastHit hit;
            
            if(Physics.Raycast(mobj.transform.position, mobj.target.position, out hit))
            {
                if (mobj.target.playerHealth)
                {
                    mobj.target.playerHealth.TAKEDAMAGE(damage / 10f);
                }
            }
        }

        public void A_CyberAttack()
        {
            if (mobj.target == null)
            {
                return;
            }

            A_FaceTarget();

            MobjManager.Instance.SpawnMissile(mobj, mobj.target, Data.MobjType.MT_ROCKET);
        }

        public void A_Hoof()
        {
            SoundManager.Instance.PlaySound(SoundType.sfx_hoof, mobj.transform.position, false);
            A_Chase();
        }

        public void A_Scream()
        {
            SoundType sound;

            switch (mobj.info.deathSound)
            {
                case 0:
                    return;

                case SoundType.sfx_podth1:
                case SoundType.sfx_podth2:
                case SoundType.sfx_podth3:
                    sound = SoundType.sfx_podth1 + DoomGame.RNG.P_Random() % 3;
                    break;

                case SoundType.sfx_bgdth1:
                case SoundType.sfx_bgdth2:
                    sound = SoundType.sfx_bgdth1 + DoomGame.RNG.P_Random() % 2;
                    break;

                default:
                    sound = mobj.info.deathSound;
                    break;
            }

            // Check for bosses.
            if (mobj.type == MobjType.MT_SPIDER || mobj.type == MobjType.MT_CYBORG)
            {
                // full volume
                SoundManager.Instance.PlaySound(sound, UnityEngine.Vector3.zero, true);
            }
            else
            {
                SoundManager.Instance.PlaySound(sound, mobj.transform.position, false);
            }
        }

        public void A_Pain()
        {
            if (mobj.info.painSound != SoundType.sfx_None)
            {
                SoundManager.Instance.PlaySound(mobj.info.painSound, mobj.transform.position, false);
            }
        }

        public void A_XScream()
        {
            SoundManager.Instance.PlaySound(SoundType.sfx_slop, mobj.transform.position, false);
        }

        public void A_Fall()
        {
            mobj.flags &= ~MobjFlags.MF_SOLID;
        }

        public void A_BrainAwake()
        {
            // find all the target spots
            int numbraintargets = 0;
            int braintargeton = 0;

            Mobj[] mobjs = GameObject.FindObjectsOfType<Mobj>();

            if(mobjs.Length == 0)
            {
                return;
            }

            foreach(var mobj in mobjs)
            {
                if(mobj.type == MobjType.MT_BOSSTARGET)
                {
                    brainTargets[numbraintargets++] = mobj;
                }
            }

            SoundManager.Instance.PlaySound(SoundType.sfx_bossit, Vector3.zero, true);
        }
    }
}
    