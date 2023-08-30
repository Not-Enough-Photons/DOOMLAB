using NEP.DOOMLAB.Sound;

namespace NEP.DOOMLAB.Data
{
    public static class Info
    {
        public static string[] SpriteNames = new string[]
        {
            "TROO","SHTG","PUNG","PISG","PISF","SHTF","SHT2","CHGG","CHGF","MISG",
            "MISF","SAWG","PLSG","PLSF","BFGG","BFGF","BLUD","PUFF","BAL1","BAL2",
            "PLSS","PLSE","MISL","BFS1","BFE1","BFE2","TFOG","IFOG","PLAY","POSS",
            "SPOS","VILE","FIRE","FATB","FBXP","SKEL","MANF","FATT","CPOS","SARG",
            "HEAD","BAL7","BOSS","BOS2","SKUL","SPID","BSPI","APLS","APBX","CYBR",
            "PAIN","SSWV","KEEN","BBRN","BOSF","ARM1","ARM2","BAR1","BEXP","FCAN",
            "BON1","BON2","BKEY","RKEY","YKEY","BSKU","RSKU","YSKU","STIM","MEDI",
            "SOUL","PINV","PSTR","PINS","MEGA","SUIT","PMAP","PVIS","CLIP","AMMO",
            "ROCK","BROK","CELL","CELP","SHEL","SBOX","BPAK","BFUG","MGUN","CSAW",
            "LAUN","PLAS","SHOT","SGN2","COLU","SMT2","GOR1","POL2","POL5","POL4",
            "POL3","POL1","POL6","GOR2","GOR3","GOR4","GOR5","SMIT","COL1","COL2",
            "COL3","COL4","CAND","CBRA","COL6","TRE1","TRE2","ELEC","CEYE","FSKU",
            "COL5","TBLU","TGRN","TRED","SMBT","SMGT","SMRT","HDB1","HDB2","HDB3",
            "HDB4","HDB5","HDB6","POB1","POB2","BRS1","TLMP","TLP2"
        };

