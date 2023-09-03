using UnityEngine;

using System.IO;
using System.Linq;

namespace NEP.DOOMLAB.WAD
{
    public class WADManager
    {
        public WADManager()
        {
            Instance = this;
        }

        public static WADManager Instance { get; private set; }

        public WADFile IWAD;

        private readonly string[] iwads = new string[]
        {
            "DOOM",
            "DOOM2",
            "TNT",
            "PLUTONIA",
            "FREEDOOM1",
            "FREEDOOM2",
        };

        public WADFile LoadWAD(string file)
        {
            var wadFile = new WADFile(file);
            wadFile.ReadHeader();
            wadFile.ReadIndexEntries();
            wadFile.ReadPalette();
            wadFile.ReadAllSounds();
            wadFile.ReadAllSprites();

            return wadFile;
        }

        public string GetIWAD()
        {
            string path = MelonLoader.MelonUtils.UserDataDirectory;
            string[] files = Directory.GetFiles(path);
            string result = "";

            for(int i = 0; i < iwads.Length; i++)
            {
                for(int j = 0; j < files.Length; j++)
                {
                    string iwadName = iwads[i] + ".WAD";
                    string file = files[j];
                    string fileName = Path.GetFileName(file);

                    if (fileName.ToLower() == iwadName.ToLower())
                    {
                        Debug.Log(file);
                        result = file;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
