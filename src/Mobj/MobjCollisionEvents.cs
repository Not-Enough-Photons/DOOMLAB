using MelonLoader;
using NEP.DOOMLAB.Game;
using NEP.DOOMLAB.Sound;

using UnityEngine;

namespace NEP.DOOMLAB.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class MobjCollisionEvents : MonoBehaviour
    {
        public MobjCollisionEvents(System.IntPtr ptr) : base(ptr) { }

        private Mobj mobj;
        private RigidbodyProjectile rigidbodyProjectile;

        private void Awake()
        {
            mobj = GetComponent<Mobj>();
            rigidbodyProjectile = gameObject.AddComponent<RigidbodyProjectile>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(mobj.flags.HasFlag(MobjFlags.MF_SPECIAL))
            {
                if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Player")
                || collision.collider.gameObject.layer == LayerMask.NameToLayer("Feet"))
                {
                    MelonLogger.Msg("Touched player");
                    DoomPlayer.Instance.TouchSpecialThing(mobj);
                }
            }

            if(mobj.flags.HasFlag(MobjFlags.MF_MISSILE))
            {
                ExplodeMissile(mobj, collision);
            }

            if(mobj.flags.HasFlag(MobjFlags.MF_SKULLFLY))
            {
                // the skull slammed into something... yep
                mobj.rigidbody.velocity = Vector3.zero;
                mobj.flags ^= MobjFlags.MF_SKULLFLY;
                mobj.SetState(mobj.info.seeState);
            }
        }

        private void ExplodeMissile(Mobj missile, Collision collision)
        {
            missile.rigidbody.velocity = Vector3.zero;
            missile.SetState(mobj.info.deathState);
            missile.collider.enabled = false;

            mobj.tics -= DoomGame.RNG.P_Random() & 3;

            if(mobj.tics < 1)
            {
                mobj.tics = 1;
            }

            mobj.flags &= MobjFlags.MF_MISSILE;

            if(mobj.info.deathSound != Sound.SoundType.sfx_None)
            {
                SoundManager.Instance.PlaySound(mobj.info.deathSound, mobj.transform.position, false);
            }

            Mobj hitMobj = collision.collider.GetComponent<Mobj>();

            if(hitMobj != null)
            {
                mobj.RadiusAttack(mobj, mobj.target, 256);
            }
        }
    }

}