using StressLevelZero.Combat;

using NEP.BWDOOM.Entities;

using UnityEngine;

namespace NEP.BWDOOM.Patches
{
    public class GamePatches
    {
        [HarmonyLib.HarmonyPatch(typeof(Projectile))]
        [HarmonyLib.HarmonyPatch(nameof(Projectile.Awake))]
        public static class ProjectilePatch
        {
            public static void OnCollision(Projectile projectile, Collider collider, Vector3 world, Vector3 normal)
            {
                float projectileDamage = projectile.bulletObject.ammoVariables.AttackDamage;

                MOBJ hitM = collider.GetComponentInParent<MOBJ>();

                if(hitM == null)
                {
                    return;
                }

                int adjustedDamage = Mathf.RoundToInt(projectileDamage);

                ThingInteraction.P_DamageMobj(hitM, null, hitM, adjustedDamage);
            }

            public static void Prefix(Projectile __instance)
            {
                __instance.onCollision.AddListener(new System.Action<Collider, Vector3, Vector3>((collider, world, normal) => OnCollision(__instance, collider, world, normal)));
            }
        }
    }
}