        public static State[] states = new State[(int)StateNum.NUMSTATES]
        {
    new State(SpriteNum.SPR_TROO, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SHTG, 4, 0, ActionTable.A_Light0, StateNum.S_NULL),
    new State(SpriteNum.SPR_PUNG, 0, 1, ActionTable.A_WeaponReady, StateNum.S_PUNCH),
    new State(SpriteNum.SPR_PUNG, 0, 1, ActionTable.A_Lower, StateNum.S_PUNCHDOWN),
    new State(SpriteNum.SPR_PUNG, 0, 1, ActionTable.A_Raise, StateNum.S_PUNCHUP),
    new State(SpriteNum.SPR_PUNG, 1, 4, null, StateNum.S_PUNCH2),
    new State(SpriteNum.SPR_PUNG, 2, 4, ActionTable.A_Punch, StateNum.S_PUNCH3),
    new State(SpriteNum.SPR_PUNG, 3, 5, null, StateNum.S_PUNCH4),
    new State(SpriteNum.SPR_PUNG, 2, 4, null, StateNum.S_PUNCH5),
    new State(SpriteNum.SPR_PUNG, 1, 5, ActionTable.A_ReFire, StateNum.S_PUNCH),
    new State(SpriteNum.SPR_PISG, 0, 1, ActionTable.A_WeaponReady, StateNum.S_PISTOL),
    new State(SpriteNum.SPR_PISG, 0, 1, ActionTable.A_Lower, StateNum.S_PISTOLDOWN),
    new State(SpriteNum.SPR_PISG, 0, 1, ActionTable.A_Raise, StateNum.S_PISTOLUP),
    new State(SpriteNum.SPR_PISG, 0, 4, null, StateNum.S_PISTOL2),
    new State(SpriteNum.SPR_PISG, 1, 6, ActionTable.A_FirePistol, StateNum.S_PISTOL3),
    new State(SpriteNum.SPR_PISG, 2, 4, null, StateNum.S_PISTOL4),
    new State(SpriteNum.SPR_PISG, 1, 5, ActionTable.A_ReFire, StateNum.S_PISTOL),
    new State(SpriteNum.SPR_PISF, 32768, 7, ActionTable.A_Light1, StateNum.S_LIGHTDONE),
    new State(SpriteNum.SPR_SHTG, 0, 1, ActionTable.A_WeaponReady, StateNum.S_SGUN),
    new State(SpriteNum.SPR_SHTG, 0, 1, ActionTable.A_Lower, StateNum.S_SGUNDOWN),
    new State(SpriteNum.SPR_SHTG, 0, 1, ActionTable.A_Raise, StateNum.S_SGUNUP),
    new State(SpriteNum.SPR_SHTG, 0, 3, null, StateNum.S_SGUN2),
    new State(SpriteNum.SPR_SHTG, 0, 7, ActionTable.A_FireShotgun, StateNum.S_SGUN3),
    new State(SpriteNum.SPR_SHTG, 1, 5, null, StateNum.S_SGUN4),
    new State(SpriteNum.SPR_SHTG, 2, 5, null, StateNum.S_SGUN5),
    new State(SpriteNum.SPR_SHTG, 3, 4, null, StateNum.S_SGUN6),
    new State(SpriteNum.SPR_SHTG, 2, 5, null, StateNum.S_SGUN7),
    new State(SpriteNum.SPR_SHTG, 1, 5, null, StateNum.S_SGUN8),
    new State(SpriteNum.SPR_SHTG, 0, 3, null, StateNum.S_SGUN9),
    new State(SpriteNum.SPR_SHTG, 0, 7, ActionTable.A_ReFire, StateNum.S_SGUN),
    new State(SpriteNum.SPR_SHTF, 32768, 4, ActionTable.A_Light1, StateNum.S_SGUNFLASH2),
    new State(SpriteNum.SPR_SHTF, 32769, 3, ActionTable.A_Light2, StateNum.S_LIGHTDONE),
    new State(SpriteNum.SPR_SHT2, 0, 1, ActionTable.A_WeaponReady, StateNum.S_DSGUN),
    new State(SpriteNum.SPR_SHT2, 0, 1, ActionTable.A_Lower, StateNum.S_DSGUNDOWN),
    new State(SpriteNum.SPR_SHT2, 0, 1, ActionTable.A_Raise, StateNum.S_DSGUNUP),
    new State(SpriteNum.SPR_SHT2, 0, 3, null, StateNum.S_DSGUN2),
    new State(SpriteNum.SPR_SHT2, 0, 7, ActionTable.A_FireShotgun2, StateNum.S_DSGUN3),
    new State(SpriteNum.SPR_SHT2, 1, 7, null, StateNum.S_DSGUN4),
    new State(SpriteNum.SPR_SHT2, 2, 7, ActionTable.A_CheckReload, StateNum.S_DSGUN5),
    new State(SpriteNum.SPR_SHT2, 3, 7, ActionTable.A_OpenShotgun2, StateNum.S_DSGUN6),
    new State(SpriteNum.SPR_SHT2, 4, 7, null, StateNum.S_DSGUN7),
    new State(SpriteNum.SPR_SHT2, 5, 7, ActionTable.A_LoadShotgun2, StateNum.S_DSGUN8),
    new State(SpriteNum.SPR_SHT2, 6, 6, null, StateNum.S_DSGUN9),
    new State(SpriteNum.SPR_SHT2, 7, 6, ActionTable.A_CloseShotgun2, StateNum.S_DSGUN10),
    new State(SpriteNum.SPR_SHT2, 0, 5, ActionTable.A_ReFire, StateNum.S_DSGUN),
    new State(SpriteNum.SPR_SHT2, 1, 7, null, StateNum.S_DSNR2),
    new State(SpriteNum.SPR_SHT2, 0, 3, null, StateNum.S_DSGUNDOWN),
    new State(SpriteNum.SPR_SHT2, 32776, 5, ActionTable.A_Light1, StateNum.S_DSGUNFLASH2),
    new State(SpriteNum.SPR_SHT2, 32777, 4, ActionTable.A_Light2, StateNum.S_LIGHTDONE),
    new State(SpriteNum.SPR_CHGG, 0, 1, ActionTable.A_WeaponReady, StateNum.S_CHAIN),
    new State(SpriteNum.SPR_CHGG, 0, 1, ActionTable.A_Lower, StateNum.S_CHAINDOWN),
    new State(SpriteNum.SPR_CHGG, 0, 1, ActionTable.A_Raise, StateNum.S_CHAINUP),
    new State(SpriteNum.SPR_CHGG, 0, 4, ActionTable.A_FireCGun, StateNum.S_CHAIN2),
    new State(SpriteNum.SPR_CHGG, 1, 4, ActionTable.A_FireCGun, StateNum.S_CHAIN3),
    new State(SpriteNum.SPR_CHGG, 1, 0, ActionTable.A_ReFire, StateNum.S_CHAIN),
    new State(SpriteNum.SPR_CHGF, 32768, 5, ActionTable.A_Light1, StateNum.S_LIGHTDONE),
    new State(SpriteNum.SPR_CHGF, 32769, 5, ActionTable.A_Light2, StateNum.S_LIGHTDONE),
    new State(SpriteNum.SPR_MISG, 0, 1, ActionTable.A_WeaponReady, StateNum.S_MISSILE),
    new State(SpriteNum.SPR_MISG, 0, 1, ActionTable.A_Lower, StateNum.S_MISSILEDOWN),
    new State(SpriteNum.SPR_MISG, 0, 1, ActionTable.A_Raise, StateNum.S_MISSILEUP),
    new State(SpriteNum.SPR_MISG, 1, 8, ActionTable.A_GunFlash, StateNum.S_MISSILE2),
    new State(SpriteNum.SPR_MISG, 1, 12, ActionTable.A_FireMissile, StateNum.S_MISSILE3),
    new State(SpriteNum.SPR_MISG, 1, 0, ActionTable.A_ReFire, StateNum.S_MISSILE),
    new State(SpriteNum.SPR_MISF, 32768, 3, ActionTable.A_Light1, StateNum.S_MISSILEFLASH2),
    new State(SpriteNum.SPR_MISF, 32769, 4, null, StateNum.S_MISSILEFLASH3),
    new State(SpriteNum.SPR_MISF, 32770, 4, ActionTable.A_Light2, StateNum.S_MISSILEFLASH4),
    new State(SpriteNum.SPR_MISF, 32771, 4, ActionTable.A_Light2, StateNum.S_LIGHTDONE),
    new State(SpriteNum.SPR_SAWG, 2, 4, ActionTable.A_WeaponReady, StateNum.S_SAWB),
    new State(SpriteNum.SPR_SAWG, 3, 4, ActionTable.A_WeaponReady, StateNum.S_SAW),
    new State(SpriteNum.SPR_SAWG, 2, 1, ActionTable.A_Lower, StateNum.S_SAWDOWN),
    new State(SpriteNum.SPR_SAWG, 2, 1, ActionTable.A_Raise, StateNum.S_SAWUP),
    new State(SpriteNum.SPR_SAWG, 0, 4, ActionTable.A_Saw, StateNum.S_SAW2),
    new State(SpriteNum.SPR_SAWG, 1, 4, ActionTable.A_Saw, StateNum.S_SAW3),
    new State(SpriteNum.SPR_SAWG, 1, 0, ActionTable.A_ReFire, StateNum.S_SAW),
    new State(SpriteNum.SPR_PLSG, 0, 1, ActionTable.A_WeaponReady, StateNum.S_PLASMA),
    new State(SpriteNum.SPR_PLSG, 0, 1, ActionTable.A_Lower, StateNum.S_PLASMADOWN),
    new State(SpriteNum.SPR_PLSG, 0, 1, ActionTable.A_Raise, StateNum.S_PLASMAUP),
    new State(SpriteNum.SPR_PLSG, 0, 3, ActionTable.A_FirePlasma, StateNum.S_PLASMA2),
    new State(SpriteNum.SPR_PLSG, 1, 20, ActionTable.A_Refire, StateNum.S_PLASMA),
    new State(SpriteNum.SPR_PLSF, 32768, 4, ActionTable.A_Light1, StateNum.S_LIGHTDONE),
    new State(SpriteNum.SPR_PLSF, 32769, 4, ActionTable.A_Light1, StateNum.S_LIGHTDONE),
    new State(SpriteNum.SPR_BFGG, 0, 1, ActionTable.A_WeaponReady, StateNum.S_BFG),
    new State(SpriteNum.SPR_BFGG, 0, 1, ActionTable.A_Lower, StateNum.S_BFGDOWN),
    new State(SpriteNum.SPR_BFGG, 0, 1, ActionTable.A_Raise, StateNum.S_BFGUP),
    new State(SpriteNum.SPR_BFGG, 0, 20, ActionTable.A_BFGsound, StateNum.S_BFG2),
    new State(SpriteNum.SPR_BFGG, 1, 10, ActionTable.A_GunFlash, StateNum.S_BFG3),
    new State(SpriteNum.SPR_BFGG, 1, 10, ActionTable.A_FireBFG, StateNum.S_BFG4),
    new State(SpriteNum.SPR_BFGG, 1, 20, ActionTable.A_ReFire, StateNum.S_BFG),
    new State(SpriteNum.SPR_BFGF, 32768, 11, ActionTable.A_Light1, StateNum.S_BFGFLASH2),
    new State(SpriteNum.SPR_BFGF, 32769, 6, ActionTable.A_Light2, StateNum.S_LIGHTDONE),
    new State(SpriteNum.SPR_BLUD, 2, 8, null, StateNum.S_BLOOD2),
    new State(SpriteNum.SPR_BLUD, 1, 8, null, StateNum.S_BLOOD3),
    new State(SpriteNum.SPR_BLUD, 0, 8, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_PUFF, 32768, 4, null, StateNum.S_PUFF2),
    new State(SpriteNum.SPR_PUFF, 1, 4, null, StateNum.S_PUFF3),
    new State(SpriteNum.SPR_PUFF, 2, 4, null, StateNum.S_PUFF4),
    new State(SpriteNum.SPR_PUFF, 3, 4, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_BAL1, 32768, 4, null, StateNum.S_TBALL2),
    new State(SpriteNum.SPR_BAL1, 32769, 4, null, StateNum.S_TBALL1),
    new State(SpriteNum.SPR_BAL1, 32770, 6, null, StateNum.S_TBALLX2),
    new State(SpriteNum.SPR_BAL1, 32771, 6, null, StateNum.S_TBALLX3),
    new State(SpriteNum.SPR_BAL1, 32772, 6, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_BAL2, 32768, 4, null, StateNum.S_RBALL2),
    new State(SpriteNum.SPR_BAL2, 32769, 4, null, StateNum.S_RBALL1),
    new State(SpriteNum.SPR_BAL2, 32770, 6, null, StateNum.S_RBALLX2),
    new State(SpriteNum.SPR_BAL2, 32771, 6, null, StateNum.S_RBALLX3),
    new State(SpriteNum.SPR_BAL2, 32772, 6, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_PLSS, 32768, 6, null, StateNum.S_PLASBALL2),
    new State(SpriteNum.SPR_PLSS, 32769, 6, null, StateNum.S_PLASBALL),
    new State(SpriteNum.SPR_PLSE, 32768, 4, null, StateNum.S_PLASEXP2),
    new State(SpriteNum.SPR_PLSE, 32769, 4, null, StateNum.S_PLASEXP3),
    new State(SpriteNum.SPR_PLSE, 32770, 4, null, StateNum.S_PLASEXP4),
    new State(SpriteNum.SPR_PLSE, 32771, 4, null, StateNum.S_PLASEXP5),
    new State(SpriteNum.SPR_PLSE, 32772, 4, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_MISL, 32768, 1, null, StateNum.S_ROCKET),
    new State(SpriteNum.SPR_BFS1, 32768, 4, null, StateNum.S_BFGSHOT2),
    new State(SpriteNum.SPR_BFS1, 32769, 4, null, StateNum.S_BFGSHOT),
    new State(SpriteNum.SPR_BFE1, 32768, 8, null, StateNum.S_BFGLAND2),
    new State(SpriteNum.SPR_BFE1, 32769, 8, null, StateNum.S_BFGLAND3),
    new State(SpriteNum.SPR_BFE1, 32770, 8, ActionTable.A_BFGSpray, StateNum.S_BFGLAND4),
    new State(SpriteNum.SPR_BFE1, 32771, 8, null, StateNum.S_BFGLAND5),
    new State(SpriteNum.SPR_BFE1, 32772, 8, null, StateNum.S_BFGLAND6),
    new State(SpriteNum.SPR_BFE1, 32773, 8, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_BFE2, 32768, 8, null, StateNum.S_BFGEXP2),
    new State(SpriteNum.SPR_BFE2, 32769, 8, null, StateNum.S_BFGEXP3),
    new State(SpriteNum.SPR_BFE2, 32770, 8, null, StateNum.S_BFGEXP4),
    new State(SpriteNum.SPR_BFE2, 32771, 8, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_MISL, 32769, 8, ActionTable.A_Explode, StateNum.S_EXPLODE2),
    new State(SpriteNum.SPR_MISL, 32770, 6, null, StateNum.S_EXPLODE3),
    new State(SpriteNum.SPR_MISL, 32771, 4, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_TFOG, 32768, 6, null, StateNum.S_TFOG01),
    new State(SpriteNum.SPR_TFOG, 32769, 6, null, StateNum.S_TFOG02),
    new State(SpriteNum.SPR_TFOG, 32768, 6, null, StateNum.S_TFOG2),
    new State(SpriteNum.SPR_TFOG, 32769, 6, null, StateNum.S_TFOG3),
    new State(SpriteNum.SPR_TFOG, 32770, 6, null, StateNum.S_TFOG4),
    new State(SpriteNum.SPR_TFOG, 32771, 6, null, StateNum.S_TFOG5),
    new State(SpriteNum.SPR_TFOG, 32772, 6, null, StateNum.S_TFOG6),
    new State(SpriteNum.SPR_TFOG, 32773, 6, null, StateNum.S_TFOG7),
    new State(SpriteNum.SPR_TFOG, 32774, 6, null, StateNum.S_TFOG8),
    new State(SpriteNum.SPR_TFOG, 32775, 6, null, StateNum.S_TFOG9),
    new State(SpriteNum.SPR_TFOG, 32776, 6, null, StateNum.S_TFOG10),
    new State(SpriteNum.SPR_TFOG, 32777, 6, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_IFOG, 32768, 6, null, StateNum.S_IFOG01),
    new State(SpriteNum.SPR_IFOG, 32769, 6, null, StateNum.S_IFOG02),
    new State(SpriteNum.SPR_IFOG, 32768, 6, null, StateNum.S_IFOG2),
    new State(SpriteNum.SPR_IFOG, 32769, 6, null, StateNum.S_IFOG3),
    new State(SpriteNum.SPR_IFOG, 32770, 6, null, StateNum.S_IFOG4),
    new State(SpriteNum.SPR_IFOG, 32771, 6, null, StateNum.S_IFOG5),
    new State(SpriteNum.SPR_IFOG, 32772, 6, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_PLAY, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_PLAY, 0, 4, null, StateNum.S_PLAY_RUN2),
    new State(SpriteNum.SPR_PLAY, 1, 4, null, StateNum.S_PLAY_RUN3),
    new State(SpriteNum.SPR_PLAY, 2, 4, null, StateNum.S_PLAY_RUN4),
    new State(SpriteNum.SPR_PLAY, 3, 4, null, StateNum.S_PLAY_RUN1),
    new State(SpriteNum.SPR_PLAY, 4, 12, null, StateNum.S_PLAY),
    new State(SpriteNum.SPR_PLAY, 32773, 6, null, StateNum.S_PLAY_ATK1),
    new State(SpriteNum.SPR_PLAY, 6, 4, null, StateNum.S_PLAY_PAIN2),
    new State(SpriteNum.SPR_PLAY, 6, 4, ActionTable.A_Pain, StateNum.S_PLAY),
    new State(SpriteNum.SPR_PLAY, 7, 10, null, StateNum.S_PLAY_DIE2),
    new State(SpriteNum.SPR_PLAY, 8, 10, ActionTable.A_PlayerScream, StateNum.S_PLAY_DIE3),
    new State(SpriteNum.SPR_PLAY, 9, 10, ActionTable.A_Fall, StateNum.S_PLAY_DIE4),
    new State(SpriteNum.SPR_PLAY, 10, 10, null, StateNum.S_PLAY_DIE5),
    new State(SpriteNum.SPR_PLAY, 11, 10, null, StateNum.S_PLAY_DIE6),
    new State(SpriteNum.SPR_PLAY, 12, 10, null, StateNum.S_PLAY_DIE7),
    new State(SpriteNum.SPR_PLAY, 13, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_PLAY, 14, 5, null, StateNum.S_PLAY_XDIE2),
    new State(SpriteNum.SPR_PLAY, 15, 5, ActionTable.A_XScream, StateNum.S_PLAY_XDIE3),
    new State(SpriteNum.SPR_PLAY, 16, 5, ActionTable.A_Fall, StateNum.S_PLAY_XDIE4),
    new State(SpriteNum.SPR_PLAY, 17, 5, null, StateNum.S_PLAY_XDIE5),
    new State(SpriteNum.SPR_PLAY, 18, 5, null, StateNum.S_PLAY_XDIE6),
    new State(SpriteNum.SPR_PLAY, 19, 5, null, StateNum.S_PLAY_XDIE7),
    new State(SpriteNum.SPR_PLAY, 20, 5, null, StateNum.S_PLAY_XDIE8),
    new State(SpriteNum.SPR_PLAY, 21, 5, null, StateNum.S_PLAY_XDIE9),
    new State(SpriteNum.SPR_PLAY, 22, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_POSS, 0, 10, ActionTable.A_Look, StateNum.S_POSS_STND2),
    new State(SpriteNum.SPR_POSS, 1, 10, ActionTable.A_Look, StateNum.S_POSS_STND),
    new State(SpriteNum.SPR_POSS, 0, 4, ActionTable.A_Chase, StateNum.S_POSS_RUN2),
    new State(SpriteNum.SPR_POSS, 0, 4, ActionTable.A_Chase, StateNum.S_POSS_RUN3),
    new State(SpriteNum.SPR_POSS, 1, 4, ActionTable.A_Chase, StateNum.S_POSS_RUN4),
    new State(SpriteNum.SPR_POSS, 1, 4, ActionTable.A_Chase, StateNum.S_POSS_RUN5),
    new State(SpriteNum.SPR_POSS, 2, 4, ActionTable.A_Chase, StateNum.S_POSS_RUN6),
    new State(SpriteNum.SPR_POSS, 2, 4, ActionTable.A_Chase, StateNum.S_POSS_RUN7),
    new State(SpriteNum.SPR_POSS, 3, 4, ActionTable.A_Chase, StateNum.S_POSS_RUN8),
    new State(SpriteNum.SPR_POSS, 3, 4, ActionTable.A_Chase, StateNum.S_POSS_RUN1),
    new State(SpriteNum.SPR_POSS, 4, 10, ActionTable.A_FaceTarget, StateNum.S_POSS_ATK2),
    new State(SpriteNum.SPR_POSS, 5, 8, ActionTable.A_PosAttack, StateNum.S_POSS_ATK3),
    new State(SpriteNum.SPR_POSS, 4, 8, null, StateNum.S_POSS_RUN1),
    new State(SpriteNum.SPR_POSS, 6, 3, null, StateNum.S_POSS_PAIN2),
    new State(SpriteNum.SPR_POSS, 6, 3, ActionTable.A_Pain, StateNum.S_POSS_RUN1),
    new State(SpriteNum.SPR_POSS, 7, 5, null, StateNum.S_POSS_DIE2),
    new State(SpriteNum.SPR_POSS, 8, 5, ActionTable.A_Scream, StateNum.S_POSS_DIE3),
    new State(SpriteNum.SPR_POSS, 9, 5, ActionTable.A_Fall, StateNum.S_POSS_DIE4),
    new State(SpriteNum.SPR_POSS, 10, 5, null, StateNum.S_POSS_DIE5),
    new State(SpriteNum.SPR_POSS, 11, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_POSS, 12, 5, null, StateNum.S_POSS_XDIE2),
    new State(SpriteNum.SPR_POSS, 13, 5, ActionTable.A_XScream, StateNum.S_POSS_XDIE3),
    new State(SpriteNum.SPR_POSS, 14, 5, ActionTable.A_Fall, StateNum.S_POSS_XDIE4),
    new State(SpriteNum.SPR_POSS, 15, 5, null, StateNum.S_POSS_XDIE5),
    new State(SpriteNum.SPR_POSS, 16, 5, null, StateNum.S_POSS_XDIE6),
    new State(SpriteNum.SPR_POSS, 17, 5, null, StateNum.S_POSS_XDIE7),
    new State(SpriteNum.SPR_POSS, 18, 5, null, StateNum.S_POSS_XDIE8),
    new State(SpriteNum.SPR_POSS, 19, 5, null, StateNum.S_POSS_XDIE9),
    new State(SpriteNum.SPR_POSS, 20, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_POSS, 10, 5, null, StateNum.S_POSS_RAISE2),
    new State(SpriteNum.SPR_POSS, 9, 5, null, StateNum.S_POSS_RAISE3),
    new State(SpriteNum.SPR_POSS, 8, 5, null, StateNum.S_POSS_RAISE4),
    new State(SpriteNum.SPR_POSS, 7, 5, null, StateNum.S_POSS_RUN1),
    new State(SpriteNum.SPR_SPOS, 0, 10, ActionTable.A_Look, StateNum.S_SPOS_STND2),
    new State(SpriteNum.SPR_SPOS, 1, 10, ActionTable.A_Look, StateNum.S_SPOS_STND),
    new State(SpriteNum.SPR_SPOS, 0, 3, ActionTable.A_Chase, StateNum.S_SPOS_RUN2),
    new State(SpriteNum.SPR_SPOS, 0, 3, ActionTable.A_Chase, StateNum.S_SPOS_RUN3),
    new State(SpriteNum.SPR_SPOS, 1, 3, ActionTable.A_Chase, StateNum.S_SPOS_RUN4),
    new State(SpriteNum.SPR_SPOS, 1, 3, ActionTable.A_Chase, StateNum.S_SPOS_RUN5),
    new State(SpriteNum.SPR_SPOS, 2, 3, ActionTable.A_Chase, StateNum.S_SPOS_RUN6),
    new State(SpriteNum.SPR_SPOS, 2, 3, ActionTable.A_Chase, StateNum.S_SPOS_RUN7),
    new State(SpriteNum.SPR_SPOS, 3, 3, ActionTable.A_Chase, StateNum.S_SPOS_RUN8),
    new State(SpriteNum.SPR_SPOS, 3, 3, ActionTable.A_Chase, StateNum.S_SPOS_RUN1),
    new State(SpriteNum.SPR_SPOS, 4, 10, ActionTable.A_FaceTarget, StateNum.S_SPOS_ATK2),
    new State(SpriteNum.SPR_SPOS, 32773, 10, ActionTable.A_SPosAttack, StateNum.S_SPOS_ATK3),
    new State(SpriteNum.SPR_SPOS, 4, 10, null, StateNum.S_SPOS_RUN1),
    new State(SpriteNum.SPR_SPOS, 6, 3, null, StateNum.S_SPOS_PAIN2),
    new State(SpriteNum.SPR_SPOS, 6, 3, ActionTable.A_Pain, StateNum.S_SPOS_RUN1),
    new State(SpriteNum.SPR_SPOS, 7, 5, null, StateNum.S_SPOS_DIE2),
    new State(SpriteNum.SPR_SPOS, 8, 5, ActionTable.A_Scream, StateNum.S_SPOS_DIE3),
    new State(SpriteNum.SPR_SPOS, 9, 5, ActionTable.A_Fall, StateNum.S_SPOS_DIE4),
    new State(SpriteNum.SPR_SPOS, 10, 5, null, StateNum.S_SPOS_DIE5),
    new State(SpriteNum.SPR_SPOS, 11, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SPOS, 12, 5, null, StateNum.S_SPOS_XDIE2),
    new State(SpriteNum.SPR_SPOS, 13, 5, ActionTable.A_XScream, StateNum.S_SPOS_XDIE3),
    new State(SpriteNum.SPR_SPOS, 14, 5, ActionTable.A_Fall, StateNum.S_SPOS_XDIE4),
    new State(SpriteNum.SPR_SPOS, 15, 5, null, StateNum.S_SPOS_XDIE5),
    new State(SpriteNum.SPR_SPOS, 16, 5, null, StateNum.S_SPOS_XDIE6),
    new State(SpriteNum.SPR_SPOS, 17, 5, null, StateNum.S_SPOS_XDIE7),
    new State(SpriteNum.SPR_SPOS, 18, 5, null, StateNum.S_SPOS_XDIE8),
    new State(SpriteNum.SPR_SPOS, 19, 5, null, StateNum.S_SPOS_XDIE9),
    new State(SpriteNum.SPR_SPOS, 20, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SPOS, 11, 5, null, StateNum.S_SPOS_RAISE2),
    new State(SpriteNum.SPR_SPOS, 10, 5, null, StateNum.S_SPOS_RAISE3),
    new State(SpriteNum.SPR_SPOS, 9, 5, null, StateNum.S_SPOS_RAISE4),
    new State(SpriteNum.SPR_SPOS, 8, 5, null, StateNum.S_SPOS_RAISE5),
    new State(SpriteNum.SPR_SPOS, 7, 5, null, StateNum.S_SPOS_RUN1),
    new State(SpriteNum.SPR_VILE, 0, 10, ActionTable.A_Look, StateNum.S_VILE_STND2),
    new State(SpriteNum.SPR_VILE, 1, 10, ActionTable.A_Look, StateNum.S_VILE_STND),
    new State(SpriteNum.SPR_VILE, 0, 2, ActionTable.A_VileChase, StateNum.S_VILE_RUN2),
    new State(SpriteNum.SPR_VILE, 0, 2, ActionTable.A_VileChase, StateNum.S_VILE_RUN3),
    new State(SpriteNum.SPR_VILE, 1, 2, ActionTable.A_VileChase, StateNum.S_VILE_RUN4),
    new State(SpriteNum.SPR_VILE, 1, 2, ActionTable.A_VileChase, StateNum.S_VILE_RUN5),
    new State(SpriteNum.SPR_VILE, 2, 2, ActionTable.A_VileChase, StateNum.S_VILE_RUN6),
    new State(SpriteNum.SPR_VILE, 2, 2, ActionTable.A_VileChase, StateNum.S_VILE_RUN7),
    new State(SpriteNum.SPR_VILE, 3, 2, ActionTable.A_VileChase, StateNum.S_VILE_RUN8),
    new State(SpriteNum.SPR_VILE, 3, 2, ActionTable.A_VileChase, StateNum.S_VILE_RUN9),
    new State(SpriteNum.SPR_VILE, 4, 2, ActionTable.A_VileChase, StateNum.S_VILE_RUN10),
    new State(SpriteNum.SPR_VILE, 4, 2, ActionTable.A_VileChase, StateNum.S_VILE_RUN11),
    new State(SpriteNum.SPR_VILE, 5, 2, ActionTable.A_VileChase, StateNum.S_VILE_RUN12),
    new State(SpriteNum.SPR_VILE, 5, 2, ActionTable.A_VileChase, StateNum.S_VILE_RUN1),
    new State(SpriteNum.SPR_VILE, 32774, 0, ActionTable.A_VileStart, StateNum.S_VILE_ATK2),
    new State(SpriteNum.SPR_VILE, 32774, 10, ActionTable.A_FaceTarget, StateNum.S_VILE_ATK3),
    new State(SpriteNum.SPR_VILE, 32775, 8, ActionTable.A_VileTarget, StateNum.S_VILE_ATK4),
    new State(SpriteNum.SPR_VILE, 32776, 8, ActionTable.A_FaceTarget, StateNum.S_VILE_ATK5),
    new State(SpriteNum.SPR_VILE, 32777, 8, ActionTable.A_FaceTarget, StateNum.S_VILE_ATK6),
    new State(SpriteNum.SPR_VILE, 32778, 8, ActionTable.A_FaceTarget, StateNum.S_VILE_ATK7),
    new State(SpriteNum.SPR_VILE, 32779, 8, ActionTable.A_FaceTarget, StateNum.S_VILE_ATK8),
    new State(SpriteNum.SPR_VILE, 32780, 8, ActionTable.A_FaceTarget, StateNum.S_VILE_ATK9),
    new State(SpriteNum.SPR_VILE, 32781, 8, ActionTable.A_FaceTarget, StateNum.S_VILE_ATK10),
    new State(SpriteNum.SPR_VILE, 32782, 8, ActionTable.A_VileAttack, StateNum.S_VILE_ATK11),
    new State(SpriteNum.SPR_VILE, 32783, 20, null, StateNum.S_VILE_RUN1),
    new State(SpriteNum.SPR_VILE, 32794, 10, null, StateNum.S_VILE_HEAL2),
    new State(SpriteNum.SPR_VILE, 32795, 10, null, StateNum.S_VILE_HEAL3),
    new State(SpriteNum.SPR_VILE, 32796, 10, null, StateNum.S_VILE_RUN1),
    new State(SpriteNum.SPR_VILE, 16, 5, null, StateNum.S_VILE_PAIN2),
    new State(SpriteNum.SPR_VILE, 16, 5, ActionTable.A_Pain, StateNum.S_VILE_RUN1),
    new State(SpriteNum.SPR_VILE, 16, 7, null, StateNum.S_VILE_DIE2),
    new State(SpriteNum.SPR_VILE, 17, 7, ActionTable.A_Scream, StateNum.S_VILE_DIE3),
    new State(SpriteNum.SPR_VILE, 18, 7, ActionTable.A_Fall, StateNum.S_VILE_DIE4),
    new State(SpriteNum.SPR_VILE, 19, 7, null, StateNum.S_VILE_DIE5),
    new State(SpriteNum.SPR_VILE, 20, 7, null, StateNum.S_VILE_DIE6),
    new State(SpriteNum.SPR_VILE, 21, 7, null, StateNum.S_VILE_DIE7),
    new State(SpriteNum.SPR_VILE, 22, 7, null, StateNum.S_VILE_DIE8),
    new State(SpriteNum.SPR_VILE, 23, 5, null, StateNum.S_VILE_DIE9),
    new State(SpriteNum.SPR_VILE, 24, 5, null, StateNum.S_VILE_DIE10),
    new State(SpriteNum.SPR_VILE, 25, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_FIRE, 32768, 2, ActionTable.A_StartFire, StateNum.S_FIRE2),
    new State(SpriteNum.SPR_FIRE, 32769, 2, ActionTable.A_Fire, StateNum.S_FIRE3),
    new State(SpriteNum.SPR_FIRE, 32768, 2, ActionTable.A_Fire, StateNum.S_FIRE4),
    new State(SpriteNum.SPR_FIRE, 32769, 2, ActionTable.A_Fire, StateNum.S_FIRE5),
    new State(SpriteNum.SPR_FIRE, 32770, 2, ActionTable.A_FireCrackle, StateNum.S_FIRE6),
    new State(SpriteNum.SPR_FIRE, 32769, 2, ActionTable.A_Fire, StateNum.S_FIRE7),
    new State(SpriteNum.SPR_FIRE, 32770, 2, ActionTable.A_Fire, StateNum.S_FIRE8),
    new State(SpriteNum.SPR_FIRE, 32769, 2, ActionTable.A_Fire, StateNum.S_FIRE9),
    new State(SpriteNum.SPR_FIRE, 32770, 2, ActionTable.A_Fire, StateNum.S_FIRE10),
    new State(SpriteNum.SPR_FIRE, 32771, 2, ActionTable.A_Fire, StateNum.S_FIRE11),
    new State(SpriteNum.SPR_FIRE, 32770, 2, ActionTable.A_Fire, StateNum.S_FIRE12),
    new State(SpriteNum.SPR_FIRE, 32771, 2, ActionTable.A_Fire, StateNum.S_FIRE13),
    new State(SpriteNum.SPR_FIRE, 32770, 2, ActionTable.A_Fire, StateNum.S_FIRE14),
    new State(SpriteNum.SPR_FIRE, 32771, 2, ActionTable.A_Fire, StateNum.S_FIRE15),
    new State(SpriteNum.SPR_FIRE, 32772, 2, ActionTable.A_Fire, StateNum.S_FIRE16),
    new State(SpriteNum.SPR_FIRE, 32771, 2, ActionTable.A_Fire, StateNum.S_FIRE17),
    new State(SpriteNum.SPR_FIRE, 32772, 2, ActionTable.A_Fire, StateNum.S_FIRE18),
    new State(SpriteNum.SPR_FIRE, 32771, 2, ActionTable.A_Fire, StateNum.S_FIRE19),
    new State(SpriteNum.SPR_FIRE, 32772, 2, ActionTable.A_FireCrackle, StateNum.S_FIRE20),
    new State(SpriteNum.SPR_FIRE, 32773, 2, ActionTable.A_Fire, StateNum.S_FIRE21),
    new State(SpriteNum.SPR_FIRE, 32772, 2, ActionTable.A_Fire, StateNum.S_FIRE22),
    new State(SpriteNum.SPR_FIRE, 32773, 2, ActionTable.A_Fire, StateNum.S_FIRE23),
    new State(SpriteNum.SPR_FIRE, 32772, 2, ActionTable.A_Fire, StateNum.S_FIRE24),
    new State(SpriteNum.SPR_FIRE, 32773, 2, ActionTable.A_Fire, StateNum.S_FIRE25),
    new State(SpriteNum.SPR_FIRE, 32774, 2, ActionTable.A_Fire, StateNum.S_FIRE26),
    new State(SpriteNum.SPR_FIRE, 32775, 2, ActionTable.A_Fire, StateNum.S_FIRE27),
    new State(SpriteNum.SPR_FIRE, 32774, 2, ActionTable.A_Fire, StateNum.S_FIRE28),
    new State(SpriteNum.SPR_FIRE, 32775, 2, ActionTable.A_Fire, StateNum.S_FIRE29),
    new State(SpriteNum.SPR_FIRE, 32774, 2, ActionTable.A_Fire, StateNum.S_FIRE30),
    new State(SpriteNum.SPR_FIRE, 32775, 2, ActionTable.A_Fire, StateNum.S_NULL),
    new State(SpriteNum.SPR_PUFF, 1, 4, null, StateNum.S_SMOKE2),
    new State(SpriteNum.SPR_PUFF, 2, 4, null, StateNum.S_SMOKE3),
    new State(SpriteNum.SPR_PUFF, 1, 4, null, StateNum.S_SMOKE4),
    new State(SpriteNum.SPR_PUFF, 2, 4, null, StateNum.S_SMOKE5),
    new State(SpriteNum.SPR_PUFF, 3, 4, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_FATB, 32768, 2, ActionTable.A_Tracer, StateNum.S_TRACER2),
    new State(SpriteNum.SPR_FATB, 32769, 2, ActionTable.A_Tracer, StateNum.S_TRACER),
    new State(SpriteNum.SPR_FBXP, 32768, 8, null, StateNum.S_TRACEEXP2),
    new State(SpriteNum.SPR_FBXP, 32769, 6, null, StateNum.S_TRACEEXP3),
    new State(SpriteNum.SPR_FBXP, 32770, 4, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SKEL, 0, 10, ActionTable.A_Look, StateNum.S_SKEL_STND2),
    new State(SpriteNum.SPR_SKEL, 1, 10, ActionTable.A_Look, StateNum.S_SKEL_STND),
    new State(SpriteNum.SPR_SKEL, 0, 2, ActionTable.A_Chase, StateNum.S_SKEL_RUN2),
    new State(SpriteNum.SPR_SKEL, 0, 2, ActionTable.A_Chase, StateNum.S_SKEL_RUN3),
    new State(SpriteNum.SPR_SKEL, 1, 2, ActionTable.A_Chase, StateNum.S_SKEL_RUN4),
    new State(SpriteNum.SPR_SKEL, 1, 2, ActionTable.A_Chase, StateNum.S_SKEL_RUN5),
    new State(SpriteNum.SPR_SKEL, 2, 2, ActionTable.A_Chase, StateNum.S_SKEL_RUN6),
    new State(SpriteNum.SPR_SKEL, 2, 2, ActionTable.A_Chase, StateNum.S_SKEL_RUN7),
    new State(SpriteNum.SPR_SKEL, 3, 2, ActionTable.A_Chase, StateNum.S_SKEL_RUN8),
    new State(SpriteNum.SPR_SKEL, 3, 2, ActionTable.A_Chase, StateNum.S_SKEL_RUN9),
    new State(SpriteNum.SPR_SKEL, 4, 2, ActionTable.A_Chase, StateNum.S_SKEL_RUN10),
    new State(SpriteNum.SPR_SKEL, 4, 2, ActionTable.A_Chase, StateNum.S_SKEL_RUN11),
    new State(SpriteNum.SPR_SKEL, 5, 2, ActionTable.A_Chase, StateNum.S_SKEL_RUN12),
    new State(SpriteNum.SPR_SKEL, 5, 2, ActionTable.A_Chase, StateNum.S_SKEL_RUN1),
    new State(SpriteNum.SPR_SKEL, 6, 0, ActionTable.A_FaceTarget, StateNum.S_SKEL_FIST2),
    new State(SpriteNum.SPR_SKEL, 6, 6, ActionTable.A_SkelWhoosh, StateNum.S_SKEL_FIST3),
    new State(SpriteNum.SPR_SKEL, 7, 6, ActionTable.A_FaceTarget, StateNum.S_SKEL_FIST4),
    new State(SpriteNum.SPR_SKEL, 8, 6, ActionTable.A_SkelFist, StateNum.S_SKEL_RUN1),
    new State(SpriteNum.SPR_SKEL, 32777, 0, ActionTable.A_FaceTarget, StateNum.S_SKEL_MISS2),
    new State(SpriteNum.SPR_SKEL, 32777, 10, ActionTable.A_FaceTarget, StateNum.S_SKEL_MISS3),
    new State(SpriteNum.SPR_SKEL, 10, 10, ActionTable.A_SkelMissile, StateNum.S_SKEL_MISS4),
    new State(SpriteNum.SPR_SKEL, 10, 10, ActionTable.A_FaceTarget, StateNum.S_SKEL_RUN1),
    new State(SpriteNum.SPR_SKEL, 11, 5, null, StateNum.S_SKEL_PAIN2),
    new State(SpriteNum.SPR_SKEL, 11, 5, ActionTable.A_Pain, StateNum.S_SKEL_RUN1),
    new State(SpriteNum.SPR_SKEL, 11, 7, null, StateNum.S_SKEL_DIE2),
    new State(SpriteNum.SPR_SKEL, 12, 7, null, StateNum.S_SKEL_DIE3),
    new State(SpriteNum.SPR_SKEL, 13, 7, ActionTable.A_Scream, StateNum.S_SKEL_DIE4),
    new State(SpriteNum.SPR_SKEL, 14, 7, ActionTable.A_Fall, StateNum.S_SKEL_DIE5),
    new State(SpriteNum.SPR_SKEL, 15, 7, null, StateNum.S_SKEL_DIE6),
    new State(SpriteNum.SPR_SKEL, 16, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SKEL, 16, 5, null, StateNum.S_SKEL_RAISE2),
    new State(SpriteNum.SPR_SKEL, 15, 5, null, StateNum.S_SKEL_RAISE3),
    new State(SpriteNum.SPR_SKEL, 14, 5, null, StateNum.S_SKEL_RAISE4),
    new State(SpriteNum.SPR_SKEL, 13, 5, null, StateNum.S_SKEL_RAISE5),
    new State(SpriteNum.SPR_SKEL, 12, 5, null, StateNum.S_SKEL_RAISE6),
    new State(SpriteNum.SPR_SKEL, 11, 5, null, StateNum.S_SKEL_RUN1),
    new State(SpriteNum.SPR_MANF, 32768, 4, null, StateNum.S_FATSHOT2),
    new State(SpriteNum.SPR_MANF, 32769, 4, null, StateNum.S_FATSHOT1),
    new State(SpriteNum.SPR_MISL, 32769, 8, null, StateNum.S_FATSHOTX2),
    new State(SpriteNum.SPR_MISL, 32770, 6, null, StateNum.S_FATSHOTX3),
    new State(SpriteNum.SPR_MISL, 32771, 4, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_FATT, 0, 15, ActionTable.A_Look, StateNum.S_FATT_STND2),
    new State(SpriteNum.SPR_FATT, 1, 15, ActionTable.A_Look, StateNum.S_FATT_STND),
    new State(SpriteNum.SPR_FATT, 0, 4, ActionTable.A_Chase, StateNum.S_FATT_RUN2),
    new State(SpriteNum.SPR_FATT, 0, 4, ActionTable.A_Chase, StateNum.S_FATT_RUN3),
    new State(SpriteNum.SPR_FATT, 1, 4, ActionTable.A_Chase, StateNum.S_FATT_RUN4),
    new State(SpriteNum.SPR_FATT, 1, 4, ActionTable.A_Chase, StateNum.S_FATT_RUN5),
    new State(SpriteNum.SPR_FATT, 2, 4, ActionTable.A_Chase, StateNum.S_FATT_RUN6),
    new State(SpriteNum.SPR_FATT, 2, 4, ActionTable.A_Chase, StateNum.S_FATT_RUN7),
    new State(SpriteNum.SPR_FATT, 3, 4, ActionTable.A_Chase, StateNum.S_FATT_RUN8),
    new State(SpriteNum.SPR_FATT, 3, 4, ActionTable.A_Chase, StateNum.S_FATT_RUN9),
    new State(SpriteNum.SPR_FATT, 4, 4, ActionTable.A_Chase, StateNum.S_FATT_RUN10),
    new State(SpriteNum.SPR_FATT, 4, 4, ActionTable.A_Chase, StateNum.S_FATT_RUN11),
    new State(SpriteNum.SPR_FATT, 5, 4, ActionTable.A_Chase, StateNum.S_FATT_RUN12),
    new State(SpriteNum.SPR_FATT, 5, 4, ActionTable.A_Chase, StateNum.S_FATT_RUN1),
    new State(SpriteNum.SPR_FATT, 6, 20, ActionTable.A_FatRaise, StateNum.S_FATT_ATK2),
    new State(SpriteNum.SPR_FATT, 32775, 10, ActionTable.A_FatAttack1, StateNum.S_FATT_ATK3),
    new State(SpriteNum.SPR_FATT, 8, 5, ActionTable.A_FaceTarget, StateNum.S_FATT_ATK4),
    new State(SpriteNum.SPR_FATT, 6, 5, ActionTable.A_FaceTarget, StateNum.S_FATT_ATK5),
    new State(SpriteNum.SPR_FATT, 32775, 10, ActionTable.A_FatAttack2, StateNum.S_FATT_ATK6),
    new State(SpriteNum.SPR_FATT, 8, 5, ActionTable.A_FaceTarget, StateNum.S_FATT_ATK7),
    new State(SpriteNum.SPR_FATT, 6, 5, ActionTable.A_FaceTarget, StateNum.S_FATT_ATK8),
    new State(SpriteNum.SPR_FATT, 32775, 10, ActionTable.A_FatAttack3, StateNum.S_FATT_ATK9),
    new State(SpriteNum.SPR_FATT, 8, 5, ActionTable.A_FaceTarget, StateNum.S_FATT_ATK10),
    new State(SpriteNum.SPR_FATT, 6, 5, ActionTable.A_FaceTarget, StateNum.S_FATT_RUN1),
    new State(SpriteNum.SPR_FATT, 9, 3, null, StateNum.S_FATT_PAIN2),
    new State(SpriteNum.SPR_FATT, 9, 3, ActionTable.A_Pain, StateNum.S_FATT_RUN1),
    new State(SpriteNum.SPR_FATT, 10, 6, null, StateNum.S_FATT_DIE2),
    new State(SpriteNum.SPR_FATT, 11, 6, ActionTable.A_Scream, StateNum.S_FATT_DIE3),
    new State(SpriteNum.SPR_FATT, 12, 6, ActionTable.A_Fall, StateNum.S_FATT_DIE4),
    new State(SpriteNum.SPR_FATT, 13, 6, null, StateNum.S_FATT_DIE5),
    new State(SpriteNum.SPR_FATT, 14, 6, null, StateNum.S_FATT_DIE6),
    new State(SpriteNum.SPR_FATT, 15, 6, null, StateNum.S_FATT_DIE7),
    new State(SpriteNum.SPR_FATT, 16, 6, null, StateNum.S_FATT_DIE8),
    new State(SpriteNum.SPR_FATT, 17, 6, null, StateNum.S_FATT_DIE9),
    new State(SpriteNum.SPR_FATT, 18, 6, null, StateNum.S_FATT_DIE10),
    new State(SpriteNum.SPR_FATT, 19, -1, ActionTable.A_BossDeath, StateNum.S_NULL),
    new State(SpriteNum.SPR_FATT, 17, 5, null, StateNum.S_FATT_RAISE2),
    new State(SpriteNum.SPR_FATT, 16, 5, null, StateNum.S_FATT_RAISE3),
    new State(SpriteNum.SPR_FATT, 15, 5, null, StateNum.S_FATT_RAISE4),
    new State(SpriteNum.SPR_FATT, 14, 5, null, StateNum.S_FATT_RAISE5),
    new State(SpriteNum.SPR_FATT, 13, 5, null, StateNum.S_FATT_RAISE6),
    new State(SpriteNum.SPR_FATT, 12, 5, null, StateNum.S_FATT_RAISE7),
    new State(SpriteNum.SPR_FATT, 11, 5, null, StateNum.S_FATT_RAISE8),
    new State(SpriteNum.SPR_FATT, 10, 5, null, StateNum.S_FATT_RUN1),
    new State(SpriteNum.SPR_CPOS, 0, 10, ActionTable.A_Look, StateNum.S_CPOS_STND2),
    new State(SpriteNum.SPR_CPOS, 1, 10, ActionTable.A_Look, StateNum.S_CPOS_STND),
    new State(SpriteNum.SPR_CPOS, 0, 3, ActionTable.A_Chase, StateNum.S_CPOS_RUN2),
    new State(SpriteNum.SPR_CPOS, 0, 3, ActionTable.A_Chase, StateNum.S_CPOS_RUN3),
    new State(SpriteNum.SPR_CPOS, 1, 3, ActionTable.A_Chase, StateNum.S_CPOS_RUN4),
    new State(SpriteNum.SPR_CPOS, 1, 3, ActionTable.A_Chase, StateNum.S_CPOS_RUN5),
    new State(SpriteNum.SPR_CPOS, 2, 3, ActionTable.A_Chase, StateNum.S_CPOS_RUN6),
    new State(SpriteNum.SPR_CPOS, 2, 3, ActionTable.A_Chase, StateNum.S_CPOS_RUN7),
    new State(SpriteNum.SPR_CPOS, 3, 3, ActionTable.A_Chase, StateNum.S_CPOS_RUN8),
    new State(SpriteNum.SPR_CPOS, 3, 3, ActionTable.A_Chase, StateNum.S_CPOS_RUN1),
    new State(SpriteNum.SPR_CPOS, 4, 10, ActionTable.A_FaceTarget, StateNum.S_CPOS_ATK2),
    new State(SpriteNum.SPR_CPOS, 32773, 4, ActionTable.A_CPosAttack, StateNum.S_CPOS_ATK3),
    new State(SpriteNum.SPR_CPOS, 32772, 4, ActionTable.A_CPosAttack, StateNum.S_CPOS_ATK4),
    new State(SpriteNum.SPR_CPOS, 5, 1, ActionTable.A_CPosRefire, StateNum.S_CPOS_ATK2),
    new State(SpriteNum.SPR_CPOS, 6, 3, null, StateNum.S_CPOS_PAIN2),
    new State(SpriteNum.SPR_CPOS, 6, 3, ActionTable.A_Pain, StateNum.S_CPOS_RUN1),
    new State(SpriteNum.SPR_CPOS, 7, 5, null, StateNum.S_CPOS_DIE2),
    new State(SpriteNum.SPR_CPOS, 8, 5, ActionTable.A_Scream, StateNum.S_CPOS_DIE3),
    new State(SpriteNum.SPR_CPOS, 9, 5, ActionTable.A_Fall, StateNum.S_CPOS_DIE4),
    new State(SpriteNum.SPR_CPOS, 10, 5, null, StateNum.S_CPOS_DIE5),
    new State(SpriteNum.SPR_CPOS, 11, 5, null, StateNum.S_CPOS_DIE6),
    new State(SpriteNum.SPR_CPOS, 12, 5, null, StateNum.S_CPOS_DIE7),
    new State(SpriteNum.SPR_CPOS, 13, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_CPOS, 14, 5, null, StateNum.S_CPOS_XDIE2),
    new State(SpriteNum.SPR_CPOS, 15, 5, ActionTable.A_XScream, StateNum.S_CPOS_XDIE3),
    new State(SpriteNum.SPR_CPOS, 16, 5, ActionTable.A_Fall, StateNum.S_CPOS_XDIE4),
    new State(SpriteNum.SPR_CPOS, 17, 5, null, StateNum.S_CPOS_XDIE5),
    new State(SpriteNum.SPR_CPOS, 18, 5, null, StateNum.S_CPOS_XDIE6),
    new State(SpriteNum.SPR_CPOS, 19, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_CPOS, 13, 5, null, StateNum.S_CPOS_RAISE2),
    new State(SpriteNum.SPR_CPOS, 12, 5, null, StateNum.S_CPOS_RAISE3),
    new State(SpriteNum.SPR_CPOS, 11, 5, null, StateNum.S_CPOS_RAISE4),
    new State(SpriteNum.SPR_CPOS, 10, 5, null, StateNum.S_CPOS_RAISE5),
    new State(SpriteNum.SPR_CPOS, 9, 5, null, StateNum.S_CPOS_RAISE6),
    new State(SpriteNum.SPR_CPOS, 8, 5, null, StateNum.S_CPOS_RAISE7),
    new State(SpriteNum.SPR_CPOS, 7, 5, null, StateNum.S_CPOS_RUN1),
    new State(SpriteNum.SPR_TROO, 0, 10, ActionTable.A_Look, StateNum.S_TROO_STND2),
    new State(SpriteNum.SPR_TROO, 1, 10, ActionTable.A_Look, StateNum.S_TROO_STND),
    new State(SpriteNum.SPR_TROO, 0, 3, ActionTable.A_Chase, StateNum.S_TROO_RUN2),
    new State(SpriteNum.SPR_TROO, 0, 3, ActionTable.A_Chase, StateNum.S_TROO_RUN3),
    new State(SpriteNum.SPR_TROO, 1, 3, ActionTable.A_Chase, StateNum.S_TROO_RUN4),
    new State(SpriteNum.SPR_TROO, 1, 3, ActionTable.A_Chase, StateNum.S_TROO_RUN5),
    new State(SpriteNum.SPR_TROO, 2, 3, ActionTable.A_Chase, StateNum.S_TROO_RUN6),
    new State(SpriteNum.SPR_TROO, 2, 3, ActionTable.A_Chase, StateNum.S_TROO_RUN7),
    new State(SpriteNum.SPR_TROO, 3, 3, ActionTable.A_Chase, StateNum.S_TROO_RUN8),
    new State(SpriteNum.SPR_TROO, 3, 3, ActionTable.A_Chase, StateNum.S_TROO_RUN1),
    new State(SpriteNum.SPR_TROO, 4, 8, ActionTable.A_FaceTarget, StateNum.S_TROO_ATK2),
    new State(SpriteNum.SPR_TROO, 5, 8, ActionTable.A_FaceTarget, StateNum.S_TROO_ATK3),
    new State(SpriteNum.SPR_TROO, 6, 6, ActionTable.A_TroopAttack, StateNum.S_TROO_RUN1),
    new State(SpriteNum.SPR_TROO, 7, 2, null, StateNum.S_TROO_PAIN2),
    new State(SpriteNum.SPR_TROO, 7, 2, ActionTable.A_Pain, StateNum.S_TROO_RUN1),
    new State(SpriteNum.SPR_TROO, 8, 8, null, StateNum.S_TROO_DIE2),
    new State(SpriteNum.SPR_TROO, 9, 8, ActionTable.A_Scream, StateNum.S_TROO_DIE3),
    new State(SpriteNum.SPR_TROO, 10, 6, null, StateNum.S_TROO_DIE4),
    new State(SpriteNum.SPR_TROO, 11, 6, ActionTable.A_FALL, StateNum.S_TROO_DIE5),
    new State(SpriteNum.SPR_TROO, 12, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_TROO, 13, 5, null, StateNum.S_TROO_XDIE2),
    new State(SpriteNum.SPR_TROO, 14, 5, ActionTable.A_XScream, StateNum.S_TROO_XDIE3),
    new State(SpriteNum.SPR_TROO, 15, 5, null, StateNum.S_TROO_XDIE4),
    new State(SpriteNum.SPR_TROO, 16, 5, ActionTable.A_FALL, StateNum.S_TROO_XDIE5),
    new State(SpriteNum.SPR_TROO, 17, 5, null, StateNum.S_TROO_XDIE6),
    new State(SpriteNum.SPR_TROO, 18, 5, null, StateNum.S_TROO_XDIE7),
    new State(SpriteNum.SPR_TROO, 19, 5, null, StateNum.S_TROO_XDIE8),
    new State(SpriteNum.SPR_TROO, 20, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_TROO, 12, 8, null, StateNum.S_TROO_RAISE2),
    new State(SpriteNum.SPR_TROO, 11, 8, null, StateNum.S_TROO_RAISE3),
    new State(SpriteNum.SPR_TROO, 10, 6, null, StateNum.S_TROO_RAISE4),
    new State(SpriteNum.SPR_TROO, 9, 6, null, StateNum.S_TROO_RAISE5),
    new State(SpriteNum.SPR_TROO, 8, 6, null, StateNum.S_TROO_RUN1),
    new State(SpriteNum.SPR_SARG, 0, 10, ActionTable.A_Look, StateNum.S_SARG_STND2),
    new State(SpriteNum.SPR_SARG, 1, 10, ActionTable.A_Look, StateNum.S_SARG_STND),
    new State(SpriteNum.SPR_SARG, 0, 2, ActionTable.A_Chase, StateNum.S_SARG_RUN2),
    new State(SpriteNum.SPR_SARG, 0, 2, ActionTable.A_Chase, StateNum.S_SARG_RUN3),
    new State(SpriteNum.SPR_SARG, 1, 2, ActionTable.A_Chase, StateNum.S_SARG_RUN4),
    new State(SpriteNum.SPR_SARG, 1, 2, ActionTable.A_Chase, StateNum.S_SARG_RUN5),
    new State(SpriteNum.SPR_SARG, 2, 2, ActionTable.A_Chase, StateNum.S_SARG_RUN6),
    new State(SpriteNum.SPR_SARG, 2, 2, ActionTable.A_Chase, StateNum.S_SARG_RUN7),
    new State(SpriteNum.SPR_SARG, 3, 2, ActionTable.A_Chase, StateNum.S_SARG_RUN8),
    new State(SpriteNum.SPR_SARG, 3, 2, ActionTable.A_Chase, StateNum.S_SARG_RUN1),
    new State(SpriteNum.SPR_SARG, 4, 8, ActionTable.A_FaceTarget, StateNum.S_SARG_ATK2),
    new State(SpriteNum.SPR_SARG, 5, 8, ActionTable.A_FaceTarget, StateNum.S_SARG_ATK3),
    new State(SpriteNum.SPR_SARG, 6, 8, ActionTable.A_SargAttack, StateNum.S_SARG_RUN1),
    new State(SpriteNum.SPR_SARG, 7, 2, null, StateNum.S_SARG_PAIN2),
    new State(SpriteNum.SPR_SARG, 7, 2, ActionTable.A_Pain, StateNum.S_SARG_RUN1),
    new State(SpriteNum.SPR_SARG, 8, 8, null, StateNum.S_SARG_DIE2),
    new State(SpriteNum.SPR_SARG, 9, 8, ActionTable.A_Scream, StateNum.S_SARG_DIE3),
    new State(SpriteNum.SPR_SARG, 10, 4, null, StateNum.S_SARG_DIE4),
    new State(SpriteNum.SPR_SARG, 11, 4, ActionTable.A_Fall, StateNum.S_SARG_DIE5),
    new State(SpriteNum.SPR_SARG, 12, 4, null, StateNum.S_SARG_DIE6),
    new State(SpriteNum.SPR_SARG, 13, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SARG, 13, 5, null, StateNum.S_SARG_RAISE2),
    new State(SpriteNum.SPR_SARG, 12, 5, null, StateNum.S_SARG_RAISE3),
    new State(SpriteNum.SPR_SARG, 11, 5, null, StateNum.S_SARG_RAISE4),
    new State(SpriteNum.SPR_SARG, 10, 5, null, StateNum.S_SARG_RAISE5),
    new State(SpriteNum.SPR_SARG, 9, 5, null, StateNum.S_SARG_RAISE6),
    new State(SpriteNum.SPR_SARG, 8, 5, null, StateNum.S_SARG_RUN1),
    new State(SpriteNum.SPR_HEAD, 0, 10, ActionTable.A_Look, StateNum.S_HEAD_STND),
    new State(SpriteNum.SPR_HEAD, 0, 3, ActionTable.A_Chase, StateNum.S_HEAD_RUN1),
    new State(SpriteNum.SPR_HEAD, 1, 5, ActionTable.A_FaceTarget, StateNum.S_HEAD_ATK2),
    new State(SpriteNum.SPR_HEAD, 2, 5, ActionTable.A_FaceTarget, StateNum.S_HEAD_ATK3),
    new State(SpriteNum.SPR_HEAD, 32771, 5, ActionTable.A_HeadAttack, StateNum.S_HEAD_RUN1),
    new State(SpriteNum.SPR_HEAD, 4, 3, null, StateNum.S_HEAD_PAIN2),
    new State(SpriteNum.SPR_HEAD, 4, 3, ActionTable.A_Pain, StateNum.S_HEAD_PAIN3),
    new State(SpriteNum.SPR_HEAD, 5, 6, null, StateNum.S_HEAD_RUN1),
    new State(SpriteNum.SPR_HEAD, 6, 8, null, StateNum.S_HEAD_DIE2),
    new State(SpriteNum.SPR_HEAD, 7, 8, ActionTable.A_Scream, StateNum.S_HEAD_DIE3),
    new State(SpriteNum.SPR_HEAD, 8, 8, null, StateNum.S_HEAD_DIE4),
    new State(SpriteNum.SPR_HEAD, 9, 8, null, StateNum.S_HEAD_DIE5),
    new State(SpriteNum.SPR_HEAD, 10, 8, ActionTable.A_Fall, StateNum.S_HEAD_DIE6),
    new State(SpriteNum.SPR_HEAD, 11, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_HEAD, 11, 8, null, StateNum.S_HEAD_RAISE2),
    new State(SpriteNum.SPR_HEAD, 10, 8, null, StateNum.S_HEAD_RAISE3),
    new State(SpriteNum.SPR_HEAD, 9, 8, null, StateNum.S_HEAD_RAISE4),
    new State(SpriteNum.SPR_HEAD, 8, 8, null, StateNum.S_HEAD_RAISE5),
    new State(SpriteNum.SPR_HEAD, 7, 8, null, StateNum.S_HEAD_RAISE6),
    new State(SpriteNum.SPR_HEAD, 6, 8, null, StateNum.S_HEAD_RUN1),
    new State(SpriteNum.SPR_BAL7, 32768, 4, null, StateNum.S_BRBALL2),
    new State(SpriteNum.SPR_BAL7, 32769, 4, null, StateNum.S_BRBALL1),
    new State(SpriteNum.SPR_BAL7, 32770, 6, null, StateNum.S_BRBALLX2),
    new State(SpriteNum.SPR_BAL7, 32771, 6, null, StateNum.S_BRBALLX3),
    new State(SpriteNum.SPR_BAL7, 32772, 6, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_BOSS, 0, 10, ActionTable.A_Look, StateNum.S_BOSS_STND2),
    new State(SpriteNum.SPR_BOSS, 1, 10, ActionTable.A_Look, StateNum.S_BOSS_STND),
    new State(SpriteNum.SPR_BOSS, 0, 3, ActionTable.A_Chase, StateNum.S_BOSS_RUN2),
    new State(SpriteNum.SPR_BOSS, 0, 3, ActionTable.A_Chase, StateNum.S_BOSS_RUN3),
    new State(SpriteNum.SPR_BOSS, 1, 3, ActionTable.A_Chase, StateNum.S_BOSS_RUN4),
    new State(SpriteNum.SPR_BOSS, 1, 3, ActionTable.A_Chase, StateNum.S_BOSS_RUN5),
    new State(SpriteNum.SPR_BOSS, 2, 3, ActionTable.A_Chase, StateNum.S_BOSS_RUN6),
    new State(SpriteNum.SPR_BOSS, 2, 3, ActionTable.A_Chase, StateNum.S_BOSS_RUN7),
    new State(SpriteNum.SPR_BOSS, 3, 3, ActionTable.A_Chase, StateNum.S_BOSS_RUN8),
    new State(SpriteNum.SPR_BOSS, 3, 3, ActionTable.A_Chase, StateNum.S_BOSS_RUN1),
    new State(SpriteNum.SPR_BOSS, 4, 8, ActionTable.A_FaceTarget, StateNum.S_BOSS_ATK2),
    new State(SpriteNum.SPR_BOSS, 5, 8, ActionTable.A_FaceTarget, StateNum.S_BOSS_ATK3),
    new State(SpriteNum.SPR_BOSS, 6, 8, ActionTable.A_BruisAttack, StateNum.S_BOSS_RUN1),
    new State(SpriteNum.SPR_BOSS, 7, 2, null, StateNum.S_BOSS_PAIN2),
    new State(SpriteNum.SPR_BOSS, 7, 2, ActionTable.A_Pain, StateNum.S_BOSS_RUN1),
    new State(SpriteNum.SPR_BOSS, 8, 8, null, StateNum.S_BOSS_DIE2),
    new State(SpriteNum.SPR_BOSS, 9, 8, ActionTable.A_Scream, StateNum.S_BOSS_DIE3),
    new State(SpriteNum.SPR_BOSS, 10, 8, null, StateNum.S_BOSS_DIE4),
    new State(SpriteNum.SPR_BOSS, 11, 8, ActionTable.A_Fall, StateNum.S_BOSS_DIE5),
    new State(SpriteNum.SPR_BOSS, 12, 8, null, StateNum.S_BOSS_DIE6),
    new State(SpriteNum.SPR_BOSS, 13, 8, null, StateNum.S_BOSS_DIE7),
    new State(SpriteNum.SPR_BOSS, 14, -1, ActionTable.A_BossDeath, StateNum.S_NULL),
    new State(SpriteNum.SPR_BOSS, 14, 8, null, StateNum.S_BOSS_RAISE2),
    new State(SpriteNum.SPR_BOSS, 13, 8, null, StateNum.S_BOSS_RAISE3),
    new State(SpriteNum.SPR_BOSS, 12, 8, null, StateNum.S_BOSS_RAISE4),
    new State(SpriteNum.SPR_BOSS, 11, 8, null, StateNum.S_BOSS_RAISE5),
    new State(SpriteNum.SPR_BOSS, 10, 8, null, StateNum.S_BOSS_RAISE6),
    new State(SpriteNum.SPR_BOSS, 9, 8, null, StateNum.S_BOSS_RAISE7),
    new State(SpriteNum.SPR_BOSS, 8, 8, null, StateNum.S_BOSS_RUN1),
    new State(SpriteNum.SPR_BOS2, 0, 10, ActionTable.A_Look, StateNum.S_BOS2_STND2),
    new State(SpriteNum.SPR_BOS2, 1, 10, ActionTable.A_Look, StateNum.S_BOS2_STND),
    new State(SpriteNum.SPR_BOS2, 0, 3, ActionTable.A_Chase, StateNum.S_BOS2_RUN2),
    new State(SpriteNum.SPR_BOS2, 0, 3, ActionTable.A_Chase, StateNum.S_BOS2_RUN3),
    new State(SpriteNum.SPR_BOS2, 1, 3, ActionTable.A_Chase, StateNum.S_BOS2_RUN4),
    new State(SpriteNum.SPR_BOS2, 1, 3, ActionTable.A_Chase, StateNum.S_BOS2_RUN5),
    new State(SpriteNum.SPR_BOS2, 2, 3, ActionTable.A_Chase, StateNum.S_BOS2_RUN6),
    new State(SpriteNum.SPR_BOS2, 2, 3, ActionTable.A_Chase, StateNum.S_BOS2_RUN7),
    new State(SpriteNum.SPR_BOS2, 3, 3, ActionTable.A_Chase, StateNum.S_BOS2_RUN8),
    new State(SpriteNum.SPR_BOS2, 3, 3, ActionTable.A_Chase, StateNum.S_BOS2_RUN1),
    new State(SpriteNum.SPR_BOS2, 4, 8, ActionTable.A_FaceTarget, StateNum.S_BOS2_ATK2),
    new State(SpriteNum.SPR_BOS2, 5, 8, ActionTable.A_FaceTarget, StateNum.S_BOS2_ATK3),
    new State(SpriteNum.SPR_BOS2, 6, 8, ActionTable.A_BruisAttack, StateNum.S_BOS2_RUN1),
    new State(SpriteNum.SPR_BOS2, 7, 2, null, StateNum.S_BOS2_PAIN2),
    new State(SpriteNum.SPR_BOS2, 7, 2, ActionTable.A_Pain, StateNum.S_BOS2_RUN1),
    new State(SpriteNum.SPR_BOS2, 8, 8, null, StateNum.S_BOS2_DIE2),
    new State(SpriteNum.SPR_BOS2, 9, 8, ActionTable.A_Scream, StateNum.S_BOS2_DIE3),
    new State(SpriteNum.SPR_BOS2, 10, 8, null, StateNum.S_BOS2_DIE4),
    new State(SpriteNum.SPR_BOS2, 11, 8, ActionTable.A_Fall, StateNum.S_BOS2_DIE5),
    new State(SpriteNum.SPR_BOS2, 12, 8, null, StateNum.S_BOS2_DIE6),
    new State(SpriteNum.SPR_BOS2, 13, 8, null, StateNum.S_BOS2_DIE7),
    new State(SpriteNum.SPR_BOS2, 14, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_BOS2, 14, 8, null, StateNum.S_BOS2_RAISE2),
    new State(SpriteNum.SPR_BOS2, 13, 8, null, StateNum.S_BOS2_RAISE3),
    new State(SpriteNum.SPR_BOS2, 12, 8, null, StateNum.S_BOS2_RAISE4),
    new State(SpriteNum.SPR_BOS2, 11, 8, null, StateNum.S_BOS2_RAISE5),
    new State(SpriteNum.SPR_BOS2, 10, 8, null, StateNum.S_BOS2_RAISE6),
    new State(SpriteNum.SPR_BOS2, 9, 8, null, StateNum.S_BOS2_RAISE7),
    new State(SpriteNum.SPR_BOS2, 8, 8, null, StateNum.S_BOS2_RUN1),
    new State(SpriteNum.SPR_SKUL, 32768, 10, ActionTable.A_Look, StateNum.S_SKULL_STND2),
    new State(SpriteNum.SPR_SKUL, 32769, 10, ActionTable.A_Look, StateNum.S_SKULL_STND),
    new State(SpriteNum.SPR_SKUL, 32768, 6, ActionTable.A_Chase, StateNum.S_SKULL_RUN2),
    new State(SpriteNum.SPR_SKUL, 32769, 6, ActionTable.A_Chase, StateNum.S_SKULL_RUN1),
    new State(SpriteNum.SPR_SKUL, 32770, 10, ActionTable.A_FaceTarget, StateNum.S_SKULL_ATK2),
    new State(SpriteNum.SPR_SKUL, 32771, 4, ActionTable.A_SkullAttack, StateNum.S_SKULL_ATK3),
    new State(SpriteNum.SPR_SKUL, 32770, 4, null, StateNum.S_SKULL_ATK4),
    new State(SpriteNum.SPR_SKUL, 32771, 4, null, StateNum.S_SKULL_ATK3),
    new State(SpriteNum.SPR_SKUL, 32772, 3, null, StateNum.S_SKULL_PAIN2),
    new State(SpriteNum.SPR_SKUL, 32772, 3, ActionTable.A_Pain, StateNum.S_SKULL_RUN1),
    new State(SpriteNum.SPR_SKUL, 32773, 6, null, StateNum.S_SKULL_DIE2),
    new State(SpriteNum.SPR_SKUL, 32774, 6, ActionTable.A_Scream, StateNum.S_SKULL_DIE3),
    new State(SpriteNum.SPR_SKUL, 32775, 6, null, StateNum.S_SKULL_DIE4),
    new State(SpriteNum.SPR_SKUL, 32776, 6, ActionTable.A_Fall, StateNum.S_SKULL_DIE5),
    new State(SpriteNum.SPR_SKUL, 9, 6, null, StateNum.S_SKULL_DIE6),
    new State(SpriteNum.SPR_SKUL, 10, 6, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SPID, 0, 10, ActionTable.A_Look, StateNum.S_SPID_STND2),
    new State(SpriteNum.SPR_SPID, 1, 10, ActionTable.A_Look, StateNum.S_SPID_STND),
    new State(SpriteNum.SPR_SPID, 0, 3, ActionTable.A_Metal, StateNum.S_SPID_RUN2),
    new State(SpriteNum.SPR_SPID, 0, 3, ActionTable.A_Chase, StateNum.S_SPID_RUN3),
    new State(SpriteNum.SPR_SPID, 1, 3, ActionTable.A_Chase, StateNum.S_SPID_RUN4),
    new State(SpriteNum.SPR_SPID, 1, 3, ActionTable.A_Chase, StateNum.S_SPID_RUN5),
    new State(SpriteNum.SPR_SPID, 2, 3, ActionTable.A_Metal, StateNum.S_SPID_RUN6),
    new State(SpriteNum.SPR_SPID, 2, 3, ActionTable.A_Chase, StateNum.S_SPID_RUN7),
    new State(SpriteNum.SPR_SPID, 3, 3, ActionTable.A_Chase, StateNum.S_SPID_RUN8),
    new State(SpriteNum.SPR_SPID, 3, 3, ActionTable.A_Chase, StateNum.S_SPID_RUN9),
    new State(SpriteNum.SPR_SPID, 4, 3, ActionTable.A_Metal, StateNum.S_SPID_RUN10),
    new State(SpriteNum.SPR_SPID, 4, 3, ActionTable.A_Chase, StateNum.S_SPID_RUN11),
    new State(SpriteNum.SPR_SPID, 5, 3, ActionTable.A_Chase, StateNum.S_SPID_RUN12),
    new State(SpriteNum.SPR_SPID, 5, 3, ActionTable.A_Chase, StateNum.S_SPID_RUN1),
    new State(SpriteNum.SPR_SPID, 32768, 20, ActionTable.A_FaceTarget, StateNum.S_SPID_ATK2),
    new State(SpriteNum.SPR_SPID, 32774, 4, ActionTable.A_SPosAttack, StateNum.S_SPID_ATK3),
    new State(SpriteNum.SPR_SPID, 32775, 4, ActionTable.A_SPosAttack, StateNum.S_SPID_ATK4),
    new State(SpriteNum.SPR_SPID, 32775, 1, ActionTable.A_SpidRefire, StateNum.S_SPID_ATK2),
    new State(SpriteNum.SPR_SPID, 8, 3, null, StateNum.S_SPID_PAIN2),
    new State(SpriteNum.SPR_SPID, 8, 3, ActionTable.A_Pain, StateNum.S_SPID_RUN1),
    new State(SpriteNum.SPR_SPID, 9, 20, ActionTable.A_Scream, StateNum.S_SPID_DIE2),
    new State(SpriteNum.SPR_SPID, 10, 10, ActionTable.A_Fall, StateNum.S_SPID_DIE3),
    new State(SpriteNum.SPR_SPID, 11, 10, null, StateNum.S_SPID_DIE4),
    new State(SpriteNum.SPR_SPID, 12, 10, null, StateNum.S_SPID_DIE5),
    new State(SpriteNum.SPR_SPID, 13, 10, null, StateNum.S_SPID_DIE6),
    new State(SpriteNum.SPR_SPID, 14, 10, null, StateNum.S_SPID_DIE7),
    new State(SpriteNum.SPR_SPID, 15, 10, null, StateNum.S_SPID_DIE8),
    new State(SpriteNum.SPR_SPID, 16, 10, null, StateNum.S_SPID_DIE9),
    new State(SpriteNum.SPR_SPID, 17, 10, null, StateNum.S_SPID_DIE10),
    new State(SpriteNum.SPR_SPID, 18, 30, null, StateNum.S_SPID_DIE11),
    new State(SpriteNum.SPR_SPID, 18, -1, ActionTable.A_BossDeath, StateNum.S_NULL),
    new State(SpriteNum.SPR_BSPI, 0, 10, ActionTable.A_Look, StateNum.S_BSPI_STND2),
    new State(SpriteNum.SPR_BSPI, 1, 10, ActionTable.A_Look, StateNum.S_BSPI_STND),
    new State(SpriteNum.SPR_BSPI, 0, 20, null, StateNum.S_BSPI_RUN1),
    new State(SpriteNum.SPR_BSPI, 0, 3, ActionTable.A_BabyMetal, StateNum.S_BSPI_RUN2),
    new State(SpriteNum.SPR_BSPI, 0, 3, ActionTable.A_Chase, StateNum.S_BSPI_RUN3),
    new State(SpriteNum.SPR_BSPI, 1, 3, ActionTable.A_Chase, StateNum.S_BSPI_RUN4),
    new State(SpriteNum.SPR_BSPI, 1, 3, ActionTable.A_Chase, StateNum.S_BSPI_RUN5),
    new State(SpriteNum.SPR_BSPI, 2, 3, ActionTable.A_Chase, StateNum.S_BSPI_RUN6),
    new State(SpriteNum.SPR_BSPI, 2, 3, ActionTable.A_Chase, StateNum.S_BSPI_RUN7),
    new State(SpriteNum.SPR_BSPI, 3, 3, ActionTable.A_BabyMetal, StateNum.S_BSPI_RUN8),
    new State(SpriteNum.SPR_BSPI, 3, 3, ActionTable.A_Chase, StateNum.S_BSPI_RUN9),
    new State(SpriteNum.SPR_BSPI, 4, 3, ActionTable.A_Chase, StateNum.S_BSPI_RUN10),
    new State(SpriteNum.SPR_BSPI, 4, 3, ActionTable.A_Chase, StateNum.S_BSPI_RUN11),
    new State(SpriteNum.SPR_BSPI, 5, 3, ActionTable.A_Chase, StateNum.S_BSPI_RUN12),
    new State(SpriteNum.SPR_BSPI, 5, 3, ActionTable.A_Chase, StateNum.S_BSPI_RUN1),
    new State(SpriteNum.SPR_BSPI, 32768, 20, ActionTable.A_FaceTarget, StateNum.S_BSPI_ATK2),
    new State(SpriteNum.SPR_BSPI, 32774, 4, ActionTable.A_BspiAttack, StateNum.S_BSPI_ATK3),
    new State(SpriteNum.SPR_BSPI, 32775, 4, null, StateNum.S_BSPI_ATK4),
    new State(SpriteNum.SPR_BSPI, 32775, 1, ActionTable.A_SpidRefire, StateNum.S_BSPI_ATK2),
    new State(SpriteNum.SPR_BSPI, 8, 3, null, StateNum.S_BSPI_PAIN2),
    new State(SpriteNum.SPR_BSPI, 8, 3, ActionTable.A_Pain, StateNum.S_BSPI_RUN1),
    new State(SpriteNum.SPR_BSPI, 9, 20, ActionTable.A_Scream, StateNum.S_BSPI_DIE2),
    new State(SpriteNum.SPR_BSPI, 10, 7, ActionTable.A_Fall, StateNum.S_BSPI_DIE3),
    new State(SpriteNum.SPR_BSPI, 11, 7, null, StateNum.S_BSPI_DIE4),
    new State(SpriteNum.SPR_BSPI, 12, 7, null, StateNum.S_BSPI_DIE5),
    new State(SpriteNum.SPR_BSPI, 13, 7, null, StateNum.S_BSPI_DIE6),
    new State(SpriteNum.SPR_BSPI, 14, 7, null, StateNum.S_BSPI_DIE7),
    new State(SpriteNum.SPR_BSPI, 15, -1, ActionTable.A_BossDeath, StateNum.S_NULL),
    new State(SpriteNum.SPR_BSPI, 15, 5, null, StateNum.S_BSPI_RAISE2),
    new State(SpriteNum.SPR_BSPI, 14, 5, null, StateNum.S_BSPI_RAISE3),
    new State(SpriteNum.SPR_BSPI, 13, 5, null, StateNum.S_BSPI_RAISE4),
    new State(SpriteNum.SPR_BSPI, 12, 5, null, StateNum.S_BSPI_RAISE5),
    new State(SpriteNum.SPR_BSPI, 11, 5, null, StateNum.S_BSPI_RAISE6),
    new State(SpriteNum.SPR_BSPI, 10, 5, null, StateNum.S_BSPI_RAISE7),
    new State(SpriteNum.SPR_BSPI, 9, 5, null, StateNum.S_BSPI_RUN1),
    new State(SpriteNum.SPR_APLS, 32768, 5, null, StateNum.S_ARACH_PLAZ2),
    new State(SpriteNum.SPR_APLS, 32769, 5, null, StateNum.S_ARACH_PLAZ),
    new State(SpriteNum.SPR_APBX, 32768, 5, null, StateNum.S_ARACH_PLEX2),
    new State(SpriteNum.SPR_APBX, 32769, 5, null, StateNum.S_ARACH_PLEX3),
    new State(SpriteNum.SPR_APBX, 32770, 5, null, StateNum.S_ARACH_PLEX4),
    new State(SpriteNum.SPR_APBX, 32771, 5, null, StateNum.S_ARACH_PLEX5),
    new State(SpriteNum.SPR_APBX, 32772, 5, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_CYBR, 0, 10, ActionTable.A_Look, StateNum.S_CYBER_STND2),
    new State(SpriteNum.SPR_CYBR, 1, 10, ActionTable.A_Look, StateNum.S_CYBER_STND),
    new State(SpriteNum.SPR_CYBR, 0, 3, ActionTable.A_Hoof, StateNum.S_CYBER_RUN2),
    new State(SpriteNum.SPR_CYBR, 0, 3, ActionTable.A_Chase, StateNum.S_CYBER_RUN3),
    new State(SpriteNum.SPR_CYBR, 1, 3, ActionTable.A_Chase, StateNum.S_CYBER_RUN4),
    new State(SpriteNum.SPR_CYBR, 1, 3, ActionTable.A_Chase, StateNum.S_CYBER_RUN5),
    new State(SpriteNum.SPR_CYBR, 2, 3, ActionTable.A_Chase, StateNum.S_CYBER_RUN6),
    new State(SpriteNum.SPR_CYBR, 2, 3, ActionTable.A_Chase, StateNum.S_CYBER_RUN7),
    new State(SpriteNum.SPR_CYBR, 3, 3, ActionTable.A_Metal, StateNum.S_CYBER_RUN8),
    new State(SpriteNum.SPR_CYBR, 3, 3, ActionTable.A_Chase, StateNum.S_CYBER_RUN1),
    new State(SpriteNum.SPR_CYBR, 4, 6, ActionTable.A_FaceTarget, StateNum.S_CYBER_ATK2),
    new State(SpriteNum.SPR_CYBR, 5, 12, ActionTable.A_CyberAttack, StateNum.S_CYBER_ATK3),
    new State(SpriteNum.SPR_CYBR, 4, 12, ActionTable.A_FaceTarget, StateNum.S_CYBER_ATK4),
    new State(SpriteNum.SPR_CYBR, 5, 12, ActionTable.A_CyberAttack, StateNum.S_CYBER_ATK5),
    new State(SpriteNum.SPR_CYBR, 4, 12, ActionTable.A_FaceTarget, StateNum.S_CYBER_ATK6),
    new State(SpriteNum.SPR_CYBR, 5, 12, ActionTable.A_CyberAttack, StateNum.S_CYBER_RUN1),
    new State(SpriteNum.SPR_CYBR, 6, 10, ActionTable.A_Pain, StateNum.S_CYBER_RUN1),
    new State(SpriteNum.SPR_CYBR, 7, 10, null, StateNum.S_CYBER_DIE2),
    new State(SpriteNum.SPR_CYBR, 8, 10, ActionTable.A_Scream, StateNum.S_CYBER_DIE3),
    new State(SpriteNum.SPR_CYBR, 9, 10, null, StateNum.S_CYBER_DIE4),
    new State(SpriteNum.SPR_CYBR, 10, 10, null, StateNum.S_CYBER_DIE5),
    new State(SpriteNum.SPR_CYBR, 11, 10, null, StateNum.S_CYBER_DIE6),
    new State(SpriteNum.SPR_CYBR, 12, 10, ActionTable.A_Fall, StateNum.S_CYBER_DIE7),
    new State(SpriteNum.SPR_CYBR, 13, 10, null, StateNum.S_CYBER_DIE8),
    new State(SpriteNum.SPR_CYBR, 14, 10, null, StateNum.S_CYBER_DIE9),
    new State(SpriteNum.SPR_CYBR, 15, 30, null, StateNum.S_CYBER_DIE10),
    new State(SpriteNum.SPR_CYBR, 15, -1, ActionTable.A_BossDeath, StateNum.S_NULL),
    new State(SpriteNum.SPR_PAIN, 0, 10, ActionTable.A_Look, StateNum.S_PAIN_STND),
    new State(SpriteNum.SPR_PAIN, 0, 3, ActionTable.A_Chase, StateNum.S_PAIN_RUN2),
    new State(SpriteNum.SPR_PAIN, 0, 3, ActionTable.A_Chase, StateNum.S_PAIN_RUN3),
    new State(SpriteNum.SPR_PAIN, 1, 3, ActionTable.A_Chase, StateNum.S_PAIN_RUN4),
    new State(SpriteNum.SPR_PAIN, 1, 3, ActionTable.A_Chase, StateNum.S_PAIN_RUN5),
    new State(SpriteNum.SPR_PAIN, 2, 3, ActionTable.A_Chase, StateNum.S_PAIN_RUN6),
    new State(SpriteNum.SPR_PAIN, 2, 3, ActionTable.A_Chase, StateNum.S_PAIN_RUN1),
    new State(SpriteNum.SPR_PAIN, 3, 5, ActionTable.A_FaceTarget, StateNum.S_PAIN_ATK2),
    new State(SpriteNum.SPR_PAIN, 4, 5, ActionTable.A_FaceTarget, StateNum.S_PAIN_ATK3),
    new State(SpriteNum.SPR_PAIN, 32773, 5, ActionTable.A_FaceTarget, StateNum.S_PAIN_ATK4),
    new State(SpriteNum.SPR_PAIN, 32773, 0, ActionTable.A_PainAttack, StateNum.S_PAIN_RUN1),
    new State(SpriteNum.SPR_PAIN, 6, 6, null, StateNum.S_PAIN_PAIN2),
    new State(SpriteNum.SPR_PAIN, 6, 6, ActionTable.A_Pain, StateNum.S_PAIN_RUN1),
    new State(SpriteNum.SPR_PAIN, 32775, 8, null, StateNum.S_PAIN_DIE2),
    new State(SpriteNum.SPR_PAIN, 32776, 8, ActionTable.A_Scream, StateNum.S_PAIN_DIE3),
    new State(SpriteNum.SPR_PAIN, 32777, 8, null, StateNum.S_PAIN_DIE4),
    new State(SpriteNum.SPR_PAIN, 32778, 8, null, StateNum.S_PAIN_DIE5),
    new State(SpriteNum.SPR_PAIN, 32779, 8, ActionTable.A_PainDie, StateNum.S_PAIN_DIE6),
    new State(SpriteNum.SPR_PAIN, 32780, 8, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_PAIN, 12, 8, null, StateNum.S_PAIN_RAISE2),
    new State(SpriteNum.SPR_PAIN, 11, 8, null, StateNum.S_PAIN_RAISE3),
    new State(SpriteNum.SPR_PAIN, 10, 8, null, StateNum.S_PAIN_RAISE4),
    new State(SpriteNum.SPR_PAIN, 9, 8, null, StateNum.S_PAIN_RAISE5),
    new State(SpriteNum.SPR_PAIN, 8, 8, null, StateNum.S_PAIN_RAISE6),
    new State(SpriteNum.SPR_PAIN, 7, 8, null, StateNum.S_PAIN_RUN1),
    new State(SpriteNum.SPR_SSWV, 0, 10, ActionTable.A_Look, StateNum.S_SSWV_STND2),
    new State(SpriteNum.SPR_SSWV, 1, 10, ActionTable.A_Look, StateNum.S_SSWV_STND),
    new State(SpriteNum.SPR_SSWV, 0, 3, ActionTable.A_Chase, StateNum.S_SSWV_RUN2),
    new State(SpriteNum.SPR_SSWV, 0, 3, ActionTable.A_Chase, StateNum.S_SSWV_RUN3),
    new State(SpriteNum.SPR_SSWV, 1, 3, ActionTable.A_Chase, StateNum.S_SSWV_RUN4),
    new State(SpriteNum.SPR_SSWV, 1, 3, ActionTable.A_Chase, StateNum.S_SSWV_RUN5),
    new State(SpriteNum.SPR_SSWV, 2, 3, ActionTable.A_Chase, StateNum.S_SSWV_RUN6),
    new State(SpriteNum.SPR_SSWV, 2, 3, ActionTable.A_Chase, StateNum.S_SSWV_RUN7),
    new State(SpriteNum.SPR_SSWV, 3, 3, ActionTable.A_Chase, StateNum.S_SSWV_RUN8),
    new State(SpriteNum.SPR_SSWV, 3, 3, ActionTable.A_Chase, StateNum.S_SSWV_RUN1),
    new State(SpriteNum.SPR_SSWV, 4, 10, ActionTable.A_FaceTarget, StateNum.S_SSWV_ATK2),
    new State(SpriteNum.SPR_SSWV, 5, 10, ActionTable.A_FaceTarget, StateNum.S_SSWV_ATK3),
    new State(SpriteNum.SPR_SSWV, 32774, 4, ActionTable.A_CPosAttack, StateNum.S_SSWV_ATK4),
    new State(SpriteNum.SPR_SSWV, 5, 6, ActionTable.A_FaceTarget, StateNum.S_SSWV_ATK5),
    new State(SpriteNum.SPR_SSWV, 32774, 4, ActionTable.A_CPosAttack, StateNum.S_SSWV_ATK6),
    new State(SpriteNum.SPR_SSWV, 5, 1, ActionTable.A_CPosRefire, StateNum.S_SSWV_ATK2),
    new State(SpriteNum.SPR_SSWV, 7, 3, null, StateNum.S_SSWV_PAIN2),
    new State(SpriteNum.SPR_SSWV, 7, 3, ActionTable.A_Pain, StateNum.S_SSWV_RUN1),
    new State(SpriteNum.SPR_SSWV, 8, 5, null, StateNum.S_SSWV_DIE2),
    new State(SpriteNum.SPR_SSWV, 9, 5, ActionTable.A_Scream, StateNum.S_SSWV_DIE3),
    new State(SpriteNum.SPR_SSWV, 10, 5, ActionTable.A_Fall, StateNum.S_SSWV_DIE4),
    new State(SpriteNum.SPR_SSWV, 11, 5, null, StateNum.S_SSWV_DIE5),
    new State(SpriteNum.SPR_SSWV, 12, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SSWV, 13, 5, null, StateNum.S_SSWV_XDIE2),
    new State(SpriteNum.SPR_SSWV, 14, 5, ActionTable.A_XScream, StateNum.S_SSWV_XDIE3),
    new State(SpriteNum.SPR_SSWV, 15, 5, ActionTable.A_Fall, StateNum.S_SSWV_XDIE4),
    new State(SpriteNum.SPR_SSWV, 16, 5, null, StateNum.S_SSWV_XDIE5),
    new State(SpriteNum.SPR_SSWV, 17, 5, null, StateNum.S_SSWV_XDIE6),
    new State(SpriteNum.SPR_SSWV, 18, 5, null, StateNum.S_SSWV_XDIE7),
    new State(SpriteNum.SPR_SSWV, 19, 5, null, StateNum.S_SSWV_XDIE8),
    new State(SpriteNum.SPR_SSWV, 20, 5, null, StateNum.S_SSWV_XDIE9),
    new State(SpriteNum.SPR_SSWV, 21, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SSWV, 12, 5, null, StateNum.S_SSWV_RAISE2),
    new State(SpriteNum.SPR_SSWV, 11, 5, null, StateNum.S_SSWV_RAISE3),
    new State(SpriteNum.SPR_SSWV, 10, 5, null, StateNum.S_SSWV_RAISE4),
    new State(SpriteNum.SPR_SSWV, 9, 5, null, StateNum.S_SSWV_RAISE5),
    new State(SpriteNum.SPR_SSWV, 8, 5, null, StateNum.S_SSWV_RUN1),
    new State(SpriteNum.SPR_KEEN, 0, -1, null, StateNum.S_KEENSTND),
    new State(SpriteNum.SPR_KEEN, 0, 6, null, StateNum.S_COMMKEEN2),
    new State(SpriteNum.SPR_KEEN, 1, 6, null, StateNum.S_COMMKEEN3),
    new State(SpriteNum.SPR_KEEN, 2, 6, ActionTable.A_Scream, StateNum.S_COMMKEEN4),
    new State(SpriteNum.SPR_KEEN, 3, 6, null, StateNum.S_COMMKEEN5),
    new State(SpriteNum.SPR_KEEN, 4, 6, null, StateNum.S_COMMKEEN6),
    new State(SpriteNum.SPR_KEEN, 5, 6, null, StateNum.S_COMMKEEN7),
    new State(SpriteNum.SPR_KEEN, 6, 6, null, StateNum.S_COMMKEEN8),
    new State(SpriteNum.SPR_KEEN, 7, 6, null, StateNum.S_COMMKEEN9),
    new State(SpriteNum.SPR_KEEN, 8, 6, null, StateNum.S_COMMKEEN10),
    new State(SpriteNum.SPR_KEEN, 9, 6, null, StateNum.S_COMMKEEN11),
    new State(SpriteNum.SPR_KEEN, 10, 6, ActionTable.A_KeenDie, StateNum.S_COMMKEEN12),
    new State(SpriteNum.SPR_KEEN, 11, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_KEEN, 12, 4, null, StateNum.S_KEENPAIN2),
    new State(SpriteNum.SPR_KEEN, 12, 8, ActionTable.A_Pain, StateNum.S_KEENSTND),
    new State(SpriteNum.SPR_BBRN, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_BBRN, 1, 36, ActionTable.A_BrainPain, StateNum.S_BRAIN),
    new State(SpriteNum.SPR_BBRN, 0, 100, ActionTable.A_BrainScream, StateNum.S_BRAIN_DIE2),
    new State(SpriteNum.SPR_BBRN, 0, 10, null, StateNum.S_BRAIN_DIE3),
    new State(SpriteNum.SPR_BBRN, 0, 10, null, StateNum.S_BRAIN_DIE4),
    new State(SpriteNum.SPR_BBRN, 0, -1, ActionTable.A_BrainDie, StateNum.S_NULL),
    new State(SpriteNum.SPR_SSWV, 0, 10, ActionTable.A_Look, StateNum.S_BRAINEYE),
    new State(SpriteNum.SPR_SSWV, 0, 181, ActionTable.A_BrainAwake, StateNum.S_BRAINEYE1),
    new State(SpriteNum.SPR_SSWV, 0, 150, ActionTable.A_BrainSpit, StateNum.S_BRAINEYE1),
    new State(SpriteNum.SPR_BOSF, 32768, 3, ActionTable.A_SpawnSound, StateNum.S_SPAWN2),
    new State(SpriteNum.SPR_BOSF, 32769, 3, ActionTable.A_SpawnFly, StateNum.S_SPAWN3),
    new State(SpriteNum.SPR_BOSF, 32770, 3, ActionTable.A_SpawnFly, StateNum.S_SPAWN4),
    new State(SpriteNum.SPR_BOSF, 32771, 3, ActionTable.A_SpawnFly, StateNum.S_SPAWN1),
    new State(SpriteNum.SPR_FIRE, 32768, 4, ActionTable.A_Fire, StateNum.S_SPAWNFIRE2),
    new State(SpriteNum.SPR_FIRE, 32769, 4, ActionTable.A_Fire, StateNum.S_SPAWNFIRE3),
    new State(SpriteNum.SPR_FIRE, 32770, 4, ActionTable.A_Fire, StateNum.S_SPAWNFIRE4),
    new State(SpriteNum.SPR_FIRE, 32771, 4, ActionTable.A_Fire, StateNum.S_SPAWNFIRE5),
    new State(SpriteNum.SPR_FIRE, 32772, 4, ActionTable.A_Fire, StateNum.S_SPAWNFIRE6),
    new State(SpriteNum.SPR_FIRE, 32773, 4, ActionTable.A_Fire, StateNum.S_SPAWNFIRE7),
    new State(SpriteNum.SPR_FIRE, 32774, 4, ActionTable.A_Fire, StateNum.S_SPAWNFIRE8),
    new State(SpriteNum.SPR_FIRE, 32775, 4, ActionTable.A_Fire, StateNum.S_NULL),
    new State(SpriteNum.SPR_MISL, 32769, 10, null, StateNum.S_BRAINEXPLODE2),
    new State(SpriteNum.SPR_MISL, 32770, 10, null, StateNum.S_BRAINEXPLODE3),
    new State(SpriteNum.SPR_MISL, 32771, 10, ActionTable.A_BrainExplode, StateNum.S_NULL),
    new State(SpriteNum.SPR_ARM1, 0, 6, null, StateNum.S_ARM1A),
    new State(SpriteNum.SPR_ARM1, 32769, 7, null, StateNum.S_ARM1),
    new State(SpriteNum.SPR_ARM2, 0, 6, null, StateNum.S_ARM2A),
    new State(SpriteNum.SPR_ARM2, 32769, 6, null, StateNum.S_ARM2),
    new State(SpriteNum.SPR_BAR1, 0, 6, null, StateNum.S_BAR2),
    new State(SpriteNum.SPR_BAR1, 1, 6, null, StateNum.S_BAR1),
    new State(SpriteNum.SPR_BEXP, 32768, 5, null, StateNum.S_BEXP2),
    new State(SpriteNum.SPR_BEXP, 32769, 5, ActionTable.A_Scream, StateNum.S_BEXP3),
    new State(SpriteNum.SPR_BEXP, 32770, 5, null, StateNum.S_BEXP4),
    new State(SpriteNum.SPR_BEXP, 32771, 10, ActionTable.A_Explode, StateNum.S_BEXP5),
    new State(SpriteNum.SPR_BEXP, 32772, 10, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_FCAN, 32768, 4, null, StateNum.S_BBAR2),
    new State(SpriteNum.SPR_FCAN, 32769, 4, null, StateNum.S_BBAR3),
    new State(SpriteNum.SPR_FCAN, 32770, 4, null, StateNum.S_BBAR1),
    new State(SpriteNum.SPR_BON1, 0, 6, null, StateNum.S_BON1A),
    new State(SpriteNum.SPR_BON1, 1, 6, null, StateNum.S_BON1B),
    new State(SpriteNum.SPR_BON1, 2, 6, null, StateNum.S_BON1C),
    new State(SpriteNum.SPR_BON1, 3, 6, null, StateNum.S_BON1D),
    new State(SpriteNum.SPR_BON1, 2, 6, null, StateNum.S_BON1E),
    new State(SpriteNum.SPR_BON1, 1, 6, null, StateNum.S_BON1),
    new State(SpriteNum.SPR_BON2, 0, 6, null, StateNum.S_BON2A),
    new State(SpriteNum.SPR_BON2, 1, 6, null, StateNum.S_BON2B),
    new State(SpriteNum.SPR_BON2, 2, 6, null, StateNum.S_BON2C),
    new State(SpriteNum.SPR_BON2, 3, 6, null, StateNum.S_BON2D),
    new State(SpriteNum.SPR_BON2, 2, 6, null, StateNum.S_BON2E),
    new State(SpriteNum.SPR_BON2, 1, 6, null, StateNum.S_BON2),
    new State(SpriteNum.SPR_BKEY, 0, 10, null, StateNum.S_BKEY2),
    new State(SpriteNum.SPR_BKEY, 32769, 10, null, StateNum.S_BKEY),
    new State(SpriteNum.SPR_RKEY, 0, 10, null, StateNum.S_RKEY2),
    new State(SpriteNum.SPR_RKEY, 32769, 10, null, StateNum.S_RKEY),
    new State(SpriteNum.SPR_YKEY, 0, 10, null, StateNum.S_YKEY2),
    new State(SpriteNum.SPR_YKEY, 32769, 10, null, StateNum.S_YKEY),
    new State(SpriteNum.SPR_BSKU, 0, 10, null, StateNum.S_BSKULL2),
    new State(SpriteNum.SPR_BSKU, 32769, 10, null, StateNum.S_BSKULL),
    new State(SpriteNum.SPR_RSKU, 0, 10, null, StateNum.S_RSKULL2),
    new State(SpriteNum.SPR_RSKU, 32769, 10, null, StateNum.S_RSKULL),
    new State(SpriteNum.SPR_YSKU, 0, 10, null, StateNum.S_YSKULL2),
    new State(SpriteNum.SPR_YSKU, 32769, 10, null, StateNum.S_YSKULL),
    new State(SpriteNum.SPR_STIM, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_MEDI, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SOUL, 32768, 6, null, StateNum.S_SOUL2),
    new State(SpriteNum.SPR_SOUL, 32769, 6, null, StateNum.S_SOUL3),
    new State(SpriteNum.SPR_SOUL, 32770, 6, null, StateNum.S_SOUL4),
    new State(SpriteNum.SPR_SOUL, 32771, 6, null, StateNum.S_SOUL5),
    new State(SpriteNum.SPR_SOUL, 32770, 6, null, StateNum.S_SOUL6),
    new State(SpriteNum.SPR_SOUL, 32769, 6, null, StateNum.S_SOUL),
    new State(SpriteNum.SPR_PINV, 32768, 6, null, StateNum.S_PINV2),
    new State(SpriteNum.SPR_PINV, 32769, 6, null, StateNum.S_PINV3),
    new State(SpriteNum.SPR_PINV, 32770, 6, null, StateNum.S_PINV4),
    new State(SpriteNum.SPR_PINV, 32771, 6, null, StateNum.S_PINV),
    new State(SpriteNum.SPR_PSTR, 32768, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_PINS, 32768, 6, null, StateNum.S_PINS2),
    new State(SpriteNum.SPR_PINS, 32769, 6, null, StateNum.S_PINS3),
    new State(SpriteNum.SPR_PINS, 32770, 6, null, StateNum.S_PINS4),
    new State(SpriteNum.SPR_PINS, 32771, 6, null, StateNum.S_PINS),
    new State(SpriteNum.SPR_MEGA, 32768, 6, null, StateNum.S_MEGA2),
    new State(SpriteNum.SPR_MEGA, 32769, 6, null, StateNum.S_MEGA3),
    new State(SpriteNum.SPR_MEGA, 32770, 6, null, StateNum.S_MEGA4),
    new State(SpriteNum.SPR_MEGA, 32771, 6, null, StateNum.S_MEGA),
    new State(SpriteNum.SPR_SUIT, 32768, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_PMAP, 32768, 6, null, StateNum.S_PMAP2),
    new State(SpriteNum.SPR_PMAP, 32769, 6, null, StateNum.S_PMAP3),
    new State(SpriteNum.SPR_PMAP, 32770, 6, null, StateNum.S_PMAP4),
    new State(SpriteNum.SPR_PMAP, 32771, 6, null, StateNum.S_PMAP5),
    new State(SpriteNum.SPR_PMAP, 32770, 6, null, StateNum.S_PMAP6),
    new State(SpriteNum.SPR_PMAP, 32769, 6, null, StateNum.S_PMAP),
    new State(SpriteNum.SPR_PVIS, 32768, 6, null, StateNum.S_PVIS2),
    new State(SpriteNum.SPR_PVIS, 1, 6, null, StateNum.S_PVIS),
    new State(SpriteNum.SPR_CLIP, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_AMMO, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_ROCK, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_BROK, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_CELL, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_CELP, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SHEL, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SBOX, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_BPAK, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_BFUG, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_MGUN, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_CSAW, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_LAUN, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_PLAS, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SHOT, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SGN2, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_COLU, 32768, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SMT2, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_GOR1, 0, 10, null, StateNum.S_BLOODYTWITCH2),
    new State(SpriteNum.SPR_GOR1, 1, 15, null, StateNum.S_BLOODYTWITCH3),
    new State(SpriteNum.SPR_GOR1, 2, 8, null, StateNum.S_BLOODYTWITCH4),
    new State(SpriteNum.SPR_GOR1, 1, 6, null, StateNum.S_BLOODYTWITCH),
    new State(SpriteNum.SPR_PLAY, 13, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_PLAY, 18, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_POL2, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_POL5, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_POL4, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_POL3, 32768, 6, null, StateNum.S_HEADCANDLES2),
    new State(SpriteNum.SPR_POL3, 32769, 6, null, StateNum.S_HEADCANDLES),
    new State(SpriteNum.SPR_POL1, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_POL6, 0, 6, null, StateNum.S_LIVESTICK2),
    new State(SpriteNum.SPR_POL6, 1, 8, null, StateNum.S_LIVESTICK),
    new State(SpriteNum.SPR_GOR2, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_GOR3, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_GOR4, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_GOR5, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_SMIT, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_COL1, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_COL2, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_COL3, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_COL4, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_CAND, 32768, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_CBRA, 32768, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_COL6, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_TRE1, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_TRE2, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_ELEC, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_CEYE, 32768, 6, null, StateNum.S_EVILEYE2),
    new State(SpriteNum.SPR_CEYE, 32769, 6, null, StateNum.S_EVILEYE3),
    new State(SpriteNum.SPR_CEYE, 32770, 6, null, StateNum.S_EVILEYE4),
    new State(SpriteNum.SPR_CEYE, 32769, 6, null, StateNum.S_EVILEYE),
    new State(SpriteNum.SPR_FSKU, 32768, 6, null, StateNum.S_FLOATSKULL2),
    new State(SpriteNum.SPR_FSKU, 32769, 6, null, StateNum.S_FLOATSKULL3),
    new State(SpriteNum.SPR_FSKU, 32770, 6, null, StateNum.S_FLOATSKULL),
    new State(SpriteNum.SPR_COL5, 0, 14, null, StateNum.S_HEARTCOL2),
    new State(SpriteNum.SPR_COL5, 1, 14, null, StateNum.S_HEARTCOL),
    new State(SpriteNum.SPR_TBLU, 32768, 4, null, StateNum.S_BLUETORCH2),
    new State(SpriteNum.SPR_TBLU, 32769, 4, null, StateNum.S_BLUETORCH3),
    new State(SpriteNum.SPR_TBLU, 32770, 4, null, StateNum.S_BLUETORCH4),
    new State(SpriteNum.SPR_TBLU, 32771, 4, null, StateNum.S_BLUETORCH),
    new State(SpriteNum.SPR_TGRN, 32768, 4, null, StateNum.S_GREENTORCH2),
    new State(SpriteNum.SPR_TGRN, 32769, 4, null, StateNum.S_GREENTORCH3),
    new State(SpriteNum.SPR_TGRN, 32770, 4, null, StateNum.S_GREENTORCH4),
    new State(SpriteNum.SPR_TGRN, 32771, 4, null, StateNum.S_GREENTORCH),
    new State(SpriteNum.SPR_TRED, 32768, 4, null, StateNum.S_REDTORCH2),
    new State(SpriteNum.SPR_TRED, 32769, 4, null, StateNum.S_REDTORCH3),
    new State(SpriteNum.SPR_TRED, 32770, 4, null, StateNum.S_REDTORCH4),
    new State(SpriteNum.SPR_TRED, 32771, 4, null, StateNum.S_REDTORCH),
    new State(SpriteNum.SPR_SMBT, 32768, 4, null, StateNum.S_BTORCHSHRT2),
    new State(SpriteNum.SPR_SMBT, 32769, 4, null, StateNum.S_BTORCHSHRT3),
    new State(SpriteNum.SPR_SMBT, 32770, 4, null, StateNum.S_BTORCHSHRT4),
    new State(SpriteNum.SPR_SMBT, 32771, 4, null, StateNum.S_BTORCHSHRT),
    new State(SpriteNum.SPR_SMGT, 32768, 4, null, StateNum.S_GTORCHSHRT2),
    new State(SpriteNum.SPR_SMGT, 32769, 4, null, StateNum.S_GTORCHSHRT3),
    new State(SpriteNum.SPR_SMGT, 32770, 4, null, StateNum.S_GTORCHSHRT4),
    new State(SpriteNum.SPR_SMGT, 32771, 4, null, StateNum.S_GTORCHSHRT),
    new State(SpriteNum.SPR_SMRT, 32768, 4, null, StateNum.S_RTORCHSHRT2),
    new State(SpriteNum.SPR_SMRT, 32769, 4, null, StateNum.S_RTORCHSHRT3),
    new State(SpriteNum.SPR_SMRT, 32770, 4, null, StateNum.S_RTORCHSHRT4),
    new State(SpriteNum.SPR_SMRT, 32771, 4, null, StateNum.S_RTORCHSHRT),
    new State(SpriteNum.SPR_HDB1, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_HDB2, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_HDB3, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_HDB4, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_HDB5, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_HDB6, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_POB1, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_POB2, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_BRS1, 0, -1, null, StateNum.S_NULL),
    new State(SpriteNum.SPR_TLMP, 32768, 4, null, StateNum.S_TECHLAMP2),
    new State(SpriteNum.SPR_TLMP, 32769, 4, null, StateNum.S_TECHLAMP3),
    new State(SpriteNum.SPR_TLMP, 32770, 4, null, StateNum.S_TECHLAMP4),
    new State(SpriteNum.SPR_TLMP, 32771, 4, null, StateNum.S_TECHLAMP),
    new State(SpriteNum.SPR_TLP2, 32768, 4, null, StateNum.S_TECH2LAMP2),
    new State(SpriteNum.SPR_TLP2, 32769, 4, null, StateNum.S_TECH2LAMP3),
    new State(SpriteNum.SPR_TLP2, 32770, 4, null, StateNum.S_TECH2LAMP4),
    new State(SpriteNum.SPR_TLP2, 32771, 4, null, StateNum.S_TECH2LAMP),
        };

