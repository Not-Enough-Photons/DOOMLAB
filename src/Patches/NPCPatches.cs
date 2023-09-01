using PuppetMasta;
using SLZ.AI;

namespace NEP.DOOMLAB.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(BehaviourBaseNav))]
    [HarmonyLib.HarmonyPatch(nameof(BehaviourBaseNav.SetAgro))]
    public static class BehaviourBaseNavPatches
    {
        public static void Postfix(TriggerRefProxy agroTarget)
        {
            MelonLoader.MelonLogger.Msg(agroTarget.name);
        }
    }
}
