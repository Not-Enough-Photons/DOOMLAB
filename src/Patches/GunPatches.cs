using UnityEngine;

using SLZ.Props.Weapons;
using NEP.DOOMLAB.Entities;

namespace NEP.DOOMLAB.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(Gun), nameof(Gun.OnFire))]
    public static class GunPatches
    {
        public static void Postfix(Gun __instance)
        {
            PropagateSound();
        }

        public static void PropagateSound()
        {
            Mobj[] mobjs = MobjManager.Instance.mobjs.ToArray();

            for (int i = 0; i < mobjs.Length; i++)
            {
                Mobj mobj = mobjs[i];

                if (mobj.health <= 0)
                {
                    continue;
                }

                if(mobj.currentState == mobj.info.seeState)
                {
                    continue;
                }

                if(mobj.currentState != mobj.info.seeState)
                {
                    mobj.SetState(mobj.info.seeState);
                }
            }
        }
    }
}