using MelonLoader;
using NEP.DOOMLAB.Entities;
using NEP.DOOMLAB.Game;
using NEP.DOOMLAB.Sound;
using SLZ.Combat;
using SLZ.SFX;
using UnityEngine;

namespace NEP.DOOMLAB.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(Projectile))]
    [HarmonyLib.HarmonyPatch(nameof(Projectile.Awake))]
    public static class ProjectilePatch
    {
        public static void Postfix(Projectile __instance)
        {
            __instance.onCollision.AddListener(new System.Action<Collider, Vector3, Vector3>((hitCol, world, normal) =>
            {
                var lookup = Mobj.ComponentCache.CacheLookup;

                if (!lookup.ContainsKey(hitCol.gameObject.GetInstanceID()))
                {
                    return;
                }

                Mobj hitMobj = lookup[hitCol.gameObject.GetInstanceID()];

                if (hitMobj == null || hitMobj == Mobj.player)
                {
                    return;
                }

                if (!hitMobj.flags.HasFlag(MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE))
                {
                    return;
                }

                if (hitMobj.flags.HasFlag(MobjFlags.MF_CORPSE))
                {
                    return;
                }

                MobjInteraction.DamageMobj(hitMobj, Mobj.player, Mobj.player, __instance._data.damageMultiplier * (DoomGame.RNG.P_Random() & 3) * 6f);

                if (!hitMobj.flags.HasFlag(MobjFlags.MF_NOBLOOD))
                {
                    MobjManager.Instance.SpawnMobj(world, Data.MobjType.MT_BLOOD);
                }
                else if(hitMobj.flags.HasFlag(MobjFlags.MF_NOBLOOD))
                {
                    MobjManager.Instance.SpawnMobj(world, Data.MobjType.MT_PUFF);
                }
            }));
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(HandSFX))]
    [HarmonyLib.HarmonyPatch(nameof(HandSFX.PunchAttack))]
    public static class PunchPatch
    {
        public static void Postfix(Collision c, float impulse, float relVelSqr)
        {
            var lookup = Mobj.ComponentCache.CacheLookup;

            if(!lookup.ContainsKey(c.gameObject.GetInstanceID()))
            {
                return;
            }

            Mobj hitMobj = lookup[c.gameObject.GetInstanceID()];

            if(hitMobj != null && hitMobj != Mobj.player)
            {
                if(!hitMobj.flags.HasFlag(MobjFlags.MF_SHOOTABLE))
                {
                    return;
                }

                if(!hitMobj.flags.HasFlag(MobjFlags.MF_NOBLOOD))
                {
                    MobjManager.Instance.SpawnMobj(c.contacts[0].point, Data.MobjType.MT_BLOOD);
                }
                else
                {
                    MobjManager.Instance.SpawnMobj(c.contacts[0].point, Data.MobjType.MT_PUFF);
                }

                hitMobj.rigidbody.AddForce(c.impactForceSum, ForceMode.Impulse);
                MobjInteraction.DamageMobj(hitMobj, Mobj.player, Mobj.player, impulse);
                SoundManager.Instance.PlaySound(SoundType.sfx_punch, c.contacts[0].point, false);
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(ImpactSFX))]
    [HarmonyLib.HarmonyPatch(nameof(ImpactSFX.BluntAttack))]
    public static class BluntPatch
    {
        public static void Postfix(float impulse, Collision c)
        {
            var lookup = Mobj.ComponentCache.CacheLookup;

            if(!lookup.ContainsKey(c.gameObject.GetInstanceID()))
            {
                return;
            }

            Mobj hitMobj = lookup[c.gameObject.GetInstanceID()];

            if (hitMobj != null && hitMobj != Mobj.player)
            {
                if(!hitMobj.flags.HasFlag(MobjFlags.MF_SHOOTABLE))
                {
                    return;
                }

                if (!hitMobj.flags.HasFlag(MobjFlags.MF_NOBLOOD))
                {
                    MobjManager.Instance.SpawnMobj(c.contacts[0].point, Data.MobjType.MT_BLOOD);
                }
                else
                {
                    MobjManager.Instance.SpawnMobj(c.contacts[0].point, Data.MobjType.MT_PUFF);
                }

                hitMobj.rigidbody.AddForce(c.impactForceSum, ForceMode.Impulse);
                MobjInteraction.DamageMobj(hitMobj, Mobj.player, Mobj.player, impulse);
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(StabSlash))]
    [HarmonyLib.HarmonyPatch(nameof(StabSlash.OnCollisionEnter))]
    public static class StabPatch
    {
        public static void Postfix(Collision c)
        {
            var lookup = Mobj.ComponentCache.CacheLookup;

            if(!lookup.ContainsKey(c.gameObject.GetInstanceID()))
            {
                return;
            }

            Mobj hitMobj = lookup[c.gameObject.GetInstanceID()];

            if (hitMobj != null && hitMobj != Mobj.player && c.impulse.magnitude > 0.25f)
            {
                if (!hitMobj.flags.HasFlag(MobjFlags.MF_SHOOTABLE))
                {
                    return;
                }

                if (!hitMobj.flags.HasFlag(MobjFlags.MF_NOBLOOD))
                {
                    MobjManager.Instance.SpawnMobj(c.contacts[0].point, Data.MobjType.MT_BLOOD);
                }
                else
                {
                    MobjManager.Instance.SpawnMobj(c.contacts[0].point, Data.MobjType.MT_PUFF);
                }

                hitMobj.rigidbody.AddForce(c.impactForceSum, ForceMode.Impulse);

                // damage balancing is hard :(
                MobjInteraction.DamageMobj(hitMobj, Mobj.player, Mobj.player, c.impulse.sqrMagnitude * 0.25f);
            }
        }
    }
}
