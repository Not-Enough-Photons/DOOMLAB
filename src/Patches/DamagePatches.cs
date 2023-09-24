using NEP.DOOMLAB.Entities;
using NEP.DOOMLAB.Game;

using SLZ.Combat;

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
}
