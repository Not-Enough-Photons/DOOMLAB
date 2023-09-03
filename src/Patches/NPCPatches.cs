using PuppetMasta;
using SLZ.AI;
using HarmonyLib;
using NEP.DOOMLAB.Entities;

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
}
