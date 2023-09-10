using UnityEngine;

using SLZ.Props.Weapons;
using SLZ.SFX;

using NEP.DOOMLAB.Sound;

namespace NEP.DOOMLAB.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class MobjGun : MonoBehaviour
    {
        public MobjGun(System.IntPtr ptr) : base(ptr) { }

        private Gun gun;
        private Mobj mobj;

        private void Start()
        {
            mobj = GetComponent<Mobj>();

            if(mobj == null)
            {
                return;
            }

            SetupGun();
        }

        private void SetupGun()
        {
            if(gun == null)
            {
                gun = gameObject.AddComponent<Gun>();
            }

            gun.roundsPerMinute = 750;
            gun.muzzleVelocity = 450;
            gun.fireMode = Gun.FireMode.AUTOMATIC;

            gun.isCharged = true;
            gun.isSlideLockedOnEmpty = false;
            gun.isLoaded = true;

            SetupGunSFX();

            gun.proxyOverride = mobj.triggerRefProxy;
            gun.firePointTransform = mobj.transform;
        }

        private void SetupGunSFX()
        {
            GunSFX gunSfx = gun.gameObject.AddComponent<GunSFX>();

            AudioClip firePistol = SoundManager.Instance.GetSound(SoundType.sfx_pistol);
            AudioClip fireShotgun = SoundManager.Instance.GetSound(SoundType.sfx_shotgn);
            AudioClip fireClip = null;

            switch(mobj.type)
            {
                case Data.MobjType.MT_POSSESSED:
                case Data.MobjType.MT_WOLFSS:
                    fireClip = firePistol;
                    break;

                case Data.MobjType.MT_SHOTGUY:
                case Data.MobjType.MT_CHAINGUY:
                    fireClip = fireShotgun;
                    break;
            }

            gunSfx.fire = new AudioClip[1]
            {
                fireClip
            };

            gun.gunSFX = gunSfx;
        }
    }
}