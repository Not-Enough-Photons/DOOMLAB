using PuppetMasta;
using SLZ.AI;

namespace NEP.DOOMLAB.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(SubBehaviourSensors))]
    [HarmonyLib.HarmonyPatch(nameof(SubBehaviourSensors.SetAgro))]
    public static class BehaviourBaseNavPatches1
    {
        public static void Postfix(TriggerRefProxy trp)
        {
            MelonLoader.MelonLogger.Msg("Set agro: " + trp.name);
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(SubBehaviourSensors))]
    [HarmonyLib.HarmonyPatch(nameof(SubBehaviourSensors.SetEngaged))]
    public static class BehaviourBaseNavPatches2
    {
        public static void Postfix(TriggerRefProxy trp)
        {
            MelonLoader.MelonLogger.Msg("Set engaged: " + trp.name);
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(SubBehaviourSensors))]
    [HarmonyLib.HarmonyPatch(nameof(SubBehaviourSensors.InitialThreat))]
    public static class BehaviourBaseNavPatches3
    {
        public static void Postfix(TriggerRefProxy trp)
        {
            MelonLoader.MelonLogger.Msg("Initial threat: " + trp.name);
        }
    }

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
