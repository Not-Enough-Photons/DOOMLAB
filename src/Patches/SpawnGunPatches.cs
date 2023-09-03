using UnityEngine;
using SLZ.Props;
using HarmonyLib;

using NEP.DOOMLAB.Entities;
using SLZ.Marrow.Warehouse;
using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Sound;

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
            MobjType mobjType = MobjManager.npcLookup[selectedCrate.Title];
            MobjInfo mobjInfo = Info.MobjInfos[(int)mobjType];

            Vector3 truePlacePosition = __instance.truePlacePosition;
            Vector3 placePosition = new Vector3(truePlacePosition.x, truePlacePosition.y + mobjInfo.height / 32f, truePlacePosition.z);

            var mobj = MobjManager.Instance.SpawnMobj(placePosition, MobjManager.npcLookup[selectedCrate.Title]);

            MobjManager.Instance.SpawnMobj(placePosition, MobjType.MT_TFOG);
            SoundManager.Instance.PlaySound(SoundType.sfx_telept, mobj.transform.position, false);

            return false;
        }

        return true;
    }
}