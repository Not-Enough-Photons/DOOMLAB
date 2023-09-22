using System.Collections.Generic;
using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Entities;
using NEP.DOOMLAB.Sound;

namespace NEP.DOOMLAB.ZDOOM
{
    public class ZDActor
    {
        public static Dictionary<string, MobjType> ActorClassTable = new Dictionary<string, MobjType>()
        {
            { "grunt", MobjType.MT_POSSESSED },
            { "shotguy", MobjType.MT_SHOTGUY },
            { "vile", MobjType.MT_VILE },
            { "skeleton", MobjType.MT_UNDEAD },
            { "fatso", MobjType.MT_FATSO },
            { "chainguy", MobjType.MT_CHAINGUY },
            { "imp", MobjType.MT_TROOP },
            { "demon", MobjType.MT_SERGEANT },
            { "spectre", MobjType.MT_SHADOWS },
            { "caco", MobjType.MT_HEAD },
            { "baron", MobjType.MT_BRUISER },
            { "knight", MobjType.MT_KNIGHT },
            { "skull", MobjType.MT_SKULL },
            { "spider", MobjType.MT_SPIDER },
            { "baby", MobjType.MT_BABY },
            { "cyber", MobjType.MT_CYBORG },
            { "pain", MobjType.MT_PAIN },
            { "wolfss", MobjType.MT_WOLFSS },
            { "keen", MobjType.MT_KEEN },
            { "brain", MobjType.MT_BOSSBRAIN }
        };
    }
}