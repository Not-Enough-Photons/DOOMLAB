using NEP.DOOMLAB.Entities;
using NEP.DOOMLAB.Game;
using NEP.DOOMLAB.Sound;
using SLZ.Combat;
using SLZ.SFX;
using UnityEngine;

namespace NEP.DOOMLAB.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(Projectile))]
    [HarmonyLib.HarmonyPatch(nameof(Projectile.Awake))]
    public static class ProjectilePatch
    {
        public static void Postfix(Projectile __instance)
        {
            __instance.onCollision.AddListener(new System.Action<Collider, Vector3, Vector3>((hitCol, world, normal) =>
            {
                Mobj hitMobj = hitCol.GetComponent<Mobj>();

                if (hitMobj == null)
                {
                    return;
                }

                if (!hitMobj.flags.HasFlag(MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE))
                {
                    return;
                }

                if (hitMobj.flags.HasFlag(MobjFlags.MF_CORPSE))
                {
                    return;
                }

                MobjInteraction.DamageMobj(hitMobj, Mobj.player, Mobj.player, __instance._data.damageMultiplier * (DoomGame.RNG.P_Random() & 3) * 6f);

                if (!hitMobj.flags.HasFlag(MobjFlags.MF_NOBLOOD))
                {
                    MobjManager.Instance.SpawnMobj(world, Data.MobjType.MT_BLOOD);
                }
                else if(hitMobj.flags.HasFlag(MobjFlags.MF_NOBLOOD))
                {
                    MobjManager.Instance.SpawnMobj(world, Data.MobjType.MT_PUFF);
                }
            }));
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(HandSFX))]
    [HarmonyLib.HarmonyPatch(nameof(HandSFX.PunchAttack))]
    public static class PunchPatch
    {
        public static void Postfix(Collision c, float impulse, float relVelSqr)
        {
            Mobj hitMobj = c.collider.GetComponent<Mobj>();

            if(hitMobj != null)
            {
                if(!hitMobj.flags.HasFlag(MobjFlags.MF_NOBLOOD))
                {
                    MobjManager.Instance.SpawnMobj(c.contacts[0].point, Data.MobjType.MT_BLOOD);
                }
                else
                {
                    MobjManager.Instance.SpawnMobj(c.contacts[0].point, Data.MobjType.MT_PUFF);
                }

                hitMobj.rigidbody.AddForce(c.impactForceSum, ForceMode.Impulse);
                MobjInteraction.DamageMobj(hitMobj, Mobj.player, Mobj.player, impulse);
                SoundManager.Instance.PlaySound(SoundType.sfx_punch, c.contacts[0].point, false);
            }
        }
    }
}
