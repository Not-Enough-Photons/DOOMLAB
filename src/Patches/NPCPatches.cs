using PuppetMasta;
using SLZ.AI;
using HarmonyLib;
using NEP.DOOMLAB.Entities;
using MelonLoader;

namespace NEP.DOOMLAB.Patches
{
    [HarmonyPatch(typeof(TriggerRefProxy), nameof(TriggerRefProxy.Awake))]
    public static class TRPPatches
    {
        public static void Postfix(TriggerRefProxy __instance)
        {
            Mobj proxyMobj = __instance.gameObject.AddComponent<Mobj>();
            proxyMobj.flags ^= MobjFlags.MF_SHOOTABLE;
        }
    }

    [HarmonyPatch(typeof(AIBrain), nameof(AIBrain.Awake))]
    public static class AIBrainPatches
    {
        public static void Postfix(AIBrain __instance)
        {
            __instance.onNPC_DeathDelegate += new System.Action<AIBrain>(Test);
        }

        public static void Test(AIBrain brain)
        {
            MelonLogger.Msg(brain.name);
        }
    }
}
