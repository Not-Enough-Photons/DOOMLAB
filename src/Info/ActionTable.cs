using System;
using System.Collections.Generic;
using NEP.DOOMLAB.Entities;

namespace NEP.DOOMLAB.Data
{
    public static class ActionTable
    {
        public static Dictionary<int, Action<Mobj>> DeHACKEDPointers = new Dictionary<int, Action<Mobj>>()
        {
            { 1, A_Light0 }
        };

        public static void A_Light0(Mobj mobj) { }
        public static void A_WeaponReady(Mobj mobj){}
        public static void A_Lower(Mobj mobj){}
        public static void A_Raise(Mobj mobj){}
        public static void A_Punch(Mobj mobj){}
        public static void A_ReFire(Mobj mobj){}
        public static void A_FirePistol(Mobj mobj){}
        public static void A_Light1(Mobj mobj){}
        public static void A_FireShotgun(Mobj mobj){}
        public static void A_Light2(Mobj mobj){}
        public static void A_FireShotgun2(Mobj mobj){}
        public static void A_CheckReload(Mobj mobj){}
        public static void A_OpenShotgun2(Mobj mobj){}
        public static void A_LoadShotgun2(Mobj mobj){}
        public static void A_CloseShotgun2(Mobj mobj){}
        public static void A_FireCGun(Mobj mobj){}
        public static void A_GunFlash(Mobj mobj){}
        public static void A_FireMissile(Mobj mobj){}
        public static void A_Saw(Mobj mobj){}
        public static void A_FirePlasma(Mobj mobj){}
        public static void A_BFGsound(Mobj mobj){}
        public static void A_FireBFG(Mobj mobj){}
        public static void A_BFGSpray(Mobj mobj){}
        public static void A_Explode(Mobj mobj){ mobj.brain.A_Explode(); }
        public static void A_Pain(Mobj mobj){ mobj.brain.A_Pain(); }
        public static void A_PlayerScream(Mobj mobj){  }
        public static void A_Fall(Mobj mobj){ mobj.brain.A_Fall(); }
        public static void A_XScream(Mobj mobj){ mobj.brain.A_XScream(); }
        public static void A_Look(Mobj mobj){ mobj.brain.A_Look(); }
        public static void A_Chase(Mobj mobj){ mobj.brain.A_Chase(); }
        public static void A_FaceTarget(Mobj mobj){ mobj.brain.A_FaceTarget(); }
        public static void A_PosAttack(Mobj mobj){ mobj.brain.A_PosAttack(); }
        public static void A_Scream(Mobj mobj){ mobj.brain.A_Scream(); }
        public static void A_SPosAttack(Mobj mobj){ mobj.brain.A_SPosAttack(); }
        public static void A_VileChase(Mobj mobj){ mobj.brain.A_VileChase(); }
        public static void A_VileStart(Mobj mobj){ mobj.brain.A_VileStart(); }
        public static void A_VileTarget(Mobj mobj){ mobj.brain.A_VileTarget(); }
        public static void A_VileAttack(Mobj mobj){ mobj.brain.A_VileAttack(); }
        public static void A_StartFire(Mobj mobj){ mobj.brain.A_StartFire(); }
        public static void A_Fire(Mobj mobj){ mobj.brain.A_Fire(); }
        public static void A_FireCrackle(Mobj mobj){ mobj.brain.A_FireCrackle(); }
        public static void A_Tracer(Mobj mobj){ mobj.brain.A_Tracer(); }
        public static void A_SkelWhoosh(Mobj mobj){ mobj.brain.A_SkelWhoosh(); }
        public static void A_SkelFist(Mobj mobj){ mobj.brain.A_SkelFist(); }
        public static void A_SkelMissile(Mobj mobj){ mobj.brain.A_SkelMissile(); }
        public static void A_FatRaise(Mobj mobj){ mobj.brain.A_FatRaise(); }
        public static void A_FatAttack1(Mobj mobj){ mobj.brain.A_FatAttack1(); }
        public static void A_FatAttack2(Mobj mobj){ mobj.brain.A_FatAttack2(); }
        public static void A_FatAttack3(Mobj mobj){ mobj.brain.A_FatAttack3(); }
        public static void A_BossDeath(Mobj mobj){}
        public static void A_CPosAttack(Mobj mobj){ mobj.brain.A_CPosAttack(); }
        public static void A_CPosRefire(Mobj mobj){ mobj.brain.A_CPosRefire(); }
        public static void A_TroopAttack(Mobj mobj){ mobj.brain.A_TroopAttack(); }
        public static void A_SargAttack(Mobj mobj){ mobj.brain.A_SargAttack(); }
        public static void A_HeadAttack(Mobj mobj){ mobj.brain.A_HeadAttack(); }
        public static void A_BruisAttack(Mobj mobj){ mobj.brain.A_BruisAttack(); }
        public static void A_SkullAttack(Mobj mobj){ mobj.brain.A_SkullAttack(); }
        public static void A_Metal(Mobj mobj){ mobj.brain.A_Metal(); }
        public static void A_SpidRefire(Mobj mobj){ mobj.brain.A_SpidRefire(); }
        public static void A_BabyMetal(Mobj mobj){ mobj.brain.A_BabyMetal(); }
        public static void A_BspiAttack(Mobj mobj){ mobj.brain.A_BspiAttack(); }
        public static void A_Hoof(Mobj mobj){ mobj.brain.A_Hoof(); }
        public static void A_CyberAttack(Mobj mobj){ mobj.brain.A_CyberAttack(); }
        public static void A_PainAttack(Mobj mobj){ mobj.brain.A_PainAttack(); }
        public static void A_PainDie(Mobj mobj){ mobj.brain.A_PainDie(); }
        public static void A_KeenDie(Mobj mobj){}
        public static void A_BrainPain(Mobj mobj){ mobj.brain.A_BrainPain(); }
        public static void A_BrainScream(Mobj mobj){ mobj.brain.A_BrainScream(); }
        public static void A_BrainDie(Mobj mobj){ }
        public static void A_BrainAwake(Mobj mobj){ mobj.brain.A_BrainAwake(); }
        public static void A_BrainSpit(Mobj mobj){}
        public static void A_SpawnSound(Mobj mobj){}
        public static void A_SpawnFly(Mobj mobj){}
        public static void A_BrainExplode(Mobj mobj){}
        public static void A_Refire(Mobj mobj) { }
        public static void A_FALL(Mobj mobj) { }
    }
}
