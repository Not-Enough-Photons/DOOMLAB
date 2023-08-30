using NEP.DOOMLAB.Rendering;
using NEP.DOOMLAB.WAD;
using NEP.DOOMLAB.WAD.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NEP.DOOMLAB.Game
{
    public class DoomGame : MonoBehaviour
    {
        public static Action OnTick;

        public WADManager WADManager;

        public List<SpriteDef> SpriteDefs;

        public float timeInterval = (1 / 35f) * 10; // DOOM updates at 1/35th of a second

        private float ticTimer;

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            ticTimer += Time.deltaTime;

            if(ticTimer > timeInterval)
            {
                OnTick?.Invoke();
                ticTimer = 0f;
            }
        }

        public void Initialize()
        {
            WADManager.LoadWAD(WADManager.pathToWAD);
            SpriteLumpGenerator.spritePatches = WADManager.file.patches;
            SpriteLumpGenerator.InitSpriteDefs();

            SpriteDefs = SpriteLumpGenerator.sprites.ToList();
        }
    }
}
