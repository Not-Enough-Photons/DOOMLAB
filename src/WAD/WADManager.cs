using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NEP.DOOMLAB.WAD
{
    public class WADManager : MonoBehaviour
    {
        public static WADManager Instance { get; private set; }

        public WADFile file;
        public string pathToWAD;

        private void Awake()
        {
            Instance = this;
        }

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
