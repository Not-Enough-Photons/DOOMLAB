using UnityEngine;
using SLZ.Props;
using HarmonyLib;

using NEP.DOOMLAB.Entities;
using SLZ.Marrow.Warehouse;

[HarmonyPatch(typeof(SpawnGun), nameof(SpawnGun.OnFire))]
public static class SpawnGunPatch
{
    public static void Prefix(SpawnGun __instance)
    {
        Crate selectedCrate = __instance._selectedCrate;

        if(MobjManager.npcLookup.ContainsKey(selectedCrate.name))
        {
            MobjManager.Instance.SpawnMobj(__instance.truePlacePosition, MobjManager.npcLookup[selectedCrate.name]);
            return;
        }
    }
}