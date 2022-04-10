using UnityEngine;
using System.Linq;

namespace NEP.BWDOOM.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class EnemyBehaviour : MonoBehaviour
    {
        public EnemyBehaviour(System.IntPtr ptr) : base(ptr) { }

        public MOBJ mObj;

        private MOBJ.DirType[] opposite = new MOBJ.DirType[]
        {
            MOBJ.DirType.DI_WEST, MOBJ.DirType.DI_SOUTHWEST, MOBJ.DirType.DI_SOUTH, MOBJ.DirType.DI_SOUTHEAST,
            MOBJ.DirType.DI_EAST, MOBJ.DirType.DI_NORTHEAST, MOBJ.DirType.DI_NORTH, MOBJ.DirType.DI_NORTHWEST, MOBJ.DirType.DI_NODIR
        };

        private MOBJ.DirType[] diags = new MOBJ.DirType[]
        {
            MOBJ.DirType.DI_NORTHWEST, MOBJ.DirType.DI_NORTHEAST, MOBJ.DirType.DI_SOUTHWEST, MOBJ.DirType.DI_SOUTHEAST
        };

        private MOBJ.DirType[] choices = new MOBJ.DirType[3];

        private void Awake()
        {
            mObj = GetComponent<MOBJ>();
        }

        private void Update()
        {
            mObj.rotation = Quaternion.AngleAxis(mObj.dirRotations[(int)mObj.moveDir], Vector3.up);
        }

        public void A_Look(MOBJ actor)
        {
            actor.threshold = 0;

            MOBJ target = actor.sensor.target;

            if (target != null)
            {
                actor.target = target;

                if ((actor.flags & MOBJFlags.MF_AMBUSH) != 0)
                {
                    A_SeeYou(actor);
                }
                else
                {
                    A_SeeYou(actor);
                }
            }

            if (actor.sensor.closestMOBJs.Count <= 0)
            {
                return;
            }
        }

        private void A_SeeYou(MOBJ actor)
        {
            actor.P_SetMobjState(actor, actor.info.seestate);
        }

        public bool P_CheckMeleeRange(MOBJ actor)
        {
            MOBJ target = actor.target;
            Vector3 targetPosition = target.transform.position;

            if (target == null)
            {
                return false;
            }

            if (Vector3.Distance(actor.position, targetPosition) >= 0.25f)
            {
                return false;
            }

            return true;
        }

        public void P_NewChaseDir(MOBJ actor)
        {
            if (actor.target == null)
            {
                throw new System.Exception("Called with no target.");
            }

            MOBJ.DirType oldDir = actor.moveDir;
            MOBJ.DirType turnAround = opposite[(int)oldDir];

            Vector3 targetPos = actor.target.transform.position;
            Vector3 actorPos = actor.transform.position;

            float deltaX = targetPos.x - actorPos.x;
            float deltaZ = targetPos.z - actorPos.z;

            if (deltaX > 30f)
            {
                choices[1] = MOBJ.DirType.DI_EAST;
            }
            else if (deltaX < -10f)
            {
                choices[1] = MOBJ.DirType.DI_WEST;
            }
            else
            {
                choices[1] = MOBJ.DirType.DI_NODIR;
            }

            if (deltaZ < -10f)
            {
                choices[2] = MOBJ.DirType.DI_SOUTH;
            }
            else if (deltaZ < 10f)
            {
                choices[2] = MOBJ.DirType.DI_NORTH;
            }
            else
            {
                choices[2] = MOBJ.DirType.DI_NODIR;
            }

            if (choices[1] != MOBJ.DirType.DI_NODIR && choices[2] != MOBJ.DirType.DI_NODIR)
            {
                float a = deltaZ <= 0f ? 1f : 0f;
                float b = deltaX >= 0f ? 1f : 0f;

                actor.moveDir = diags[(int)(a + b)];

                if (actor.moveDir != turnAround && actor.thingMovement.P_TryWalk(actor))
                {
                    return;
                }
            }

            // Try other directions.
            if (BWDOOM.Misc.DoomRNG.P_Random() > 200 || Mathf.Abs(deltaZ) > Mathf.Abs(deltaX))
            {
                MOBJ.DirType temp = choices[1];
                choices[1] = choices[2];
                choices[2] = temp;
            }

            if (choices[1] == turnAround)
            {
                choices[1] = MOBJ.DirType.DI_NODIR;
            }

            if (choices[2] == turnAround)
            {
                choices[2] = MOBJ.DirType.DI_NODIR;
            }

            if (choices[1] != MOBJ.DirType.DI_NODIR)
            {
                actor.moveDir = choices[1];

                if (actor.thingMovement.P_TryWalk(actor))
                {
                    // Moved forward or attacked
                    return;
                }
            }

            if (choices[2] != MOBJ.DirType.DI_NODIR)
            {
                actor.moveDir = choices[2];

                if (actor.thingMovement.P_TryWalk(actor))
                {
                    // Moved forward or attacked
                    return;
                }
            }

            if (oldDir != MOBJ.DirType.DI_NODIR)
            {
                actor.moveDir = oldDir;

                if (actor.thingMovement.P_TryWalk(actor))
                {
                    return;
                }
            }

            if ((Misc.DoomRNG.P_Random() & 1) != 0)
            {
                for (int dir = (int)MOBJ.DirType.DI_EAST; dir <= (int)MOBJ.DirType.DI_SOUTHEAST; dir++)
                {
                    if ((MOBJ.DirType)dir != turnAround)
                    {
                        actor.moveDir = (MOBJ.DirType)dir;

                        if (actor.thingMovement.P_TryWalk(actor))
                        {
                            return;
                        }
                    }
                }
            }
            else
            {
                for (int dir = (int)MOBJ.DirType.DI_SOUTHEAST; dir != (int)MOBJ.DirType.DI_EAST - 1; dir--)
                {
                    if ((MOBJ.DirType)dir != turnAround)
                    {
                        actor.moveDir = (MOBJ.DirType)dir;

                        if (actor.thingMovement.P_TryWalk(actor))
                        {
                            return;
                        }
                    }
                }
            }

            if (turnAround != MOBJ.DirType.DI_NODIR)
            {
                actor.moveDir = turnAround;

                if (actor.thingMovement.P_TryWalk(actor))
                {
                    return;
                }

            }

            actor.moveDir = MOBJ.DirType.DI_NODIR;
        }

        public void P_RadiusAttack(MOBJ spot, MOBJ source, int damage)
        {

        }

        public void A_Chase(MOBJ actor)
        {
            if (actor.reactiontime > 0)
            {
                actor.reactiontime--;
            }

            if (actor.threshold > 0)
            {
                if (actor.target == null || actor.target.health <= 0)
                {
                    actor.threshold = 0;
                }
                else
                {
                    actor.threshold--;
                }
            }

            // TODO:
            // implement the angle stuff

            if (actor.target == null || (actor.target.flags & MOBJFlags.MF_SHOOTABLE) == 0)
            {
                if (actor.sensor.target == null)
                {
                    return;
                }

                //actor.P_SetMobjState(actor, actor.info.spawnstate);

                return;
            }

            if ((actor.flags & MOBJFlags.MF_JUSTATTACKED) != 0)
            {
                actor.flags &= ~MOBJFlags.MF_JUSTATTACKED;

                // TODO:
                // add world parameters (nightmare, fast monsters, etc)

                return;
            }

            if (actor.info.missilestate != StateNum.S_NULL)
            {
                actor.P_SetMobjState(actor, actor.info.missilestate);
                actor.flags |= MOBJFlags.MF_JUSTATTACKED;

                A_NoMissile(actor);

                return;
            }
        }

        private void A_NoMissile(MOBJ actor)
        {
            if (actor.threshold == 0)
            {
                if (actor.sensor.closestMOBJs.Count > 0)
                {
                    return;
                }
            }

            if (--actor.moveCount < 0 || !actor.thingMovement.P_Move(actor))
            {
                P_NewChaseDir(actor);
            }

            if (actor.info.activesound != 0 && Misc.DoomRNG.P_Random() < 3)
            {
                //Play sound
            }
        }

        public void A_Pain(MOBJ actor)
        {
            if (actor.info.painsound != Sound.SFXEnum.sfx_None)
            {
                print("A_Pain");
                Sound.SFXManager.instance.S_StartSoundAtVolume(actor.transform.position, actor.info.painsound, false);
            }
        }

        public void A_Scream(MOBJ actor)
        {

        }

        public void A_TroopAttack(MOBJ actor)
        {
            if (actor.target == null)
            {
                return;
            }

            Main.mobjManager.P_SpawnMissile(actor, actor.target, MOBJType.MT_TROOPSHOT);
        }

        public void A_Explode(MOBJ actor)
        {
            // P_RadiusAttack(actor, actor.target, (128 / 10));
        }

        public void A_FaceTarget(MOBJ actor)
        {
            if (actor.target == null || actor.targetGameObject == null)
            {
                return;
            }

            actor.flags &= ~MOBJFlags.MF_AMBUSH;

            float dx = actor.target.position.x - actor.position.x;
            float dz = actor.target.position.z - actor.position.z;
            Quaternion lookRotation = Quaternion.LookRotation((Vector3.right * dx + Vector3.forward * dz).normalized, transform.up);
            actor.rotation.eulerAngles = lookRotation.eulerAngles;

            if (actor.targetGameObject != null)
            {
                float dgx = actor.targetGameObject.transform.position.x - actor.position.x;
                float dgz = actor.targetGameObject.transform.position.z - actor.position.z;
                Quaternion rot = Quaternion.LookRotation((Vector3.right * dx + Vector3.forward * dz).normalized, transform.up);
                actor.rotation.eulerAngles = rot.eulerAngles;
            }
        }
    }
}
