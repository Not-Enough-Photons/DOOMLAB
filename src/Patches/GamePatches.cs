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

                MelonLoader.MelonLogger.Msg(collider.name);

                MOBJ hitM = collider.GetComponent<MOBJ>();
                    ThingInteraction.P_DamageMobj(hitM, hitM, hitM, 1);
            }

            public static void Postfix(Projectile __instance)
            {
                __instance.onCollision.AddListener(new System.Action<Collider, Vector3, Vector3>((collider, world, normal) => OnCollision(__instance, collider, world, normal)));
            }
        }
    }
}
