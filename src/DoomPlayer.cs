using NEP.DOOMLAB.Entities;
using NEP.DOOMLAB.Sound;
using UnityEngine;

namespace NEP.DOOMLAB
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class DoomPlayer : MonoBehaviour
    {
        public DoomPlayer(System.IntPtr ptr) : base(ptr) { }

        public static DoomPlayer Instance { get; private set; }

        public int ItemCount => itemCount;

        public Player_Health Health => Mobj.player.playerHealth;

        private int itemCount = 0;

        private void Awake()
        {
            Instance = this;
        }

        public void TouchSpecialThing(Mobj special)
        {
            SoundType sound = SoundType.sfx_itemup;

            var playerHealth = Mobj.player.playerHealth;

            switch(special.sprite)
            {
                case Data.SpriteNum.SPR_ARM1:
                    break;
                    
                case Data.SpriteNum.SPR_ARM2:
                    break;

                case Data.SpriteNum.SPR_BON1:
                    playerHealth.curr_Health += 0.1f;

                    if(playerHealth.curr_Health < 0 && playerHealth.deathIsImminent)
                    {
                        playerHealth.LifeSavingDamgeDealt();
                    }
                    break;

                case Data.SpriteNum.SPR_BON2:
                    break;

                case Data.SpriteNum.SPR_SOUL:
                    playerHealth.curr_Health = 10f;

                    if(playerHealth.curr_Health < 0 && playerHealth.deathIsImminent)
                    {
                        playerHealth.LifeSavingDamgeDealt();
                    }

                    sound = SoundType.sfx_getpow;
                    break;

                case Data.SpriteNum.SPR_MEGA:
                    playerHealth.curr_Health = 10f;

                    if(playerHealth.curr_Health < 0 && playerHealth.deathIsImminent)
                    {
                        playerHealth.LifeSavingDamgeDealt();
                    }

                    sound = SoundType.sfx_getpow;
                    break;

                case Data.SpriteNum.SPR_BKEY:
                    break;

                case Data.SpriteNum.SPR_YKEY:
                    break;

                case Data.SpriteNum.SPR_RKEY:
                    break;

                case Data.SpriteNum.SPR_BSKU:
                    break;
                
                case Data.SpriteNum.SPR_YSKU:
                    break;

                case Data.SpriteNum.SPR_RSKU:
                    break;

                case Data.SpriteNum.SPR_STIM:
                    playerHealth.curr_Health += 1f;

                    if(playerHealth.curr_Health < 0 && playerHealth.deathIsImminent)
                    {
                        playerHealth.LifeSavingDamgeDealt();
                    }

                    sound = SoundType.sfx_getpow;
                    break;

                case Data.SpriteNum.SPR_MEDI:
                    playerHealth.curr_Health += 5f;

                    if(playerHealth.curr_Health < 0 && playerHealth.deathIsImminent)
                    {
                        playerHealth.LifeSavingDamgeDealt();
                    }

                    sound = SoundType.sfx_getpow;
                    break;

                case Data.SpriteNum.SPR_PINV:
                    playerHealth.SetHealthMode((int)Player_Health.HealthMode.Invincible);
                    sound = SoundType.sfx_getpow;
                    break;

                case Data.SpriteNum.SPR_PSTR:
                    playerHealth._rigManager.avatar._strengthLower = 1000f;
                    sound = SoundType.sfx_getpow;
                    break;

                case Data.SpriteNum.SPR_PINS:
                    sound = SoundType.sfx_getpow;
                    break;

                case Data.SpriteNum.SPR_SUIT:
                    sound = SoundType.sfx_getpow;
                    break;

                case Data.SpriteNum.SPR_PMAP:
                    sound = SoundType.sfx_getpow;
                    break;

                case Data.SpriteNum.SPR_PVIS:
                    sound = SoundType.sfx_getpow;
                    break;

                case Data.SpriteNum.SPR_CLIP:
                    break;

                case Data.SpriteNum.SPR_AMMO:
                    break;

                case Data.SpriteNum.SPR_ROCK:
                    break;

                case Data.SpriteNum.SPR_BROK:
                    break;
                
                case Data.SpriteNum.SPR_CELL:
                    break;

                case Data.SpriteNum.SPR_CELP:
                    break;

                case Data.SpriteNum.SPR_SHEL:
                    break;

                case Data.SpriteNum.SPR_SBOX:
                    break;

                case Data.SpriteNum.SPR_BPAK:
                    break;
            }

            if(special.flags.HasFlag(MobjFlags.MF_COUNTITEM))
            {
                itemCount++;
            }

            MobjManager.Instance.RemoveMobj(special);
            SoundManager.Instance.PlaySound(sound, Vector3.zero, true);
        }
    }
}