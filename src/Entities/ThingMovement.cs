using UnityEngine;

using NEP.BWDOOM.Entities;

namespace NEP.BWDOOM.Entities
{
    /// <summary>
    /// Movement logic for MOBJs
    /// </summary>
    /// https://github.com/sinshu/managed-doom/blob/master/ManagedDoom/src/Doom/World/ThingMovement.cs#L82
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class ThingMovement : MonoBehaviour
    {
        public ThingMovement(System.IntPtr ptr) : base(ptr) { }

        public MOBJ currentThing;
        public MOBJFlags currentFlags;
        public Vector3 currentPos;
        public bool floatOk;

        public float floatSpeed = 4f / 10f;

        public float maxMove = 3f; // Only allow a max velocity of 3 meters per second

        private void Start()
        {
            currentThing = GetComponent<MOBJ>();
            currentFlags = currentThing.flags;
        }

        private void Update()
        {
            currentPos = currentThing.position;
        }

        public bool P_CheckThing(MOBJ thing)
        {
            if ((thing.flags & (MOBJFlags.MF_SOLID | MOBJFlags.MF_SPECIAL | MOBJFlags.MF_SHOOTABLE)) == 0)
            {
                return true;
            }

            float blockDist = thing.radius + currentThing.radius;

            if (Mathf.Abs(thing.transform.position.x - currentPos.x) >= blockDist ||
               Mathf.Abs(thing.transform.position.z - currentPos.z) >= blockDist)
            {
                return true;
            }

            if (thing == currentThing)
            {
                return true;
            }

            if ((currentThing.flags & MOBJFlags.MF_SKULLFLY) != 0)
            {
                int damage = currentThing.info.damage;

                ThingInteraction.P_DamageMobj(thing, currentThing, currentThing, damage);

                currentThing.flags &= ~MOBJFlags.MF_SKULLFLY;
                currentThing.rb.velocity = Vector3.zero;

                currentThing.P_SetMobjState(currentThing, currentThing.info.spawnstate);

                return false;
            }

            return (thing.flags & MOBJFlags.MF_SOLID) == 0;
        }

        public bool P_CheckPosition(MOBJ thing, Vector3 position)
        {
            currentThing = thing;
            currentFlags = thing.flags;

            currentPos = position;

            if ((currentFlags & MOBJFlags.MF_NOCLIP) != 0)
            {
                return true;
            }

            Collider[] overlap = Physics.OverlapBox(position + transform.forward * 0.5f, thing.transform.localScale / 2f);

            if (overlap.Length >= 1)
            {
                return false; // Something in the way... yeah...
            }

            return true;
        }

        public bool P_TryMove(MOBJ thing, Vector3 tryV)
        {
            /*if(!P_CheckPosition(thing, tryV))
            {
                return false;
            }*/

            if (!((thing.flags &= MOBJFlags.MF_NOCLIP) != 0))
            {
                floatOk = true;
            }

            thing.transform.position += (Vector3.right * tryV.x + Vector3.forward * tryV.z) * Time.deltaTime;

            return true;
        }

        public bool P_TryWalk(MOBJ actor)
        {
            if (!P_Move(actor))
            {
                return false;
            }

            actor.moveCount = Misc.DoomRNG.P_Random() & 15;

            return true;
        }

        public bool P_Move(MOBJ thing)
        {
            if (thing.moveDir == MOBJ.DirType.DI_NODIR)
            {
                return false;
            }

            if (thing.moveDir >= MOBJ.DirType.NUMDIRS)
            {
                throw new System.Exception("Weird movedir!");
            }

            float tryX = (thing.position.x + thing.info.speed) * Time.deltaTime;
            float tryZ = (thing.position.z + thing.info.speed) * Time.deltaTime;

            bool tryOk = thing.thingMovement.P_TryMove(thing, new Vector3(tryX, 0f, tryZ));

            if (!tryOk)
            {

            }
            else
            {
                thing.flags &= ~MOBJFlags.MF_INFLOAT;
            }

            return true;
        }

        public void P_XYMovement(MOBJ thing)
        {
            if (thing.rb.velocity == Vector3.zero)
            {
                // The skull slammed into something
                if ((thing.flags & MOBJFlags.MF_SKULLFLY) != 0)
                {
                    thing.flags &= ~MOBJFlags.MF_SKULLFLY;
                    thing.rb.velocity = Vector3.zero;

                    thing.P_SetMobjState(thing, thing.info.spawnstate);
                }

                return;
            }

            thing.rb.velocity = Vector3.ClampMagnitude(thing.rb.velocity, maxMove);

            float moveX = thing.rb.velocity.x;
            float moveZ = thing.rb.velocity.z;

            float pTryX = thing.position.x + moveX;
            float pTryZ = thing.position.z + moveZ;

            if (!thing.thingMovement.P_TryMove(thing, new Vector3(pTryX, 0f, pTryZ)))
            {
                if ((thing.flags &= MOBJFlags.MF_MISSILE) != 0)
                {
                    // explode since we hit a wall
                }
            }
        }

        public void P_ZMovement(MOBJ thing)
        {
            if ((thing.flags & MOBJFlags.MF_FLOAT) != 0 && thing.target != null)
            {
                float dist = Vector3.Distance(thing.transform.position, thing.target.transform.position);
                float delta = (thing.target.transform.position.z + (thing.height * 2)) - thing.transform.position.z;

                if (delta < 0f && dist < -(delta * 3f))
                {
                    thing.transform.position -= Vector3.up * floatSpeed;
                }
                else if (delta > 0f && dist < (delta * 3f))
                {
                    thing.transform.position += Vector3.up * floatSpeed;
                }
            }
        }
    }
}
