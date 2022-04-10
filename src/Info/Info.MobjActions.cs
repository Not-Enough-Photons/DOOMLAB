using NEP.BWDOOM.Entities;

namespace NEP.BWDOOM.Info
{
    public class MobjActions
    {
        public void A_Light0(MOBJ mobj) { }
        public void A_WeaponReady(MOBJ mobj) { }
        public void A_Lower(MOBJ mobj) { }
        public void A_Raise(MOBJ mobj) { }
        public void A_Punch(MOBJ mobj) { }
        public void A_ReFire(MOBJ mobj) { }
        public void A_FirePistol(MOBJ mobj) { }
        public void A_Light1(MOBJ mobj) { }
        public void A_FireShotgun(MOBJ mobj) { }
        public void A_Light2(MOBJ mobj) { }
        public void A_FireShotgun2(MOBJ mobj) { }
        public void A_CheckReload(MOBJ mobj) { }
        public void A_OpenShotgun2(MOBJ mobj) { }
        public void A_LoadShotgun2(MOBJ mobj) { }
        public void A_CloseShotgun2(MOBJ mobj) { }
        public void A_FireCGun(MOBJ mobj) { }
        public void A_GunFlash(MOBJ mobj) { }
        public void A_FireMissile(MOBJ mobj) { }
        public void A_Saw(MOBJ mobj) { }
        public void A_FirePlasma(MOBJ mobj) { }
        public void A_BFGsound(MOBJ mobj) { }
        public void A_FireBFG(MOBJ mobj) { }
        public void A_BFGSpray(MOBJ mobj) { }
        public void A_Explode(MOBJ mobj) { mobj.enemyBehaviour.A_Explode(mobj); }
        public void A_Pain(MOBJ mobj) { }
        public void A_PlayerScream(MOBJ mobj) { }
        public void A_Fall(MOBJ mobj) { }
        public void A_XScream(MOBJ mobj) { }
        public void A_Look(MOBJ mobj) { mobj.enemyBehaviour.A_Look(mobj); }
        public void A_Chase(MOBJ mobj) { mobj.enemyBehaviour.A_Chase(mobj); }
        public void A_FaceTarget(MOBJ mobj) { }
        public void A_PosAttack(MOBJ mobj) { }
        public void A_Scream(MOBJ mobj) { }
        public void A_SPosAttack(MOBJ mobj) { }
        public void A_VileChase(MOBJ mobj) { }
        public void A_VileStart(MOBJ mobj) { }
        public void A_VileTarget(MOBJ mobj) { }
        public void A_VileAttack(MOBJ mobj) { }
        public void A_StartFire(MOBJ mobj) { }
        public void A_Fire(MOBJ mobj) { }
        public void A_FireCrackle(MOBJ mobj) { }
        public void A_Tracer(MOBJ mobj) { }
        public void A_SkelWhoosh(MOBJ mobj) { }
        public void A_SkelFist(MOBJ mobj) { }
        public void A_SkelMissile(MOBJ mobj) { }
        public void A_FatRaise(MOBJ mobj) { }
        public void A_FatAttack1(MOBJ mobj) { }
        public void A_FatAttack2(MOBJ mobj) { }
        public void A_FatAttack3(MOBJ mobj) { }
        public void A_BossDeath(MOBJ mobj) { }
        public void A_CPosAttack(MOBJ mobj) { }
        public void A_CPosRefire(MOBJ mobj) { }
        public void A_TroopAttack(MOBJ mobj) { mobj.enemyBehaviour.A_TroopAttack(mobj); }
        public void A_SargAttack(MOBJ mobj) { }
        public void A_HeadAttack(MOBJ mobj) { }
        public void A_BruisAttack(MOBJ mobj) { }
        public void A_SkullAttack(MOBJ mobj) { }
        public void A_Metal(MOBJ mobj) { }
        public void A_SpidRefire(MOBJ mobj) { }
        public void A_BabyMetal(MOBJ mobj) { }
        public void A_BspiAttack(MOBJ mobj) { }
        public void A_Hoof(MOBJ mobj) { }
        public void A_CyberAttack(MOBJ mobj) { }
        public void A_PainAttack(MOBJ mobj) { }
        public void A_PainDie(MOBJ mobj) { }
        public void A_KeenDie(MOBJ mobj) { }
        public void A_BrainPain(MOBJ mobj) { }
        public void A_BrainScream(MOBJ mobj) { }
        public void A_BrainDie(MOBJ mobj) { }
        public void A_BrainAwake(MOBJ mobj) { }
        public void A_BrainSpit(MOBJ mobj) { }
        public void A_SpawnSound(MOBJ mobj) { }
        public void A_SpawnFly(MOBJ mobj) { }
        public void A_BrainExplode(MOBJ mobj) { }
    }
}
