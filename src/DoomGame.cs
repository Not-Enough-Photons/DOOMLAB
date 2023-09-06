using System;
using UnityEngine;

namespace NEP.DOOMLAB.Game
{
    public class DoomGame
    {
        public static class RNG
        {
            public enum PRandomType
            {
                pr_skullfly,                // #1
                pr_damage,                  // #2
                pr_crush,                   // #3
                pr_genlift,                 // #4
                pr_killtics,                // #5
                pr_damagemobj,              // #6
                pr_painchance,              // #7
                pr_lights,                  // #8
                pr_explode,                 // #9
                pr_respawn,                 // #10
                pr_lastlook,                // #11
                pr_spawnthing,              // #12
                pr_spawnpuff,               // #13
                pr_spawnblood,              // #14
                pr_missile,                 // #15
                pr_shadow,                  // #16
                pr_plats,                   // #17
                pr_punch,                   // #18
                pr_punchangle,              // #19
                pr_saw,                     // #20
                pr_plasma,                  // #21
                pr_gunshot,                 // #22
                pr_misfire,                 // #23
                pr_shotgun,                 // #24
                pr_bfg,                     // #25
                pr_slimehurt,               // #26
                pr_dmspawn,                 // #27
                pr_missrange,               // #28
                pr_trywalk,                 // #29
                pr_newchase,                // #30
                pr_newchasedir,             // #31
                pr_see,                     // #32
                pr_facetarget,              // #33
                pr_posattack,               // #34
                pr_sposattack,              // #35
                pr_cposattack,              // #36
                pr_spidrefire,              // #37
                pr_troopattack,             // #38
                pr_sargattack,              // #39
                pr_headattack,              // #40
                pr_bruisattack,             // #41
                pr_tracer,                  // #42
                pr_skelfist,                // #43
                pr_scream,                  // #44
                pr_brainscream,             // #45
                pr_cposrefire,              // #46
                pr_brainexp,                // #47
                pr_spawnfly,                // #48
                pr_misc,                    // #49
                pr_all_in_one,              // #50
                                            // Start new entries -- add new entries below

                // End of new entries
                NUMPRCLASS               // MUST be last item in list
            }

            public static readonly int[] rngTable = new int[]
            {
                0,   8, 109, 220, 222, 241, 149, 107,  75, 248, 254, 140,  16,  66 ,
                74,  21, 211,  47,  80, 242, 154,  27, 205, 128, 161,  89,  77,  36 ,
                95, 110,  85,  48, 212, 140, 211, 249,  22,  79, 200,  50,  28, 188 ,
                52, 140, 202, 120,  68, 145,  62,  70, 184, 190,  91, 197, 152, 224 ,
                149, 104,  25, 178, 252, 182, 202, 182, 141, 197,   4,  81, 181, 242 ,
                145,  42,  39, 227, 156, 198, 225, 193, 219,  93, 122, 175, 249,   0 ,
                175, 143,  70, 239,  46, 246, 163,  53, 163, 109, 168, 135,   2, 235 ,
                25,  92,  20, 145, 138,  77,  69, 166,  78, 176, 173, 212, 166, 113 ,
                94, 161,  41,  50, 239,  49, 111, 164,  70,  60,   2,  37, 171,  75 ,
                136, 156,  11,  56,  42, 146, 138, 229,  73, 146,  77,  61,  98, 196 ,
                135, 106,  63, 197, 195,  86,  96, 203, 113, 101, 170, 247, 181, 113 ,
                80, 250, 108,   7, 255, 237, 129, 226,  79, 107, 112, 166, 103, 241 ,
                24, 223, 239, 120, 198,  58,  60,  82, 128,   3, 184,  66, 143, 224 ,
                145, 224,  81, 206, 163,  45,  63,  90, 168, 114,  59,  33, 159,  95 ,
                28, 139, 123,  98, 125, 196,  15,  70, 194, 253,  54,  14, 109, 226 ,
                71,  17, 161,  93, 186,  87, 244, 138,  20,  52, 123, 251,  26,  36 ,
                17,  46,  52, 231, 232,  76,  31, 221,  84,  37, 216, 165, 212, 106 ,
                197, 242,  98,  43,  39, 175, 254, 145, 190,  84, 118, 222, 187, 136 ,
                120, 163, 236, 249
            };

            private static int rndIndex = 0;
            private static int prndIndex = 0;

            private static int seed = 1993; // killough 3/26/98: The seed

            private static long[] rngSeeder = new long[(int)PRandomType.NUMPRCLASS];

            // using killough's RNG method for a more normally distributed probability
            public static int P_Random(PRandomType prClass = PRandomType.pr_all_in_one)
            {
                long boom;

                boom = rngSeeder[(int)prClass] * seed;

                // killough 3/26/98: add pr_class*2 to addend

                rngSeeder[(int)prClass] = boom * 1664525 + 221297 + (int)prClass * 2;

                boom >>= 20;

                return (int)boom & 255;
            }

            public static int P_Random()
            {
                if (prndIndex + 1 >= rngTable.Length)
                {
                    prndIndex = 0;
                }
                else
                {
                    prndIndex++;
                }

                return rngTable[prndIndex];
            }

            public static int M_Random()
            {
                if (rndIndex + 1 >= rngTable.Length)
                {
                    rndIndex = 0;
                }
                else
                {
                    rndIndex++;
                }

                rndIndex += 1 % 255;
                return rngTable[rndIndex];
            }

            public static void M_ClearRandom()
            {
                rndIndex = prndIndex = 0;
            }
        }

        public DoomGame()
        {
            Instance = this;
        }

        public static DoomGame Instance { get; private set; }

        public Action OnTick;

        public float timeInterval = 1f / 35f; // DOOM updates at 1/35th of a second

        public bool fastMonsters = false;

        private float ticTimer;

        public void Update()
        {
            ticTimer += Time.deltaTime;

            if(ticTimer > timeInterval)
            {
                OnTick?.Invoke();
                ticTimer = 0f;
            }
        }
    }
}
