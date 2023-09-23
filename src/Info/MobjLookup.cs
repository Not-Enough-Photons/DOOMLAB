using System.Collections.Generic;

namespace NEP.DOOMLAB.Data
{
    public static class MobjLookup
    {
        public static Dictionary<string, MobjType> npcLookup = new Dictionary<string, MobjType>()
        {
            { "Zombieman", MobjType.MT_POSSESSED },
            { "Shotgun Guy", MobjType.MT_SHOTGUY },
            { "Chaingun Guy", MobjType.MT_CHAINGUY },
            { "Imp", MobjType.MT_TROOP },
            { "Pinky Demon", MobjType.MT_SERGEANT },
            { "Spectre", MobjType.MT_SHADOWS},
            { "Lost Soul", MobjType.MT_SKULL },
            { "Cacodemon", MobjType.MT_HEAD },
            { "Hell Knight", MobjType.MT_KNIGHT },
            { "Baron of Hell", MobjType.MT_BRUISER },
            { "Arachnotron", MobjType.MT_BABY },
            { "Mancubus", MobjType.MT_FATSO },
            { "Revenant", MobjType.MT_UNDEAD },
            { "Pain Elemental", MobjType.MT_PAIN },
            { "Arch-Vile", MobjType.MT_VILE },
            { "Spider Mastermind", MobjType.MT_SPIDER },
            { "Cyberdemon", MobjType.MT_CYBORG },
            { "SS Soldier", MobjType.MT_WOLFSS },
            { "Commander Keen", MobjType.MT_KEEN },
            { "Icon of Sin", MobjType.MT_BOSSBRAIN }
        };

        public static Dictionary<string, MobjType> itemLookup = new Dictionary<string, MobjType>()
        {
            { "Armor Bonus", MobjType.MT_MISC2 },
            { "Armor", MobjType.MT_MISC0 },
            { "Backpack", MobjType.MT_MISC24 },
            { "Berserk", MobjType.MT_MISC13 },
            { "Blue Keycard", MobjType.MT_MISC4 },
            { "Blue Skull Key", MobjType.MT_MISC9 },
            { "Explosive Barrel", MobjType.MT_BARREL },
            { "Health Bonus", MobjType.MT_MISC2 },
            { "Invulnerability", MobjType.MT_INV },
            { "Light Amplification Visor", MobjType.MT_MISC16 },
            { "Medikit", MobjType.MT_MISC11 },
            { "Megaarmor", MobjType.MT_MISC1 },
            { "Megasphere", MobjType.MT_MEGA },
            { "Partial Invisibility", MobjType.MT_INS },
            { "Red Keycard", MobjType.MT_MISC5 },
            { "Red Skull Key", MobjType.MT_MISC8 },
            { "Soulsphere", MobjType.MT_MISC12 },
            { "Stimpack", MobjType.MT_MISC10 },
            { "Suit", MobjType.MT_MISC14 },
            { "Yellow Keycard", MobjType.MT_MISC6 },
            { "Yellow Skull Key", MobjType.MT_MISC7 }
        };
    }
}