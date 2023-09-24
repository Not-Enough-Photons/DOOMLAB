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
            Mobj other = collision.collider.GetComponent<Mobj>();

            if(mobj.flags.HasFlag(MobjFlags.MF_SPECIAL))
            {
                if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Player")
                || collision.collider.gameObject.layer == LayerMask.NameToLayer("Feet"))
                {
                    DoomPlayer.Instance.TouchSpecialThing(mobj);
                }
            }

            if(mobj.flags.HasFlag(MobjFlags.MF_MISSILE))
            {
                ExplodeMissile(mobj, other);
            }

            if(mobj.flags.HasFlag(MobjFlags.MF_SKULLFLY))
            {
                MobjInteraction.CheckThing(other, mobj);
            }
        }

        private void ExplodeMissile(Mobj missile, Mobj hitMobj)
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

            if(hitMobj != null)
            {
                MobjInteraction.CheckThing(hitMobj, missile);
            }
        }
    }

}