using NEP.DOOMLAB.Rendering;
using NEP.DOOMLAB.WAD;
using NEP.DOOMLAB.WAD.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NEP.DOOMLAB.Game
{
    public class DoomGame
    {
        public DoomGame()
        {
            Instance = this;
        }

        public static DoomGame Instance { get; private set; }

        public Action OnTick;

        public List<SpriteDef> SpriteDefs;

        public float timeInterval = 1f / 35f; // DOOM updates at 1/35th of a second

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

        public void Initialize()
        {
            SpriteLumpGenerator.spritePatches = WADManager.Instance.file.patches;
            SpriteLumpGenerator.InitSpriteDefs();

            SpriteDefs = SpriteLumpGenerator.sprites.ToList();
        }
    }
}
