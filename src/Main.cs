using MelonLoader;
using NEP.DOOMLAB.WAD;
using BoneLib;
using NEP.DOOMLAB.Game;
using UnityEngine;
using NEP.DOOMLAB.Entities;
using System.IO;
using NEP.DOOMLAB.Sound;
using NEP.DOOMLAB.Rendering;
using BoneLib.BoneMenu.Elements;
using BoneLib.BoneMenu;
using MK.Glow;

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

            new WADManager();
            WADManager.Instance.IWAD = WADManager.Instance.LoadWAD(WADManager.Instance.GetIWAD());
            SpriteLumpGenerator.Initialize();

            DoomGame game = new DoomGame();

            BoneLib.Hooking.OnLevelInitialized += OnSceneLoaded;

            BoneMenuStuff();
        }

        public override void OnUpdate() => DoomGame.Instance.Update();

        public void OnSceneLoaded(LevelInfo info)
        {
            new GameObject("[DOOMLAB] - Sound Manager").AddComponent<SoundManager>();
            new GameObject("[DOOMLAB] - MOBJ Manager").AddComponent<MobjManager>();

            player = BoneLib.Player.physicsRig.m_chest.gameObject.AddComponent<Mobj>();
            player.flags ^= MobjFlags.MF_SHOOTABLE;
            player.playerHealth = BoneLib.Player.rigManager.GetComponent<Player_Health>();
        }

        internal void BoneMenuStuff()
        {
            MenuCategory menuCategory = MenuManager.CreateCategory("Not Enough Photons", Color.white);
            var doomCategory = menuCategory.CreateCategory("DOOMLAB", Color.white);

            doomCategory.CreateBoolElement("Disable AI", Color.white, false, (value) => Settings.DisableAI = value);

            var wadCategory = 
        }
    }
}
