using System;
using NEP.DOOMLAB.Data;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace NEP.DOOMLAB.Game
{
    public class MobjBrain : MonoBehaviour
    {
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
            return test_intersect = Physics.BoxCast(mobj.transform.position, mobj.collider.size, mobj.transform.forward);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(mobj.transform.position + mobj.transform.forward, mobj.collider.size);
            Gizmos.color = test_intersect ? Color.red : Color.green;
        }

        public bool TryMove()
        {
            if (!Move())
            {
                return false;
            }

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

                if (mobj.moveDirection != turnAround && TryMove())
                {
                    return;
                }
            }

            // the random state stuff isn't implemented yet
            // so i'm just gonna wing it
            if (Mathf.Abs(dz) > Mathf.Abs(dx))
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

                if (TryMove())
                {
                    // move forward or attacked
                    return;
                }
            }

            if (forwardDirections[2] != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(forwardDirections[2]);

                if (TryMove())
                {
                    // move forward or attacked
                    return;
                }
            }

            // no direct path to player, try another direction
            if (oldDirection != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(oldDirection);

                if (TryMove())
                {
                    return;
                }
            }

            // no randomness at the moment
            // if(P_Random() & 1)

            // randomly determine direction of search

            for (triedDirection = Mobj.MoveDirection.EAST;
                triedDirection != Mobj.MoveDirection.NODIR;
                triedDirection++)
            {
                if (triedDirection != turnAround)
                {
                    SetMoveDirection(triedDirection);

                    if (TryMove())
                    {
                        return;
                    }
                }
            }

            if (turnAround != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(turnAround);

                if (TryMove())
                {
                    return;
                }
            }

            // you can't move! LOL!
            SetMoveDirection(Mobj.MoveDirection.NODIR);
        }

        public void A_Look()
        {
            Move();

            Action seeyou = delegate
            {
                if (mobj.info.seeSound != Sound.SoundType.sfx_None)
                {
                    // do sound stuff
                }

                mobj.SetState(mobj.info.seeState);
            };

            mobj.threshold = 0;
            // use dummy target for now

            if (mobj.target != null && mobj.flags.HasFlag(MobjFlags.MF_SHOOTABLE))
            {
                seeyou();
            }
        }

        public void A_Chase()
        {
            if (mobj.target == null)
            {
                return;
            }

            NavMeshPath path = new NavMeshPath();
            NavMesh.CalculatePath(mobj.transform.position, mobj.target.position, 0, path);

            return;

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

            if(mobj.info.meleeState != StateNum.S_NULL && Vector3.Distance(mobj.transform.position, mobj.target.position) < 5f)
            {
                mobj.SetState(mobj.info.meleeState);
            }

            if(mobj.info.missileState != StateNum.S_NULL && Vector3.Distance(mobj.transform.position, mobj.target.position) < 50)
            {
                mobj.SetState(mobj.info.missileState);
            }

            // this is really weird because i guess its supposed to
            // reorient the actor? but there was some cursed bit shifting
            if (mobj.moveDirection != Mobj.MoveDirection.NODIR)
            {
                // Quaternion target = Quaternion.Euler(mobj.transform.up * directions[7]);
                // angleDelta = target.eulerAngles.y - directions[(int)mobj.moveDirection];

                // if (angleDelta > 0)
                // {
                //     mobj.transform.rotation = Quaternion.AngleAxis(-22.5f, Vector3.up);
                // }
                // else if(angleDelta < 0)
                // {
                //     mobj.transform.rotation = Quaternion.AngleAxis(22.5f, Vector3.up);
                // }
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
