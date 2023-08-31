using MelonLoader;
using NEP.DOOMLAB.WAD;
using BoneLib;
using NEP.DOOMLAB.Game;
using UnityEngine;
using SLZ.Marrow.Warehouse;
using NEP.DOOMLAB.Entities;
using System.IO;

namespace NEP.DOOMLAB
{
    public static class BuildInfo
    {
        public const string Name = "DOOMLAB"; // Name of the Mod.  (MUST BE SET)
        public const string Description = ""; // Description for the Mod.  (Set as null if none)
        public const string Author = ""; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "0.0.1"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class Main : MelonMod
    {
        public AssetBundle bundle;
        public static GameObject mobjTemplate;
        public static Mobj player;

        public override void OnInitializeMelon()
        {
            bundle = AssetBundle.LoadFromFile(Path.Combine(MelonUtils.UserDataDirectory, "doomlab.pack"));
            mobjTemplate = bundle.LoadAsset("[MOBJ] - Null").Cast<GameObject>();
            mobjTemplate.hideFlags = HideFlags.DontUnloadUnusedAsset;

            WADManager manager = new WADManager();

            manager.LoadWAD(manager.pathToWAD);

            DoomGame game = new DoomGame();
            game.Initialize();

            BoneLib.Hooking.OnLevelInitialized += OnSceneLoaded;
        }

        public override void OnUpdate()
        {
            DoomGame.Instance.Update();
        }

        public void OnSceneLoaded(LevelInfo info)
        {
            new GameObject().AddComponent<MobjManager>();

            player = BoneLib.Player.physicsRig.m_chest.gameObject.AddComponent<Mobj>();
            player.flags ^= MobjFlags.MF_SHOOTABLE;
        }
    }
}
