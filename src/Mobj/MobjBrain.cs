using System;
using System.Collections.Generic;

using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Game;
using NEP.DOOMLAB.Sound;

using UnityEngine;

namespace NEP.DOOMLAB.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class MobjBrain : MonoBehaviour
    {
        public MobjBrain(System.IntPtr ptr) : base(ptr) { }

        public Mobj mobj;

        private List<Mobj> listBrainTargets;

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
           Mobj.MoveDirection.SOUTHEAST, Mobj.MoveDirection.NORTHEAST, Mobj.MoveDirection.SOUTHWEST, Mobj.MoveDirection.NORTHWEST 
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
            if(mobj.target == null)
            {
                return;
            }

            Mobj.MoveDirection oldDir = mobj.moveDirection;
            Mobj.MoveDirection turnAround = opposite[(int)oldDir];
            Mobj.MoveDirection tempDir;

            float deltaX = mobj.target.transform.position.x - mobj.transform.position.x;
            float deltaZ = mobj.target.transform.position.z - mobj.transform.position.z;

            Mobj.MoveDirection[] possibleDirections = new Mobj.MoveDirection[2];

            if (deltaX > 0.5f)
            {
                possibleDirections[0] = Mobj.MoveDirection.NORTH;
            }
            else if (deltaX < -0.5f)
            {
                possibleDirections[0] = Mobj.MoveDirection.SOUTH;
            }
            else
            {
                possibleDirections[0] = Mobj.MoveDirection.NODIR;
            }

            if (deltaZ > 0.5f)
            {
                possibleDirections[1] = Mobj.MoveDirection.EAST;
            }
            else if (deltaZ < -0.5f)
            {
                possibleDirections[1] = Mobj.MoveDirection.WEST;
            }
            else
            {
                possibleDirections[1] = Mobj.MoveDirection.NODIR;
            }

            // try a diagonal/ordinal route
            // possible choices: north-east
            //                   north-west
            //                   south-east
            //                   south-west
            if (possibleDirections[0] != Mobj.MoveDirection.NODIR && possibleDirections[1] != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(diags[(deltaZ < 0 ? 1 : 0) * 2 + (deltaX > 0 ? 1 : 0)]);

                if(mobj.moveDirection != turnAround && TryWalk())
                {
                    return;
                }
            }

            if(DoomGame.RNG.P_Random() < 200 || Mathf.Abs(deltaZ) > Mathf.Abs(deltaX))
            {
                tempDir = possibleDirections[0];
                possibleDirections[0] = possibleDirections[1];
                possibleDirections[1] = tempDir;
            }

            if(possibleDirections[0] == turnAround)
            {
                possibleDirections[0] = Mobj.MoveDirection.NODIR;
            }

            if(possibleDirections[1] == turnAround)
            {
                possibleDirections[1] = Mobj.MoveDirection.NODIR;
            }

            if(possibleDirections[0] != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(possibleDirections[0]);

                if(TryWalk())
                {
                    return;
                }
            }

            if(possibleDirections[1] != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(possibleDirections[1]);

                if(TryWalk())
                {
                    return;
                }
            }

            if(oldDir != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(oldDir);

                if(TryWalk())
                {
                    return;
                }
            }

            if((DoomGame.RNG.P_Random() & 1) != 0)
            {
                for(tempDir = Mobj.MoveDirection.WEST;
                    tempDir <= Mobj.MoveDirection.SOUTHWEST;
                    tempDir++)
                    {
                        if(tempDir != turnAround)
                        {
                            SetMoveDirection(tempDir);

                            if(TryWalk())
                            {
                                return;
                            }
                        }
                    }
            }
            else
            {
                for(tempDir = Mobj.MoveDirection.SOUTHWEST;
                    tempDir != Mobj.MoveDirection.WEST - 1;
                    tempDir--)
                    {
                        if(tempDir != turnAround)
                        {
                            SetMoveDirection(tempDir);

                            if(TryWalk())
                            {
                                return;
                            }
                        }
                    }
            }

            if(turnAround != Mobj.MoveDirection.NODIR)
            {
                SetMoveDirection(turnAround);
                
                if (TryWalk())
                {
                    return;
                }
            }

            SetMoveDirection(Mobj.MoveDirection.NODIR);
        }

        public bool CheckMeleeRange()
        {
            if(mobj.target == null)
            {
                return false;
            }

            if(Vector3.Distance(mobj.transform.position, mobj.target.transform.position) > 0.5f)
            {
                return false;
            }

            return true;
        }

        public bool CheckMissileRange()
        {
            if (!CheckSight())
            {
                MelonLoader.MelonLogger.Msg("Not in sight");
                return false;
            }

            MelonLoader.MelonLogger.Msg("In sight");

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
            if(mobj.target == null)
            {
                return false;
            }

            return true;
        }

        public bool FindPlayer()
        {
            if(mobj.target == null)
            {
                return false;
            }

            Vector3 directionToTarget = mobj.target.position - mobj.transform.position;
            float angle = Vector3.Angle(directionToTarget, mobj.transform.forward);

            if(angle < 90f * 0.5f)
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
            SoundType sound;

            switch(mobj.info.seeSound)
            {
                case SoundType.sfx_posit1:
                case SoundType.sfx_posit2:
                case SoundType.sfx_posit3:
                    sound = SoundType.sfx_posit1 + DoomGame.RNG.P_Random() % 3;
                    break;
                
                case SoundType.sfx_bgsit1:
                case SoundType.sfx_bgsit2:
                    sound = SoundType.sfx_bgsit1 + DoomGame.RNG.P_Random() % 2;
                    break;

                default:
                    sound = mobj.info.seeSound;
                    break;
            }

            if(mobj.type == MobjType.MT_SPIDER || mobj.type == MobjType.MT_CYBORG)
            {
                SoundManager.Instance.PlaySound(sound, Vector3.zero, true);
            }
            else
            {
                SoundManager.Instance.PlaySound(sound, mobj.transform.position, false);
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
                if (mobj.target == Mobj.player)
                {
                    mobj.target.playerHealth.TAKEDAMAGE(damage / 10f);
                }
            }

            SoundManager.Instance.PlaySound(SoundType.sfx_pistol, mobj.transform.position, false);
        }

        public void A_CPosAttack()
        {
            if(mobj.target == null)
            {
                return;
            }

            SoundManager.Instance.PlaySound(SoundType.sfx_shotgn, mobj.transform.position, false);
            A_FaceTarget();

            float damage = ((DoomGame.RNG.P_Random() % 5) + 1) * 3;
        }

        public void A_CPosRefire()
        {
            A_FaceTarget();

            if(DoomGame.RNG.P_Random() < 40)
            {
                return;
            }

            if(mobj.target == null || mobj.target.health <= 0 || !CheckSight())
            {
                mobj.SetState(mobj.info.seeState);
            }
        }

        public void A_SpidRefire()
        {
            A_FaceTarget();

            if(DoomGame.RNG.P_Random() < 10)
            {
                return;
            }

            if(mobj.target == null || mobj.target.health == 0 || !CheckSight())
            {
                mobj.SetState(mobj.info.seeState);
            }
        }

        public void A_BspiAttack()
        {
            if (mobj.target == null)
            {
                return;
            }

            A_FaceTarget();

            // launch a missile
            MobjManager.Instance.SpawnMissile(mobj, mobj.target, MobjType.MT_ARACHPLAZ);
        }

        public void A_SargAttack()
        {
            if(mobj.target == null)
            {
                return;
            }

            A_FaceTarget();

            if(CheckMeleeRange())
            {
                
            }
        }

        public void A_SkelWhoosh()
        {
            if(mobj.target == null)
            {
                return;
            }

            A_FaceTarget();
            SoundManager.Instance.PlaySound(SoundType.sfx_skeswg, mobj.transform.position, false);
        }

        public void A_SkelFist()
        {
            if(mobj.target == null)
            {
                return;
            }

            A_FaceTarget();

            if(CheckMeleeRange())
            {
                SoundManager.Instance.PlaySound(SoundType.sfx_skepch, mobj.transform.position, false);
                // damage
            }
        }

        public void A_PainAttack()
        {
            
        }

        public void A_SkullAttack()
        {
            if(mobj.target == null)
            {
                return;
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

        public void A_HeadAttack()
        {
            if (mobj.target == null)
            {
                return;
            }

            A_FaceTarget();
            if(CheckMeleeRange())
            {
                float damage = (DoomGame.RNG.P_Random()%6+1)*10;
                mobj.target.TakeDamage(damage, mobj);
                return;
            }

            MobjManager.Instance.SpawnMissile(mobj, mobj.target, MobjType.MT_HEADSHOT);
        }

        public void A_BruisAttack()
        {
            if (mobj.target == null)
            {
                return;
            }

            if (CheckMeleeRange())
            {
                SoundManager.Instance.PlaySound(SoundType.sfx_claw, mobj.transform.position, false);
                float damage = (DoomGame.RNG.P_Random() % 8 + 1) * 10;
                mobj.target.TakeDamage(damage, mobj);
                return;
            }

            // launch a missile
            MobjManager.Instance.SpawnMissile(mobj, mobj.target, MobjType.MT_BRUISERSHOT);
        }

        public void A_Hoof()
        {
            SoundManager.Instance.PlaySound(SoundType.sfx_hoof, mobj.transform.position, false);
            A_Chase();
        }

        public void A_Metal()
        {
            SoundManager.Instance.PlaySound(SoundType.sfx_metal, mobj.transform.position, false);
            A_Chase();
        }

        public void A_BabyMetal()
        {
            SoundManager.Instance.PlaySound(SoundType.sfx_bspwlk, mobj.transform.position, false);
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
            SoundManager.Instance.PlaySound(SoundType.sfx_bossit, Vector3.zero, true);

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
                    listBrainTargets.Add(mobj);
                }
            }

        }

        public void A_BrainPain()
        {
            SoundManager.Instance.PlaySound(SoundType.sfx_bospn, Vector3.zero, true);
        }

        public void A_BrainScream()
        {
            SoundManager.Instance.PlaySound(SoundType.sfx_bosdth, Vector3.zero, true);
        }
    }
}
    