        public static State GetState(StateNum stateNum)
        {
            return states[(int)stateNum];
        }

        public static readonly MobjInfo[] MobjInfos = new MobjInfo[]
        {
            new MobjInfo( // MobjType.Player
                -1, // doomEdNum
                StateNum.S_PLAY, // spawnState
                100, // spawnHealth
                StateNum.S_PLAY_RUN1, // seeState
                SoundType.sfx_None, // seeSound
                0, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_PLAY_PAIN, // painState
                255, // painChance
                SoundType.sfx_plpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_PLAY_ATK1, // missileState
                StateNum.S_PLAY_DIE1, // deathState
                StateNum.S_PLAY_XDIE1, // xdeathState
                SoundType.sfx_pldeth, // deathSound
                0, // speed
                (16), // radius
                (56), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_DROPOFF | MobjFlags.MF_PICKUP | MobjFlags.MF_NOTDMATCH, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Possessed
                3004, // doomEdNum
                StateNum.S_POSS_STND, // spawnState
                20, // spawnHealth
                StateNum.S_POSS_RUN1, // seeState
                SoundType.sfx_posit1, // seeSound
                8, // reactionTime
                SoundType.sfx_pistol, // attackSound
                StateNum.S_POSS_PAIN, // painState
                200, // painChance
                SoundType.sfx_popain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_POSS_ATK1, // missileState
                StateNum.S_POSS_DIE1, // deathState
                StateNum.S_POSS_XDIE1, // xdeathState
                SoundType.sfx_podth3, // deathSound
                8, // speed
                (20), // radius
                (56), // height
                100, // mass
                0, // damage
                SoundType.sfx_posact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_POSS_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Shotguy
                9, // doomEdNum
                StateNum.S_POSS_STND, // spawnState
                30, // spawnHealth
                StateNum.S_POSS_RUN1, // seeState
                SoundType.sfx_posit2, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_POSS_PAIN, // painState
                170, // painChance
                SoundType.sfx_popain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_POSS_ATK1, // missileState
                StateNum.S_POSS_DIE1, // deathState
                StateNum.S_POSS_XDIE1, // xdeathState
                SoundType.sfx_podth1, // deathSound
                8, // speed
                (20), // radius
                (56), // height
                100, // mass
                0, // damage
                SoundType.sfx_posact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_POSS_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Vile
                64, // doomEdNum
                StateNum.S_VILE_STND, // spawnState
                700, // spawnHealth
                StateNum.S_VILE_RUN1, // seeState
                SoundType.sfx_vilsit, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_VILE_PAIN, // painState
                10, // painChance
                SoundType.sfx_vipain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_VILE_ATK1, // missileState
                StateNum.S_VILE_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_vildth, // deathSound
                15, // speed
                (20), // radius
                (56), // height
                500, // mass
                0, // damage
                SoundType.sfx_vilact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Fire
                -1, // doomEdNum
                StateNum.S_FIRE1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Undead
                66, // doomEdNum
                StateNum.S_SKEL_STND, // spawnState
                300, // spawnHealth
                StateNum.S_SKEL_RUN1, // seeState
                SoundType.sfx_skesit, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_SKEL_PAIN, // painState
                100, // painChance
                SoundType.sfx_popain, // painSound
                StateNum.S_SKEL_FIST1, // meleeState
                StateNum.S_SKEL_MISS1, // missileState
                StateNum.S_SKEL_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_skedth, // deathSound
                10, // speed
                (20), // radius
                (56), // height
                500, // mass
                0, // damage
                SoundType.sfx_skeact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_SKEL_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Tracer
                -1, // doomEdNum
                StateNum.S_TRACER, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_skeact, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_TRACEEXP1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_barexp, // deathSound
                10, // speed
                (11), // radius
                (8), // height
                100, // mass
                10, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_MISSILE | MobjFlags.MF_DROPOFF | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Smoke
                -1, // doomEdNum
                StateNum.S_SMOKE1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Fatso
                67, // doomEdNum
                StateNum.S_FATT_STND, // spawnState
                600, // spawnHealth
                StateNum.S_FATT_RUN1, // seeState
                SoundType.sfx_mansit, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_FATT_PAIN, // painState
                80, // painChance
                SoundType.sfx_mnpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_FATT_ATK1, // missileState
                StateNum.S_FATT_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_mandth, // deathSound
                8, // speed
                (48), // radius
                (64), // height
                1000, // mass
                0, // damage
                SoundType.sfx_posact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_FATT_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Fatshot
                -1, // doomEdNum
                StateNum.S_FATSHOT1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_firsht, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_FATSHOTX1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_firxpl, // deathSound
                20, // speed
                (6), // radius
                (8), // height
                100, // mass
                8, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_MISSILE | MobjFlags.MF_DROPOFF | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Chainguy
                65, // doomEdNum
                StateNum.S_CPOS_STND, // spawnState
                70, // spawnHealth
                StateNum.S_CPOS_RUN1, // seeState
                SoundType.sfx_posit2, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_CPOS_PAIN, // painState
                170, // painChance
                SoundType.sfx_popain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_CPOS_ATK1, // missileState
                StateNum.S_CPOS_DIE1, // deathState
                StateNum.S_CPOS_XDIE1, // xdeathState
                SoundType.sfx_podth2, // deathSound
                8, // speed
                (20), // radius
                (56), // height
                100, // mass
                0, // damage
                SoundType.sfx_posact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_CPOS_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Troop
                3001, // doomEdNum
                StateNum.S_TROO_STND, // spawnState
                60, // spawnHealth
                StateNum.S_TROO_RUN1, // seeState
                SoundType.sfx_bgsit1, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_TROO_PAIN, // painState
                200, // painChance
                SoundType.sfx_popain, // painSound
                StateNum.S_TROO_ATK1, // meleeState
                StateNum.S_TROO_ATK1, // missileState
                StateNum.S_TROO_DIE1, // deathState
                StateNum.S_TROO_XDIE1, // xdeathState
                SoundType.sfx_bgdth1, // deathSound
                8, // speed
                (20), // radius
                (56), // height
                100, // mass
                0, // damage
                SoundType.sfx_bgact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_TROO_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Sergeant
                3002, // doomEdNum
                StateNum.S_SARG_STND, // spawnState
                150, // spawnHealth
                StateNum.S_SARG_RUN1, // seeState
                SoundType.sfx_sgtsit, // seeSound
                8, // reactionTime
                SoundType.sfx_sgtatk, // attackSound
                StateNum.S_SARG_PAIN, // painState
                180, // painChance
                SoundType.sfx_dmpain, // painSound
                StateNum.S_SARG_ATK1, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_SARG_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_sgtdth, // deathSound
                10, // speed
                (30), // radius
                (56), // height
                400, // mass
                0, // damage
                SoundType.sfx_dmact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_SARG_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Shadows
                58, // doomEdNum
                StateNum.S_SARG_STND, // spawnState
                150, // spawnHealth
                StateNum.S_SARG_RUN1, // seeState
                SoundType.sfx_sgtsit, // seeSound
                8, // reactionTime
                SoundType.sfx_sgtatk, // attackSound
                StateNum.S_SARG_PAIN, // painState
                180, // painChance
                SoundType.sfx_dmpain, // painSound
                StateNum.S_SARG_ATK1, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_SARG_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_sgtdth, // deathSound
                10, // speed
                (30), // radius
                (56), // height
                400, // mass
                0, // damage
                SoundType.sfx_dmact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_SHADOW | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_SARG_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Head
                3005, // doomEdNum
                StateNum.S_HEAD_STND, // spawnState
                400, // spawnHealth
                StateNum.S_HEAD_RUN1, // seeState
                SoundType.sfx_cacsit, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_HEAD_PAIN, // painState
                128, // painChance
                SoundType.sfx_dmpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_HEAD_ATK1, // missileState
                StateNum.S_HEAD_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_cacdth, // deathSound
                8, // speed
                (31), // radius
                (56), // height
                400, // mass
                0, // damage
                SoundType.sfx_dmact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_FLOAT | MobjFlags.MF_NOGRAVITY | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_HEAD_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Bruiser
                3003, // doomEdNum
                StateNum.S_BOSS_STND, // spawnState
                1000, // spawnHealth
                StateNum.S_BOSS_RUN1, // seeState
                SoundType.sfx_brssit, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_BOSS_PAIN, // painState
                50, // painChance
                SoundType.sfx_dmpain, // painSound
                StateNum.S_BOSS_ATK1, // meleeState
                StateNum.S_BOSS_ATK1, // missileState
                StateNum.S_BOSS_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_brsdth, // deathSound
                8, // speed
                (24), // radius
                (64), // height
                1000, // mass
                0, // damage
                SoundType.sfx_dmact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_BOSS_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Bruisershot
                -1, // doomEdNum
                StateNum.S_BRBALL1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_firsht, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_BRBALLX1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_firxpl, // deathSound
                15, // speed
                (6), // radius
                (8), // height
                100, // mass
                8, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_MISSILE | MobjFlags.MF_DROPOFF | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Knight
                69, // doomEdNum
                StateNum.S_BOS2_STND, // spawnState
                500, // spawnHealth
                StateNum.S_BOS2_RUN1, // seeState
                SoundType.sfx_kntsit, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_BOS2_PAIN, // painState
                50, // painChance
                SoundType.sfx_dmpain, // painSound
                StateNum.S_BOS2_ATK1, // meleeState
                StateNum.S_BOS2_ATK1, // missileState
                StateNum.S_BOS2_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_kntdth, // deathSound
                8, // speed
                (24), // radius
                (64), // height
                1000, // mass
                0, // damage
                SoundType.sfx_dmact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_BOS2_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Skull
                3006, // doomEdNum
                StateNum.S_SKULL_STND, // spawnState
                100, // spawnHealth
                StateNum.S_SKULL_RUN1, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_sklatk, // attackSound
                StateNum.S_SKULL_PAIN, // painState
                256, // painChance
                SoundType.sfx_dmpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_SKULL_ATK1, // missileState
                StateNum.S_SKULL_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_firxpl, // deathSound
                8, // speed
                (16), // radius
                (56), // height
                50, // mass
                3, // damage
                SoundType.sfx_dmact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_FLOAT | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Spider
                7, // doomEdNum
                StateNum.S_SPID_STND, // spawnState
                3000, // spawnHealth
                StateNum.S_SPID_RUN1, // seeState
                SoundType.sfx_spisit, // seeSound
                8, // reactionTime
                SoundType.sfx_shotgn, // attackSound
                StateNum.S_SPID_PAIN, // painState
                40, // painChance
                SoundType.sfx_dmpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_SPID_ATK1, // missileState
                StateNum.S_SPID_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_spidth, // deathSound
                12, // speed
                (128), // radius
                (100), // height
                1000, // mass
                0, // damage
                SoundType.sfx_dmact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Baby
                68, // doomEdNum
                StateNum.S_BSPI_STND, // spawnState
                500, // spawnHealth
                StateNum.S_BSPI_SIGHT, // seeState
                SoundType.sfx_bspsit, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_BSPI_PAIN, // painState
                128, // painChance
                SoundType.sfx_dmpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_BSPI_ATK1, // missileState
                StateNum.S_BSPI_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_bspdth, // deathSound
                12, // speed
                (64), // radius
                (64), // height
                600, // mass
                0, // damage
                SoundType.sfx_bspact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_BSPI_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Cyborg
                16, // doomEdNum
                StateNum.S_CYBER_STND, // spawnState
                4000, // spawnHealth
                StateNum.S_CYBER_RUN1, // seeState
                SoundType.sfx_cybsit, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_CYBER_PAIN, // painState
                20, // painChance
                SoundType.sfx_dmpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_CYBER_ATK1, // missileState
                StateNum.S_CYBER_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_cybdth, // deathSound
                16, // speed
                (40), // radius
                (110), // height
                1000, // mass
                0, // damage
                SoundType.sfx_dmact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Pain
                71, // doomEdNum
                StateNum.S_PAIN_STND, // spawnState
                400, // spawnHealth
                StateNum.S_PAIN_RUN1, // seeState
                SoundType.sfx_pesit, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_PAIN_PAIN, // painState
                128, // painChance
                SoundType.sfx_pepain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_PAIN_ATK1, // missileState
                StateNum.S_PAIN_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_pedth, // deathSound
                8, // speed
                (31), // radius
                (56), // height
                400, // mass
                0, // damage
                SoundType.sfx_dmact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_FLOAT | MobjFlags.MF_NOGRAVITY | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_PAIN_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Wolfss
                84, // doomEdNum
                StateNum.S_SSWV_STND, // spawnState
                50, // spawnHealth
                StateNum.S_SSWV_RUN1, // seeState
                SoundType.sfx_sssit, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_SSWV_PAIN, // painState
                170, // painChance
                SoundType.sfx_popain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_SSWV_ATK1, // missileState
                StateNum.S_SSWV_DIE1, // deathState
                StateNum.S_SSWV_XDIE1, // xdeathState
                SoundType.sfx_ssdth, // deathSound
                8, // speed
                (20), // radius
                (56), // height
                100, // mass
                0, // damage
                SoundType.sfx_posact, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_SSWV_RAISE1 // raiseState
            ),

            new MobjInfo( // MobjType.Keen
                72, // doomEdNum
                StateNum.S_KEENSTND, // spawnState
                100, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_KEENPAIN, // painState
                256, // painChance
                SoundType.sfx_keenpn, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_COMMKEEN, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_keendt, // deathSound
                0, // speed
                (16), // radius
                (72), // height
                10000000, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_COUNTKILL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Bossbrain
                88, // doomEdNum
                StateNum.S_BRAIN, // spawnState
                250, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_BRAIN_PAIN, // painState
                255, // painChance
                SoundType.sfx_bospn, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_BRAIN_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_bosdth, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                10000000, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Bossspit
                89, // doomEdNum
                StateNum.S_BRAINEYE, // spawnState
                1000, // spawnHealth
                StateNum.S_BRAINEYESEE, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (32), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_NOSECTOR, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Bosstarget
                87, // doomEdNum
                StateNum.S_NULL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (32), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_NOSECTOR, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Spawnshot
                -1, // doomEdNum
                StateNum.S_SPAWN1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_bospit, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_firxpl, // deathSound
                10, // speed
                (6), // radius
                (32), // height
                100, // mass
                3, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_MISSILE | MobjFlags.MF_DROPOFF | MobjFlags.MF_NOGRAVITY | MobjFlags.MF_NOCLIP, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Spawnfire
                -1, // doomEdNum
                StateNum.S_SPAWNFIRE1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Barrel
                2035, // doomEdNum
                StateNum.S_BAR1, // spawnState
                20, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_BEXP, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_barexp, // deathSound
                0, // speed
                (10), // radius
                (42), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SHOOTABLE | MobjFlags.MF_NOBLOOD, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Troopshot
                -1, // doomEdNum
                StateNum.S_TBALL1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_firsht, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_TBALLX1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_firxpl, // deathSound
                10, // speed
                (6), // radius
                (8), // height
                100, // mass
                3, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_MISSILE | MobjFlags.MF_DROPOFF | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Headshot
                -1, // doomEdNum
                StateNum.S_RBALL1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_firsht, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_RBALLX1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_firxpl, // deathSound
                10, // speed
                (6), // radius
                (8), // height
                100, // mass
                5, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_MISSILE | MobjFlags.MF_DROPOFF | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Rocket
                -1, // doomEdNum
                StateNum.S_ROCKET, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_rlaunc, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_EXPLODE1, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_barexp, // deathSound
                20, // speed
                (11), // radius
                (8), // height
                100, // mass
                20, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_MISSILE | MobjFlags.MF_DROPOFF | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Plasma
                -1, // doomEdNum
                StateNum.S_PLASBALL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_plasma, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_PLASEXP, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_firxpl, // deathSound
                25, // speed
                (13), // radius
                (8), // height
                100, // mass
                5, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_MISSILE | MobjFlags.MF_DROPOFF | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Bfg
                -1, // doomEdNum
                StateNum.S_BFGSHOT, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_BFGLAND, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_rxplod, // deathSound
                25, // speed
                (13), // radius
                (8), // height
                100, // mass
                100, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_MISSILE | MobjFlags.MF_DROPOFF | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Arachplaz
                -1, // doomEdNum
                StateNum.S_ARACH_PLAZ, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_plasma, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_ARACH_PLEX, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_firxpl, // deathSound
                25, // speed
                (13), // radius
                (8), // height
                100, // mass
                5, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_MISSILE | MobjFlags.MF_DROPOFF | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Puff
                -1, // doomEdNum
                StateNum.S_PUFF1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Blood
                -1, // doomEdNum
                StateNum.S_BLOOD1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Tfog
                -1, // doomEdNum
                StateNum.S_TFOG, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Ifog
                -1, // doomEdNum
                StateNum.S_IFOG, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Teleportman
                14, // doomEdNum
                StateNum.S_NULL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_NOSECTOR, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Extrabfg
                -1, // doomEdNum
                StateNum.S_BFGEXP, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc0
                2018, // doomEdNum
                StateNum.S_ARM1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc1
                2019, // doomEdNum
                StateNum.S_ARM2, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc2
                2014, // doomEdNum
                StateNum.S_BON1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_COUNTITEM, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc3
                2015, // doomEdNum
                StateNum.S_BON2, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_COUNTITEM, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc4
                5, // doomEdNum
                StateNum.S_BKEY, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_NOTDMATCH, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc5
                13, // doomEdNum
                StateNum.S_RKEY, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_NOTDMATCH, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc6
                6, // doomEdNum
                StateNum.S_YKEY, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_NOTDMATCH, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc7
                39, // doomEdNum
                StateNum.S_YSKULL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_NOTDMATCH, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc8
                38, // doomEdNum
                StateNum.S_RSKULL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_NOTDMATCH, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc9
                40, // doomEdNum
                StateNum.S_BSKULL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_NOTDMATCH, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc10
                2011, // doomEdNum
                StateNum.S_STIM, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc11
                2012, // doomEdNum
                StateNum.S_MEDI, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc12
                2013, // doomEdNum
                StateNum.S_SOUL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_COUNTITEM, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Inv
                2022, // doomEdNum
                StateNum.S_PINV, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_COUNTITEM, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc13
                2023, // doomEdNum
                StateNum.S_PSTR, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_COUNTITEM, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Ins
                2024, // doomEdNum
                StateNum.S_PINS, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_COUNTITEM, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc14
                2025, // doomEdNum
                StateNum.S_SUIT, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc15
                2026, // doomEdNum
                StateNum.S_PMAP, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_COUNTITEM, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc16
                2045, // doomEdNum
                StateNum.S_PVIS, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_COUNTITEM, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Mega
                83, // doomEdNum
                StateNum.S_MEGA, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL | MobjFlags.MF_COUNTITEM, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Clip
                2007, // doomEdNum
                StateNum.S_CLIP, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc17
                2048, // doomEdNum
                StateNum.S_AMMO, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc18
                2010, // doomEdNum
                StateNum.S_ROCK, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc19
                2046, // doomEdNum
                StateNum.S_BROK, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc20
                2047, // doomEdNum
                StateNum.S_CELL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc21
                17, // doomEdNum
                StateNum.S_CELP, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc22
                2008, // doomEdNum
                StateNum.S_SHEL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc23
                2049, // doomEdNum
                StateNum.S_SBOX, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc24
                8, // doomEdNum
                StateNum.S_BPAK, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc25
                2006, // doomEdNum
                StateNum.S_BFUG, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Chaingun
                2002, // doomEdNum
                StateNum.S_MGUN, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc26
                2005, // doomEdNum
                StateNum.S_CSAW, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc27
                2003, // doomEdNum
                StateNum.S_LAUN, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc28
                2004, // doomEdNum
                StateNum.S_PLAS, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Shotgun
                2001, // doomEdNum
                StateNum.S_SHOT, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Supershotgun
                82, // doomEdNum
                StateNum.S_SHOT2, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPECIAL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc29
                85, // doomEdNum
                StateNum.S_TECH2LAMP, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc30
                86, // doomEdNum
                StateNum.S_TECH2LAMP, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc31
                2028, // doomEdNum
                StateNum.S_COLU, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc32
                30, // doomEdNum
                StateNum.S_TALLGRNCOL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc33
                31, // doomEdNum
                StateNum.S_SHRTGRNCOL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc34
                32, // doomEdNum
                StateNum.S_TALLREDCOL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc35
                33, // doomEdNum
                StateNum.S_SHRTREDCOL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc36
                37, // doomEdNum
                StateNum.S_SKULLCOL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc37
                36, // doomEdNum
                StateNum.S_HEARTCOL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc38
                41, // doomEdNum
                StateNum.S_EVILEYE, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc39
                42, // doomEdNum
                StateNum.S_FLOATSKULL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc40
                43, // doomEdNum
                StateNum.S_TORCHTREE, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc41
                44, // doomEdNum
                StateNum.S_BLUETORCH, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc42
                45, // doomEdNum
                StateNum.S_GREENTORCH, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc43
                46, // doomEdNum
                StateNum.S_REDTORCH, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc44
                55, // doomEdNum
                StateNum.S_BTORCHSHRT, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc45
                56, // doomEdNum
                StateNum.S_GTORCHSHRT, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc46
                57, // doomEdNum
                StateNum.S_RTORCHSHRT, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc47
                47, // doomEdNum
                StateNum.S_STALAGTITE, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc48
                48, // doomEdNum
                StateNum.S_TECHPILLAR, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc49
                34, // doomEdNum
                StateNum.S_CANDLESTIK, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                0, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc50
                35, // doomEdNum
                StateNum.S_CANDELABRA, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc51
                49, // doomEdNum
                StateNum.S_BLOODYTWITCH, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (68), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc52
                50, // doomEdNum
                StateNum.S_MEAT2, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (84), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc53
                51, // doomEdNum
                StateNum.S_MEAT3, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (84), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc54
                52, // doomEdNum
                StateNum.S_MEAT4, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (68), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc55
                53, // doomEdNum
                StateNum.S_MEAT5, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (52), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc56
                59, // doomEdNum
                StateNum.S_MEAT2, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (84), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc57
                60, // doomEdNum
                StateNum.S_MEAT4, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (68), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc58
                61, // doomEdNum
                StateNum.S_MEAT3, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (52), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc59
                62, // doomEdNum
                StateNum.S_MEAT5, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (52), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc60
                63, // doomEdNum
                StateNum.S_BLOODYTWITCH, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (68), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc61
                22, // doomEdNum
                StateNum.S_HEAD_DIE1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                0, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc62
                15, // doomEdNum
                StateNum.S_PLAY_DIE7, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                0, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc63
                18, // doomEdNum
                StateNum.S_POSS_DIE5, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                0, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc64
                21, // doomEdNum
                StateNum.S_SARG_DIE6, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                0, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc65
                23, // doomEdNum
                StateNum.S_SKULL_DIE6, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                0, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc66
                20, // doomEdNum
                StateNum.S_TROO_DIE5, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                0, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc67
                19, // doomEdNum
                StateNum.S_POSS_DIE5, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                0, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc68
                10, // doomEdNum
                StateNum.S_PLAY_XDIE9, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                0, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc69
                12, // doomEdNum
                StateNum.S_PLAY_XDIE9, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                0, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc70
                28, // doomEdNum
                StateNum.S_HEADONASTICK, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc71
                24, // doomEdNum
                StateNum.S_GIBS, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                0, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc72
                27, // doomEdNum
                StateNum.S_HEADONASTICK, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc73
                29, // doomEdNum
                StateNum.S_HEADCANDLES, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc74
                25, // doomEdNum
                StateNum.S_DEADSTICK, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc75
                26, // doomEdNum
                StateNum.S_LIVESTICK, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc76
                54, // doomEdNum
                StateNum.S_BIGTREE, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (32), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc77
                70, // doomEdNum
                StateNum.S_BBAR1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc78
                73, // doomEdNum
                StateNum.S_HANGNOGUTS, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (88), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc79
                74, // doomEdNum
                StateNum.S_HANGBNOBRAIN, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (88), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc80
                75, // doomEdNum
                StateNum.S_HANGTLOOKDN, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (64), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc81
                76, // doomEdNum
                StateNum.S_HANGTSKULL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (64), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc82
                77, // doomEdNum
                StateNum.S_HANGTLOOKUP, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (64), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc83
                78, // doomEdNum
                StateNum.S_HANGTNOBRAIN, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (16), // radius
                (64), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_SOLID | MobjFlags.MF_SPAWNCEILING | MobjFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc84
                79, // doomEdNum
                StateNum.S_COLONGIBS, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc85
                80, // doomEdNum
                StateNum.S_SMALLPOOL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP, // flags
                StateNum.S_NULL // raiseState
            ),

            new MobjInfo( // MobjType.Misc86
                81, // doomEdNum
                StateNum.S_BRAINSTEM, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SoundType.sfx_None, // seeSound
                8, // reactionTime
                SoundType.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SoundType.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // missileState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SoundType.sfx_None, // deathSound
                0, // speed
                (20), // radius
                (16), // height
                100, // mass
                0, // damage
                SoundType.sfx_None, // activeSound
                MobjFlags.MF_NOBLOCKMAP, // flags
                StateNum.S_NULL // raiseState
            )

        };
    }
}
