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
            if(mobj.flags.HasFlag(MobjFlags.MF_MISSILE))
            {
                ExplodeMissile(mobj, collision);
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
                SoundManager.Instance.PlaySound(mobj.info.deathSound, mobj.audioSource, false);
            }

            Mobj hitMobj = collision.gameObject.GetComponent<Mobj>();

            if(hitMobj != null)
            {
                // mobj.RadiusAttack(mobj, 256);
                mobj.TakeDamage(10 - Vector3.Distance(mobj.transform.position, hitMobj.transform.position), mobj.target, mobj);
            }
        }
    }

}