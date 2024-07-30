using MelonLoader;

using UnityEngine;

using Il2CppSLZ.Marrow;

using NEP.DOOMLAB.Entities;

namespace NEP.DOOMLAB.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(Gun), nameof(Gun.OnFire))]
    public static class GunPatches
    {
        public static void Postfix(Gun __instance)
        {
            PropagateSound(__instance);
        }

        public static void PropagateSound(Gun gun)
        {
            LayerMask mask = ~LayerMask.NameToLayer("EnemyColliders");
            var colliders = Physics.OverlapBox(
                gun.firePointTransform.position, 
                Vector3.one * 16f, 
                Quaternion.identity, 
                mask, 
                QueryTriggerInteraction.Ignore);

            for(int i = 0; i < colliders.Length; i++)
            {
                var gameObject = colliders[i].gameObject;
                int instanceId = gameObject.GetInstanceID();
                var lookup = Mobj.ComponentCache.CacheLookup;

                if(!lookup.ContainsKey(instanceId))
                {
                    continue;
                }

                Mobj heardMobj = lookup[instanceId];

                if(heardMobj == Mobj.player)
                {
                    continue;
                }

                if(heardMobj.target != null)
                {
                    continue;
                }

                heardMobj.target = Mobj.player;
                heardMobj.brain.A_SeeYou();
            }
        }
    }
}