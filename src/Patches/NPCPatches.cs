using SLZ.AI;


using HarmonyLib;

using NEP.DOOMLAB.Entities;

using MelonLoader;
using PuppetMasta;

namespace NEP.DOOMLAB.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(SubBehaviourSensors))]
    [HarmonyLib.HarmonyPatch(nameof(SubBehaviourSensors.AddThreat))]
    public static class BehaviourBaseNavPatches4
    {
        public static void Postfix(TriggerRefProxy trp, float threat)
        {
            MelonLoader.MelonLogger.Msg("Add threat: " + trp.name + " Threat: " + threat);
        }
    }
}
