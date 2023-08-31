using UnityEngine;

using System.IO;

namespace NEP.DOOMLAB.WAD
{
    public class WADManager
    {
        public WADManager()
        {
            Instance = this;
        }

        public static WADManager Instance { get; private set; }

        public WADFile file;
        public string pathToWAD => Path.Combine(MelonLoader.MelonUtils.UserDataDirectory, "DOOM2.wad");

        public void LoadWAD(string pathToWAD)
        {
            file = new WADFile(pathToWAD);
            file.ReadHeader();
            file.ReadIndexEntries();
            file.ReadPalette();
            file.ListSprites();
        }
    }
}
