using UnityEngine;

namespace NEP.BWDOOM.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class ThingInteraction : MonoBehaviour
    {
        public ThingInteraction(System.IntPtr ptr) : base(ptr) { }

        public static void P_KillMobj(MOBJ source, MOBJ target)
        {
            target.flags &= ~(MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_FLOAT | MOBJFlags.MF_SKULLFLY);

            if (target.type == MOBJType.MT_SKULL)
            {
                target.flags &= ~MOBJFlags.MF_NOGRAVITY;
            }

            target.flags |= MOBJFlags.MF_CORPSE | MOBJFlags.MF_DROPOFF;
            // adjust height

            if (target.health < -target.info.spawnhealth && target.info.xdeathstate != 0)
            {
                target.P_SetMobjState(target, target.info.xdeathstate);
            }
            else
            {
                target.P_SetMobjState(target, target.info.deathstate);
            }

            target.tics -= 1;

            if (target.tics < 1)
            {
                target.tics = 1;
            }
        }

        public static void P_DamageMobj(MOBJ target, MOBJ inflictor, MOBJ source, int damage)
        {
            if ((target.flags & MOBJFlags.MF_SHOOTABLE) == 0)
            {
                return;
            }

            if (target.health <= 0)
            {
                return;
            }

            if ((target.flags & MOBJFlags.MF_SKULLFLY) != 0)
            {
                target.rb.velocity = Vector3.zero;
            }

            target.health -= damage;

            if (target.health <= 0)
            {
                P_KillMobj(source, target);
                return;
            }

            if ((target.flags & MOBJFlags.MF_SKULLFLY) == 0)
            {
                target.flags |= MOBJFlags.MF_JUSTHIT;

                if (target.info.painstate != StateNum.S_NULL)
                {
                    target.P_SetMobjState(target, target.info.painstate);
                }
            }

            target.reactiontime = 0;

            if ((target.threshold == 0 || target.type == MOBJType.MT_VILE) &&
                source != null &&
                source != target &&
                source.type != MOBJType.MT_VILE)
            {
                target.target = source;
                target.threshold = 8;

                if (target.state == Info.StateTable.states[(int)target.info.spawnstate] && target.info.seestate != StateNum.S_NULL)
                {
                    target.P_SetMobjState(target, target.info.seestate);
                }
            }
        }
    }
}
    