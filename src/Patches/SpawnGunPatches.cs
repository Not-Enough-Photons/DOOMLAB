using UnityEngine;
using HarmonyLib;

using SLZ.Props;
using SLZ.Marrow.Warehouse;

using NEP.DOOMLAB.Entities;
using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Sound;

namespace NEP.DOOMLAB.Patches
{
    [HarmonyPatch(typeof(SpawnGun), nameof(SpawnGun.OnFire))]
    public static class SpawnGunPatch
    {
        public static bool Prefix(SpawnGun __instance)
        {
            if (__instance._selectedMode == UtilityModes.REMOVER)
            {
                Mobj hitMobj = __instance._hitInfo.collider.GetComponent<Mobj>();

                if (hitMobj != null)
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

            if (selectedCrate == null)
            {
                return false;
            }

            if (MobjLookup.npcLookup.ContainsKey(selectedCrate.Title))
            {
                MobjType mobjType = MobjLookup.npcLookup[selectedCrate.Title];
                MobjInfo mobjInfo = Info.MobjInfos[(int)mobjType];

                Vector3 truePlacePosition = __instance.truePlacePosition;
                Quaternion truePlaceRotation = __instance.truePlaceRotation;
                Vector3 placePosition = new Vector3(truePlacePosition.x, truePlacePosition.y + mobjInfo.height / 32f, truePlacePosition.z);
                Quaternion placeRotation = Quaternion.Euler(new Vector3(0f, truePlaceRotation.y, 0f));

                var mobj = MobjManager.Instance.SpawnMobj(placePosition, mobjType, placeRotation.eulerAngles.y);

                MobjManager.Instance.SpawnMobj(placePosition, MobjType.MT_TFOG);
                SoundManager.Instance.PlaySound(SoundType.sfx_telept, mobj.transform.position, false);

                return false;
            }
            else if (MobjLookup.itemLookup.ContainsKey(selectedCrate.Title))
            {
                MobjType mobjType = MobjLookup.itemLookup[selectedCrate.Title];
                MobjInfo mobjInfo = Info.MobjInfos[(int)mobjType];

                Vector3 truePlacePosition = __instance.truePlacePosition;
                Quaternion truePlaceRotation = __instance.truePlaceRotation;
                Vector3 placePosition = new Vector3(truePlacePosition.x, truePlacePosition.y + mobjInfo.height / 32f, truePlacePosition.z);
                Quaternion placeRotation = Quaternion.Euler(new Vector3(0f, truePlaceRotation.y, 0f));

                var mobj = MobjManager.Instance.SpawnMobj(placePosition, mobjType, placeRotation.eulerAngles.y);

                MobjManager.Instance.SpawnMobj(placePosition, MobjType.MT_TFOG);
                SoundManager.Instance.PlaySound(SoundType.sfx_telept, mobj.transform.position, false);

                return false;
            }

            return true;
        }
    }
}