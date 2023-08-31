using NEP.DOOMLAB.Entities;
using SLZ.AI;
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

                if(hitMobj)
                {
                    hitMobj.TakeDamage(__instance._data.damageMultiplier * 1f, __instance._proxy.chestTran.GetComponent<Mobj>());

                    if (!hitMobj.flags.HasFlag(MobjFlags.MF_NOBLOOD))
                    {
                        MobjManager.Instance.SpawnMobj(world, Data.MobjType.MT_BLOOD);
                    }
                }
            }));
        }
    }
}
