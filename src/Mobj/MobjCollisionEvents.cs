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

            var hitObjects = Physics.SphereCastAll(transform.position, 1f, transform.position);

            for(int i = 0; i < hitObjects.Length; i++)
            {
                var hitObject = hitObjects[i];

                if(hitObject.rigidbody)
                {
                    hitObject.rigidbody.AddExplosionForce(250f, transform.position, 1.5f);
                }

                Mobj mobj = hitObject.collider.GetComponent<Mobj>();

                if(mobj == null)
                {
                    continue;
                }

                if(!MobjManager.Instance.CheckThing(mobj, missile))
                {
                    continue;
                }

                if(mobj == Mobj.player)
                {
                    Mobj.player.playerHealth.TAKEDAMAGE(1f);
                }
            }
        }
    }

}