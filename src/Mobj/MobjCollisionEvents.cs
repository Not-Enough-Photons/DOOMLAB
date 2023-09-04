using NEP.DOOMLAB.Game;
using NEP.DOOMLAB.Sound;
using SLZ.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NEP.DOOMLAB.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class MobjCollisionEvents : MonoBehaviour
    {
        public MobjCollisionEvents(System.IntPtr ptr) : base(ptr) { }

        private Mobj mobj;

        private void Awake()
        {
            mobj = GetComponent<Mobj>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(mobj.flags.HasFlag(MobjFlags.MF_MISSILE))
            {
                ExplodeMissile(mobj);
            }
        }

        private void ExplodeMissile(Mobj missile)
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

            RaycastHit hit;
            Physics.SphereCast(transform.position, 1f, transform.position, out hit);

            Mobj hitMobj = hit.collider.GetComponent<Mobj>();

            if(hitMobj != null && MobjManager.Instance.CheckThing(hitMobj, missile))
            {
                hitMobj.TakeDamage(1f, missile, missile.target);
            }
        }
    }

}