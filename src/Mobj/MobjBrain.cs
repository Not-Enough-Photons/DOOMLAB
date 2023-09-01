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
            if(mobj.moveDirection == Mobj.MoveDirection.NODIR)
            {
                return false;
            }

            if((int)mobj.moveDirection >= 8)
            {
                return false;
            }

            RaycastHit hit;
            bool tryOk = Physics.BoxCast(mobj.transform.position, mobj.collider.size, mobj.transform.forward, out hit);

            if (!tryOk || hit.collider.gameObject.layer == LayerMask.NameToLayer("Static") || !hit.collider.isTrigger)
            {
                return false;
            }

            float tryX = (mobj.transform.position.x * mobj.info.speed);
            float tryZ = (mobj.transform.position.z * mobj.info.speed);

            mobj.rigidbody.AddForce(mobj.transform.right * tryX + mobj.transform.forward * tryZ, ForceMode.Force);
            mobj.rigidbody.velocity = Vector3.ClampMagnitude(mobj.rigidbody.velocity, mobj.info.speed / 32f);

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
            var oldDirection = mobj.moveDirection;
            var turnAround = opposite[(int)oldDirection];
            var forwardDirections = new Mobj.MoveDirection[3];
            var triedDirection = Mobj.MoveDirection.NODIR;

            float dx = mobj.target.transform.position.x - mobj.transform.position.x;
            float dz = mobj.target.transform.position.z - mobj.transform.position.z;

            // Too far right, so go their way
            if (dx > 1.5)
            {
                forwardDirections[1] = Mobj.MoveDirection.EAST;
            }
            else if (dx < -1.5) // Too far left, go their way
            {
                forwardDirections[1] = Mobj.MoveDirection.WEST;
            }
            else // That route is boned
            {
                forwardDirections[1] = Mobj.MoveDirection.NODIR;
            }

            if (dz > 1.5) // Too behind, go south
            {
                forwardDirections[2] = Mobj.MoveDirection.SOUTH;
            }
            else if (dz < -1.5) // Too ahead, go north
            {
                forwardDirections[2] = Mobj.MoveDirection.NORTH;
            }
            else // That route is boned
            {
                forwardDirections[2] = Mobj.MoveDirection.NODIR;
            }

            // try direct route
            if (forwardDirections[1] != Mobj.MoveDirection.NODIR
            && forwardDirections[2] != Mobj.MoveDirection.NODIR)
            {
                int behind = dz < 0 ? 1 : 0;
                int left = dx > 0 ? 1 : 0;
                SetMoveDirection(diags[behind + left]);

                if (mobj.moveDirection != turnAround && TryWalk())
                {
                    return;
                }
            }

            if (DoomGame.RNG.P_Random() > 200 || Mathf.Abs(dz) > Mathf.Abs(dx))
            {
                // Swap directions
                triedDirection = forwardDirections[1];
                forwardDirections[1] = forwardDirections[2];
                forwardDirections[2] = triedDirection;
            }

            if (forwardDirections[1] == turnAround)
            {
                forwardDirections[1] = Mobj.MoveDirection.NODIR;
            }

            if (forwardDirections[2] == turnAround)
            {
                forwardDirections[2] = Mobj.MoveDirection.NODIR;
            }

            if (forwardDirections[1] != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(forwardDirections[1]);

                if (TryWalk())
                {
                    // move forward or attacked
                    return;
                }
            }

            if (forwardDirections[2] != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(forwardDirections[2]);

                if (TryWalk())
                {
                    // move forward or attacked
                    return;
                }
            }

            // no direct path to player, try another direction
            if (oldDirection != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(oldDirection);

                if (TryWalk())
                {
                    return;
                }
            }

            if((DoomGame.RNG.P_Random() & 1) != 0)
            {
                for (triedDirection = Mobj.MoveDirection.EAST;
                triedDirection != Mobj.MoveDirection.NODIR;
                triedDirection++)
                {
                    if (triedDirection != turnAround)
                    {
                        SetMoveDirection(triedDirection);

                        if (TryWalk())
                        {
                            return;
                        }
                    }
                }
            }
            else
            {
                for (triedDirection = Mobj.MoveDirection.SOUTHEAST;
                triedDirection != (Mobj.MoveDirection.EAST - 1);
                triedDirection--)
                {
                    if (triedDirection != turnAround)
                    {
                        SetMoveDirection(triedDirection);

                        if (TryWalk())
                        {
                            return;
                        }
                    }
                }
            }
            

            if (turnAround != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(turnAround);

                if (TryWalk())
                {
                    return;
                }
            }

            // you can't move! LOL!
            SetMoveDirection(Mobj.MoveDirection.NODIR);
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
            MelonLoader.MelonLogger.Msg("In view: " + inView);
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
                switch (mobj.type)
                {
                    case MobjType.MT_CYBORG:
                        SoundManager.Instance.PlaySound(mobj.info.seeSound, mobj.transform.position, true);
                        break;
                }
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

            if(mobj.threshold != 0)
            {
                if(mobj.target != null && mobj.health <= 0)
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
                mobj.flags &= ~MobjFlags.MF_JUSTATTACKED;
                NewChaseDir();
                MelonLoader.MelonLogger.Msg("Just attacked!");
                return;
            }

            if(mobj.info.meleeState != StateNum.S_NULL && CheckMeleeRange())
            {
                if(mobj.info.attackSound != SoundType.sfx_None)
                {
                    SoundManager.Instance.PlaySound(mobj.info.attackSound, mobj.transform.position, false);
                }

                mobj.SetState(mobj.info.meleeState);
                MelonLoader.MelonLogger.Msg("Close to target, use melee attack");
                return;
            }

            if(mobj.info.missileState != StateNum.S_NULL)
            {
                if (mobj.moveCount != 0)
                {
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

        public void A_CyberAttack()
        {
            if (mobj.target == null)
            {
                return;
            }

            A_FaceTarget();

            MobjManager.Instance.SpawnMissile(mobj, mobj.target, Data.MobjType.MT_ROCKET);
        }
    }
}
    