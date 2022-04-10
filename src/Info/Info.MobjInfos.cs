using NEP.BWDOOM.Entities;
using NEP.BWDOOM.Sound;

namespace NEP.BWDOOM.Info
{
    public class MobjInfos
    {
        public static MOBJInfo[] infos = new MOBJInfo[]
        {
            new MOBJInfo( // MobjType.Player
                -1, // doomEdNum
                StateNum.S_PLAY, // spawnState
                100, // spawnHealth
                StateNum.S_PLAY_RUN1, // seeState
                SFXEnum.sfx_None, // seeSound
                0, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_PLAY_PAIN, // painState
                255, // painChance
                SFXEnum.sfx_plpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_PLAY_ATK1, // MF_MISSILEState
                StateNum.S_PLAY_DIE1, // deathState
                StateNum.S_PLAY_XDIE1, // xdeathState
                SFXEnum.sfx_pldeth, // deathSound
                0, // speed
                16, // radius
                56, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_DROPOFF | MOBJFlags.MF_PICKUP | MOBJFlags.MF_NOTDMATCH, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Possessed
                3004, // doomEdNum
                StateNum.S_POSS_STND, // spawnState
                20, // spawnHealth
                StateNum.S_POSS_RUN1, // seeState
                SFXEnum.sfx_posit1, // seeSound
                8, // reactionTime
                SFXEnum.sfx_pistol, // attackSound
                StateNum.S_POSS_PAIN, // painState
                200, // painChance
                SFXEnum.sfx_popain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_POSS_ATK1, // MF_MISSILEState
                StateNum.S_POSS_DIE1, // deathState
                StateNum.S_POSS_XDIE1, // xdeathState
                SFXEnum.sfx_podth1, // deathSound
                8, // speed
                20, // radius
                56, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_posact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_POSS_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.Shotguy
                9, // doomEdNum
                StateNum.S_SPOS_STND, // spawnState
                30, // spawnHealth
                StateNum.S_SPOS_RUN1, // seeState
                SFXEnum.sfx_posit2, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_SPOS_PAIN, // painState
                170, // painChance
                SFXEnum.sfx_popain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_POSS_ATK1, // MF_MISSILEState
                StateNum.S_POSS_DIE1, // deathState
                StateNum.S_SPOS_XDIE1, // xdeathState
                SFXEnum.sfx_podth2, // deathSound
                8, // speed
                20, // radius
                56, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_posact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_SPOS_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.Vile
                64, // doomEdNum
                StateNum.S_VILE_STND, // spawnState
                700, // spawnHealth
                StateNum.S_VILE_RUN1, // seeState
                SFXEnum.sfx_vilsit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_VILE_PAIN, // painState
                10, // painChance
                SFXEnum.sfx_vipain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_VILE_ATK1, // MF_MISSILEState
                StateNum.S_VILE_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_vildth, // deathSound
                15, // speed
                20, // radius
                56, // height
                500, // mass
                0, // damage
                SFXEnum.sfx_vilact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Fire
                -1, // doomEdNum
                StateNum.S_FIRE1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_None, // deathSound
                0, // speed
                20, // radius
                16, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Undead
                66, // doomEdNum
                StateNum.S_SKEL_STND, // spawnState
                300, // spawnHealth
                StateNum.S_SKEL_RUN1, // seeState
                SFXEnum.sfx_skesit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_SKEL_PAIN, // painState
                100, // painChance
                SFXEnum.sfx_popain, // painSound
                StateNum.S_SKEL_FIST1, // meleeState
                StateNum.S_SKEL_MISS1, // MF_MISSILEState
                StateNum.S_SKEL_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_skedth, // deathSound
                10, // speed
                20, // radius
                56, // height
                500, // mass
                0, // damage
                SFXEnum.sfx_skeact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_SKEL_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.Tracer
                -1, // doomEdNum
                StateNum.S_TRACER, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_skeact, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_TRACEEXP1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_barexp, // deathSound
                10, // speed
                11, // radius
                8, // height
                100, // mass
                10, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_MISSILE | MOBJFlags.MF_DROPOFF | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Smoke
                -1, // doomEdNum
                StateNum.S_SMOKE1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_None, // deathSound
                0, // speed
                20, // radius
                16, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Fatso
                67, // doomEdNum
                StateNum.S_FATT_STND, // spawnState
                600, // spawnHealth
                StateNum.S_FATT_RUN1, // seeState
                SFXEnum.sfx_mansit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_FATT_PAIN, // painState
                80, // painChance
                SFXEnum.sfx_mnpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_FATT_ATK1, // MF_MISSILEState
                StateNum.S_FATT_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_mandth, // deathSound
                8, // speed
                48, // radius
                64, // height
                1000, // mass
                0, // damage
                SFXEnum.sfx_posact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_FATT_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.Fatshot
                -1, // doomEdNum
                StateNum.S_FATSHOT1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_firsht, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_FATSHOTX1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_firxpl, // deathSound
                20, // speed
                6, // radius
                8, // height
                100, // mass
                8, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_MISSILE | MOBJFlags.MF_DROPOFF | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Chainguy
                65, // doomEdNum
                StateNum.S_CPOS_STND, // spawnState
                70, // spawnHealth
                StateNum.S_CPOS_RUN1, // seeState
                SFXEnum.sfx_posit2, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_CPOS_PAIN, // painState
                170, // painChance
                SFXEnum.sfx_popain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_CPOS_ATK1, // MF_MISSILEState
                StateNum.S_CPOS_DIE1, // deathState
                StateNum.S_CPOS_XDIE1, // xdeathState
                SFXEnum.sfx_podth1, // deathSound
                8, // speed
                20, // radius
                56, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_posact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_CPOS_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.Troop
                3001, // doomEdNum
                StateNum.S_TROO_STND, // spawnState
                60, // spawnHealth
                StateNum.S_TROO_RUN1, // seeState
                SFXEnum.sfx_bgsit1, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_TROO_PAIN, // painState
                200, // painChance
                SFXEnum.sfx_popain, // painSound
                StateNum.S_TROO_ATK1, // meleeState
                StateNum.S_TROO_ATK1, // MF_MISSILEState
                StateNum.S_TROO_DIE1, // deathState
                StateNum.S_TROO_XDIE1, // xdeathState
                SFXEnum.sfx_bgdth1, // deathSound
                8, // speed
                20, // radius
                56, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_bgact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_TROO_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.Sergeant
                3002, // doomEdNum
                StateNum.S_SARG_STND, // spawnState
                150, // spawnHealth
                StateNum.S_SARG_RUN1, // seeState
                SFXEnum.sfx_sgtsit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_sgtatk, // attackSound
                StateNum.S_SARG_PAIN, // painState
                180, // painChance
                SFXEnum.sfx_dmpain, // painSound
                StateNum.S_SARG_ATK1, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_SARG_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_sgtdth, // deathSound
                10, // speed
                30, // radius
                56, // height
                400, // mass
                0, // damage
                SFXEnum.sfx_dmact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_SARG_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.MF_SHADOWS
                58, // doomEdNum
                StateNum.S_SARG_STND, // spawnState
                150, // spawnHealth
                StateNum.S_SARG_RUN1, // seeState
                SFXEnum.sfx_sgtsit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_sgtatk, // attackSound
                StateNum.S_SARG_PAIN, // painState
                180, // painChance
                SFXEnum.sfx_dmpain, // painSound
                StateNum.S_SARG_ATK1, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_SARG_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_sgtdth, // deathSound
                10, // speed
                30, // radius
                56, // height
                400, // mass
                0, // damage
                SFXEnum.sfx_dmact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_SHADOW | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_SARG_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.Head
                3005, // doomEdNum
                StateNum.S_HEAD_STND, // spawnState
                400, // spawnHealth
                StateNum.S_HEAD_RUN1, // seeState
                SFXEnum.sfx_cacsit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_HEAD_PAIN, // painState
                128, // painChance
                SFXEnum.sfx_dmpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_HEAD_ATK1, // MF_MISSILEState
                StateNum.S_HEAD_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_cacdth, // deathSound
                8, // speed
                31, // radius
                56, // height
                400, // mass
                0, // damage
                SFXEnum.sfx_dmact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_FLOAT | MOBJFlags.MF_NOGRAVITY | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_HEAD_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.Bruiser
                3003, // doomEdNum
                StateNum.S_BOSS_STND, // spawnState
                1000, // spawnHealth
                StateNum.S_BOSS_RUN1, // seeState
                SFXEnum.sfx_brssit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_BOSS_PAIN, // painState
                50, // painChance
                SFXEnum.sfx_dmpain, // painSound
                StateNum.S_BOSS_ATK1, // meleeState
                StateNum.S_BOSS_ATK1, // MF_MISSILEState
                StateNum.S_BOSS_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_brsdth, // deathSound
                8, // speed
                24, // radius
                64, // height
                1000, // mass
                0, // damage
                SFXEnum.sfx_dmact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_BOSS_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.Bruisershot
                -1, // doomEdNum
                StateNum.S_BRBALL1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_firsht, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_BRBALLX1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_firxpl, // deathSound
                15, // speed
                6, // radius
                8, // height
                100, // mass
                8, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_MISSILE | MOBJFlags.MF_DROPOFF | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Knight
                69, // doomEdNum
                StateNum.S_BOS2_STND, // spawnState
                500, // spawnHealth
                StateNum.S_BOS2_RUN1, // seeState
                SFXEnum.sfx_kntsit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_BOS2_PAIN, // painState
                50, // painChance
                SFXEnum.sfx_dmpain, // painSound
                StateNum.S_BOS2_ATK1, // meleeState
                StateNum.S_BOS2_ATK1, // MF_MISSILEState
                StateNum.S_BOS2_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_kntdth, // deathSound
                8, // speed
                24, // radius
                64, // height
                1000, // mass
                0, // damage
                SFXEnum.sfx_dmact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_BOS2_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.Skull
                3006, // doomEdNum
                StateNum.S_SKULL_STND, // spawnState
                100, // spawnHealth
                StateNum.S_SKULL_RUN1, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_sklatk, // attackSound
                StateNum.S_SKULL_PAIN, // painState
                256, // painChance
                SFXEnum.sfx_dmpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_SKULL_ATK1, // MF_MISSILEState
                StateNum.S_SKULL_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_firxpl, // deathSound
                8, // speed
                16, // radius
                56, // height
                50, // mass
                3, // damage
                SFXEnum.sfx_dmact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_FLOAT | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Spider
                7, // doomEdNum
                StateNum.S_SPID_STND, // spawnState
                3000, // spawnHealth
                StateNum.S_SPID_RUN1, // seeState
                SFXEnum.sfx_spisit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_shotgn, // attackSound
                StateNum.S_SPID_PAIN, // painState
                40, // painChance
                SFXEnum.sfx_dmpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_SPID_ATK1, // MF_MISSILEState
                StateNum.S_SPID_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_spidth, // deathSound
                12, // speed
                128, // radius
                100, // height
                1000, // mass
                0, // damage
                SFXEnum.sfx_dmact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Baby
                68, // doomEdNum
                StateNum.S_BSPI_STND, // spawnState
                500, // spawnHealth
                StateNum.S_BSPI_RUN1, // seeState
                SFXEnum.sfx_bspsit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_BSPI_PAIN, // painState
                128, // painChance
                SFXEnum.sfx_dmpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_BSPI_ATK1, // MF_MISSILEState
                StateNum.S_BSPI_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_bspdth, // deathSound
                12, // speed
                64, // radius
                64, // height
                600, // mass
                0, // damage
                SFXEnum.sfx_bspact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_BSPI_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.Cyborg
                16, // doomEdNum
                StateNum.S_CYBER_STND, // spawnState
                4000, // spawnHealth
                StateNum.S_CYBER_RUN1, // seeState
                SFXEnum.sfx_cybsit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_CYBER_PAIN, // painState
                20, // painChance
                SFXEnum.sfx_dmpain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_CYBER_ATK1, // MF_MISSILEState
                StateNum.S_CYBER_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_cybdth, // deathSound
                16, // speed
                40, // radius
                110, // height
                1000, // mass
                0, // damage
                SFXEnum.sfx_dmact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Pain
                71, // doomEdNum
                StateNum.S_PAIN_STND, // spawnState
                400, // spawnHealth
                StateNum.S_PAIN_RUN1, // seeState
                SFXEnum.sfx_pesit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_PAIN_PAIN, // painState
                128, // painChance
                SFXEnum.sfx_pepain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_PAIN_ATK1, // MF_MISSILEState
                StateNum.S_PAIN_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_pedth, // deathSound
                8, // speed
                31, // radius
                56, // height
                400, // mass
                0, // damage
                SFXEnum.sfx_dmact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_FLOAT | MOBJFlags.MF_NOGRAVITY | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_PAIN_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.Wolfss
                84, // doomEdNum
                StateNum.S_SSWV_STND, // spawnState
                50, // spawnHealth
                StateNum.S_SSWV_RUN1, // seeState
                SFXEnum.sfx_sssit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_SSWV_PAIN, // painState
                170, // painChance
                SFXEnum.sfx_popain, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_SSWV_ATK1, // MF_MISSILEState
                StateNum.S_SSWV_DIE1, // deathState
                StateNum.S_SSWV_XDIE1, // xdeathState
                SFXEnum.sfx_ssdth, // deathSound
                8, // speed
                20, // radius
                56, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_posact, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_SSWV_RAISE1 // raiseState
            ),

            new MOBJInfo( // MobjType.Keen
                72, // doomEdNum
                StateNum.S_KEENSTND, // spawnState
                100, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_KEENPAIN, // painState
                256, // painChance
                SFXEnum.sfx_keenpn, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_COMMKEEN, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_keendt, // deathSound
                0, // speed
                16, // radius
                72, // height
                10000000, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SPAWNCEILING | MOBJFlags.MF_NOGRAVITY | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_COUNTKILL, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Bossbrain
                88, // doomEdNum
                StateNum.S_BRAIN, // spawnState
                250, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_BRAIN_PAIN, // painState
                255, // painChance
                SFXEnum.sfx_bospn, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_BRAIN_DIE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_bosdth, // deathSound
                0, // speed
                16, // radius
                16, // height
                10000000, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Bossspit
                89, // doomEdNum
                StateNum.S_BRAINEYE, // spawnState
                1000, // spawnHealth
                StateNum.S_BRAINEYESEE, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_None, // deathSound
                0, // speed
                20, // radius
                32, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_NOSECTOR, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Bosstarget
                87, // doomEdNum
                StateNum.S_NULL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_None, // deathSound
                0, // speed
                20, // radius
                32, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_NOSECTOR, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Spawnshot
                -1, // doomEdNum
                StateNum.S_SPAWN1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_bospit, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_firxpl, // deathSound
                10, // speed
                6, // radius
                32, // height
                100, // mass
                3, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_MISSILE | MOBJFlags.MF_DROPOFF | MOBJFlags.MF_NOGRAVITY | MOBJFlags.MF_NOCLIP, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Spawnfire
                -1, // doomEdNum
                StateNum.S_SPAWNFIRE1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_None, // deathSound
                0, // speed
                20, // radius
                16, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Barrel
                2035, // doomEdNum
                StateNum.S_BAR1, // spawnState
                20, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_BEXP, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_barexp, // deathSound
                0, // speed
                10, // radius
                42, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_SOLID | MOBJFlags.MF_SHOOTABLE | MOBJFlags.MF_NOBLOOD, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Troopshot
                -1, // doomEdNum
                StateNum.S_TBALL1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_firsht, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_TBALLX1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_firxpl, // deathSound
                10, // speed
                6, // radius
                8, // height
                100, // mass
                3, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_MISSILE | MOBJFlags.MF_DROPOFF | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Headshot
                -1, // doomEdNum
                StateNum.S_RBALL1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_firsht, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_RBALLX1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_firxpl, // deathSound
                10 , // speed
                6, // radius
                8, // height
                100, // mass
                5, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_MISSILE | MOBJFlags.MF_DROPOFF | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Rocket
                -1, // doomEdNum
                StateNum.S_ROCKET, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_rlaunc, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_EXPLODE1, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_barexp, // deathSound
                20 , // speed
                11, // radius
                8, // height
                100, // mass
                20, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_MISSILE | MOBJFlags.MF_DROPOFF | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Plasma
                -1, // doomEdNum
                StateNum.S_PLASBALL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_plasma, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_PLASEXP, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_firxpl, // deathSound
                25 , // speed
                13, // radius
                8, // height
                100, // mass
                5, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_MISSILE | MOBJFlags.MF_DROPOFF | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Bfg
                -1, // doomEdNum
                StateNum.S_BFGSHOT, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_BFGLAND, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_rxplod, // deathSound
                25 , // speed
                13, // radius
                8, // height
                100, // mass
                100, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_MISSILE | MOBJFlags.MF_DROPOFF | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Arachplaz
                -1, // doomEdNum
                StateNum.S_ARACH_PLAZ, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_plasma, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_ARACH_PLEX, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_firxpl, // deathSound
                25 , // speed
                13, // radius
                8, // height
                100, // mass
                5, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_MISSILE | MOBJFlags.MF_DROPOFF | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Puff
                -1, // doomEdNum
                StateNum.S_PUFF1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_None, // deathSound
                0, // speed
                20, // radius
                16, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Blood
                -1, // doomEdNum
                StateNum.S_BLOOD1, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_None, // deathSound
                0, // speed
                20, // radius
                16, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Tfog
                -1, // doomEdNum
                StateNum.S_TFOG, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_None, // deathSound
                0, // speed
                20, // radius
                16, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Ifog
                -1, // doomEdNum
                StateNum.S_IFOG, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_None, // deathSound
                0, // speed
                20, // radius
                16, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Teleportman
                14, // doomEdNum
                StateNum.S_NULL, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_None, // deathSound
                0, // speed
                20, // radius
                16, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_NOSECTOR, // flags
                StateNum.S_NULL // raiseState
            ),

            new MOBJInfo( // MobjType.Extrabfg
                -1, // doomEdNum
                StateNum.S_BFGEXP, // spawnState
                1000, // spawnHealth
                StateNum.S_NULL, // seeState
                SFXEnum.sfx_None, // seeSound
                8, // reactionTime
                SFXEnum.sfx_None, // attackSound
                StateNum.S_NULL, // painState
                0, // painChance
                SFXEnum.sfx_None, // painSound
                StateNum.S_NULL, // meleeState
                StateNum.S_NULL, // MF_MISSILEState
                StateNum.S_NULL, // deathState
                StateNum.S_NULL, // xdeathState
                SFXEnum.sfx_None, // deathSound
                0, // speed
                20, // radius
                16, // height
                100, // mass
                0, // damage
                SFXEnum.sfx_None, // activeSound
                MOBJFlags.MF_NOBLOCKMAP | MOBJFlags.MF_NOGRAVITY, // flags
                StateNum.S_NULL // raiseState
            ),
        };
    }
}
