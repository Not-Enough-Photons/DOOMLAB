using UnityEngine;
using SLZ.Props;
using HarmonyLib;

using NEP.DOOMLAB.Entities;
using SLZ.Marrow.Warehouse;

[HarmonyPatch(typeof(SpawnGun), nameof(SpawnGun.OnFire))]
public static class SpawnGunPatch
{
    public static bool Prefix(SpawnGun __instance)
    {
        if(__instance._selectedMode == UtilityModes.REMOVER)
        {
            Mobj hitMobj = __instance._hitInfo.collider.GetComponent<Mobj>();

            if(hitMobj != null)
            {
                if (hitMobj == Mobj.player)
                {
                    return false;
                }

                MobjManager.Instance.RemoveMobj(hitMobj);

                return false;
            }

            return true;
        }

        Crate selectedCrate = __instance._selectedCrate;

        if(MobjManager.npcLookup.ContainsKey(selectedCrate.Title))
        {
            MobjManager.Instance.SpawnMobj(__instance.truePlacePosition, MobjManager.npcLookup[selectedCrate.Title]);
            return false;
        }

        return true;
    }
}