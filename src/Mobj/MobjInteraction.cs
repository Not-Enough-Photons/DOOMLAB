using NEP.DOOMLAB.Game;
using NEP.DOOMLAB.Data;

using UnityEngine;

using SLZ.Combat;

using MelonLoader;

namespace NEP.DOOMLAB.Entities
{
    public static class MobjInteraction
    {
        public static bool CheckThing(Mobj thing, Mobj tmThing)
        {
            if (!thing.flags.HasFlag(MobjFlags.MF_SOLID))
            {
                return false;
            }

            if(!thing.flags.HasFlag(MobjFlags.MF_SHOOTABLE))
            {
                return false;
            }

            if (thing == tmThing)
            {
                return false;
            }

            if (tmThing.flags.HasFlag(MobjFlags.MF_SKULLFLY))
            {
                float damage = ((DoomGame.RNG.P_Random() % 8) + 1) * tmThing.info.damage;

                DamageMobj(thing, tmThing, tmThing, damage);

                tmThing.flags &= ~MobjFlags.MF_SKULLFLY;
                tmThing.rigidbody.velocity = Vector3.zero;

                tmThing.SetState(tmThing.info.spawnState);

                return true;
            }

            if (tmThing.flags.HasFlag(MobjFlags.MF_MISSILE))
            {
                if (tmThing.target != null && (
                tmThing.target.type == thing.type ||
                (tmThing.target.type == MobjType.MT_KNIGHT && thing.type == MobjType.MT_BRUISER) ||
                (tmThing.target.type == MobjType.MT_BRUISER && thing.type == MobjType.MT_KNIGHT)))
                {
                    // Don't damage same species
                    if (thing.type == tmThing.target.type)
                    {
                        return false;
                    }
                }

                if (!thing.flags.HasFlag(MobjFlags.MF_SHOOTABLE))
                {
                    return !thing.flags.HasFlag(MobjFlags.MF_SOLID);
                }

                float damage = ((DoomGame.RNG.P_Random() % 8) + 1) * tmThing.info.damage;
                DamageMobj(thing, tmThing, tmThing.target, damage);

                return true;
            }

            return !thing.flags.HasFlag(MobjFlags.MF_SOLID);
        }

        public static bool LineAttack(Mobj shootThing, Vector3 origin, Vector3 direction, float damage, float distance)
        {
            Ray ray = new Ray(origin, origin + direction);

            if (Physics.Raycast(ray, out RaycastHit hit, distance))
            {
                Collider collider = hit.collider;
                ImpactProperties impactProperties = collider.GetComponent<ImpactProperties>();

                if (impactProperties != null)
                {
                    MobjManager.Instance.SpawnMobj(hit.point, MobjType.MT_PUFF);
                    return false;
                }

                Mobj hitMobj = collider.GetComponent<Mobj>();

                if (hitMobj == null)
                {
                    return false;
                }

                if (hitMobj == shootThing)
                {
                    // we cant shoot ourselves
                    return false;
                }

                if (!hitMobj.flags.HasFlag(MobjFlags.MF_SHOOTABLE))
                {
                    return false; // Corpse
                }

                if (hitMobj.flags.HasFlag(MobjFlags.MF_NOBLOOD))
                {
                    MobjManager.Instance.SpawnMobj(hit.point, MobjType.MT_PUFF);
                }
                else
                {
                    MobjManager.Instance.SpawnMobj(hit.point, MobjType.MT_BLOOD);
                }

                if (damage > 0f)
                {
                    if (hitMobj == Mobj.player)
                    {
                        Mobj.player.playerHealth.TAKEDAMAGE(damage);
                    }
                    else
                    {
                        DamageMobj(hitMobj, shootThing, shootThing, damage);
                    }
                }

                return true;
            }

            return false;
        }

        public static void RadiusAttack(Mobj spot, Mobj source, float damage)
        {
            var hits = Physics.BoxCastAll(spot.transform.position, Vector3.one * 4, spot.transform.position);

            for (int i = 0; i < hits.Length; i++)
            {
                Mobj hit = hits[i].collider.GetComponent<Mobj>();
                RadiusAttackIterator(hit, spot, source, damage);
            }
        }

        public static bool RadiusAttackIterator(Mobj thing, Mobj spot, Mobj source, float damage)
        {
            if(thing == null)
            {
                return false;
            }

            if (!thing.flags.HasFlag(MobjFlags.MF_SHOOTABLE))
            {
                return false;
            }

            // take no damage from rockets if we're a cyborg or spider
            if (thing.type == MobjType.MT_CYBORG || thing.type == MobjType.MT_SPIDER)
            {
                return false;
            }

            float dx = Mathf.Abs(thing.transform.position.x - spot.transform.position.x);
            float dz = Mathf.Abs(thing.transform.position.z - spot.transform.position.z);

            float distance = dx > dz ? dx : dz;
            distance = (distance - thing.radius / 32f);
            MelonLogger.Msg("Absolute Distance (in meters): " + distance);

            if (distance < 0)
            {
                distance = 0;
            }

            if (distance > damage)
            {
                return false;
            }

            if (thing.brain == null)
            {
                return false;
            }

            if (thing.brain.CheckSight(spot))
            {
                if (thing == Mobj.player)
                {
                    Mobj.player.playerHealth.TAKEDAMAGE(damage);
                }
                else
                {
                    DamageMobj(thing, spot, source, damage - distance);
                    MelonLogger.Msg($"Real Damage: {damage - distance}");
                }
            }

            return true;
        }

        public static void DamageMobj(Mobj target, Mobj inflictor, Mobj source, float damage)
        {
            if (!target.flags.HasFlag(MobjFlags.MF_SHOOTABLE))
            {
                return;
            }

            if (target.health <= 0f)
            {
                return;
            }

            if (target.flags.HasFlag(MobjFlags.MF_SKULLFLY))
            {
                target.rigidbody.velocity = Vector3.zero;
            }

            target.health -= damage;
            if (target.health <= 0)
            {
                target.Kill();
                return;
            }

            if (DoomGame.RNG.P_Random() < target.info.painChance && !target.flags.HasFlag(MobjFlags.MF_SKULLFLY))
            {
                target.flags |= MobjFlags.MF_JUSTHIT;
                target.SetState(target.info.painState);
            }

            target.reactionTime = 0;

            if (target.threshold == 0 || target.type == MobjType.MT_VILE
                && source != null && source != target
                && source.type != MobjType.MT_VILE)
            {
                target.target = source;
                target.threshold = 8;

                if (target.state == Info.GetState(target.info.spawnState) && target.info.seeState != StateNum.S_NULL)
                {
                    target.SetState(target.info.seeState);
                }
            }
        }
    }
}