using MelonLoader;

using BoneLib;

using NEP.DOOMLAB.WAD;
using NEP.DOOMLAB.Game;
using NEP.DOOMLAB.Entities;
using NEP.DOOMLAB.Rendering;
using NEP.DOOMLAB.Sound;

using UnityEngine;

using System.IO;
using System.Reflection;

using BoneLib.BoneMenu.Elements;
using BoneLib.BoneMenu;

namespace NEP.DOOMLAB
{
    public static class BuildInfo
    {
        public const string Name = "DOOMLAB"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Hell has encroached into MythOS. Pick up Doomguy's skills and slay endless demons."; // Description for the Mod.  (Set as null if none)
        public const string Author = "Not Enough Photons, adamdev"; // Author of the Mod.  (MUST BE SET)
        public const string Company = "Not Enough Photons"; // Company that made the Mod.  (Set as null if none)
        public const string Version = "0.0.1"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class Main : MelonMod
    {
        public AssetBundle bundle;
        public static GameObject mobjTemplate;
        public static Material unlitMaterial;
        public static Mobj player;

        public static readonly string UserDataDirectory = MelonUtils.UserDataDirectory;
        public static readonly string TeamDirectory = Path.Combine(UserDataDirectory, "Not Enough Photons");
        public static readonly string ModDirectory = Path.Combine(TeamDirectory, "DOOMLAB");
        public static readonly string IWADDirectory = Path.Combine(ModDirectory, "IWADS");
        public static readonly string PWADDirectory = Path.Combine(ModDirectory, "PWADS");
        
        public static Texture2D MissingSprite;

        private static AssetBundle GetEmbeddedBundle()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            string fileName = HelperMethods.IsAndroid() ? "doomlab_quest.pack" : "doomlab_pcvr.pack";

            using (Stream resourceStream = assembly.GetManifestResourceStream("NEP.DOOMLAB.Resources." + fileName))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    resourceStream.CopyTo(memoryStream);
                    return AssetBundle.LoadFromMemory(memoryStream.ToArray());
                }
            }
        }

        public override void OnInitializeMelon()
        {
            Directory.CreateDirectory(ModDirectory);
            Directory.CreateDirectory(IWADDirectory);
            Directory.CreateDirectory(PWADDirectory);

            bundle = GetEmbeddedBundle();
            mobjTemplate = bundle.LoadAsset("[MOBJ] - Null").Cast<GameObject>();
            mobjTemplate.hideFlags = HideFlags.DontUnloadUnusedAsset;
            MissingSprite = bundle.LoadAsset("faila0").Cast<Texture2D>();
            MissingSprite.hideFlags = HideFlags.DontUnloadUnusedAsset;
            unlitMaterial = bundle.LoadAsset("mat_unlit").Cast<Material>();
            unlitMaterial.hideFlags = HideFlags.DontUnloadUnusedAsset;

            new WADManager();
            WADManager.Instance.LoadWAD(WADManager.Instance.GetIWAD());
            FrameBuilder.GenerateTable();

            DoomGame game = new DoomGame();

            BoneLib.Hooking.OnLevelInitialized += OnSceneLoaded;

            BoneMenuStuff();
        }

        public override void OnUpdate() => DoomGame.Instance.Update();

        public void OnSceneLoaded(LevelInfo info)
        {
            DoomGame.Instance.gameTic = 0;

            new SoundManager();
            new MobjManager();

            player = Player.physicsRig.m_chest.gameObject.AddComponent<Mobj>();
            player.gameObject.AddComponent<DoomPlayer>();
            player.flags ^= MobjFlags.MF_SHOOTABLE;
            player.playerHealth = Player.rigManager.GetComponent<Player_Health>();
        }

        internal void BoneMenuStuff()
        {
            MenuCategory menuCategory = MenuManager.CreateCategory("Not Enough Photons", Color.white);
            var doomCategory = menuCategory.CreateCategory("DOOMLAB", Color.white);

            var gameFlagsCategory = doomCategory.CreateCategory("Game Flags", Color.white);
            var debugCategory = doomCategory.CreateCategory("Debug", Color.white);

            gameFlagsCategory.CreateBoolElement("Disable Thinking", Color.white, false, (value) => Settings.DisableAI = value);
            gameFlagsCategory.CreateBoolElement("No Target", Color.white, false, null);
            gameFlagsCategory.CreateBoolElement("Fast Monsters", Color.white, false, (value) => 
            {
                Settings.FastMonsters = value;
                DoomGame.Instance.UpdateFastMonsters(Settings.FastMonsters);
            });
            gameFlagsCategory.CreateBoolElement("Respawn Monsters", Color.white, false, (value) => Settings.RespawnMonsters = value);

            debugCategory.CreateFloatElement("Projectile Pruning Distance", Color.white, 128f, 32f, 0f, 4096f, (value) => Settings.ProjectilePruneDistance = value);
            debugCategory.CreateBoolElement("MOBJ Debug Stats", Color.white, false, (value) => Settings.EnableMobjDebug = value);
            debugCategory.CreateBoolElement("MOBJ Debug Lines", Color.white, false, (value) => Settings.EnableMobjDebugLines = value);
            debugCategory.CreateBoolElement("MOBJ Debug Colliders", Color.white, false, (value) => Settings.EnableMobjDebugColliders = value);

            var wadCategory = doomCategory.CreateCategory("WADS", Color.white);
            string[] iwadNames = WADManager.Instance.GetWADsInFolder(WADFile.WADType.IWAD, false);
            string[] pwadNames = WADManager.Instance.GetWADsInFolder(WADFile.WADType.PWAD, false);

            for (int i = 0; i < iwadNames.Length; i++)
            {
                int index = i;
                wadCategory.CreateFunctionElement(WADManager.Instance.GetWADFileName(iwadNames[index], true), Color.white, () =>
                {
                    WADManager.Instance.LoadWAD(WADManager.Instance.IWADS[index]);
                    FrameBuilder.GenerateTable();
                    MobjRenderer.LoadSpriteDefs();
                    SoundManager.Instance.LoadWADAudio(WADManager.Instance.LoadedWAD.sounds);
                });
            }

            for (int i = 0; i < pwadNames.Length; i++)
            {
                int index = i;
                wadCategory.CreateFunctionElement(WADManager.Instance.GetWADFileName(pwadNames[index], true), Color.white, () =>
                {
                    WADManager.Instance.LoadWAD(WADManager.Instance.PWADS[index]);
                    FrameBuilder.GenerateTable();
                    MobjRenderer.LoadSpriteDefs();
                    SoundManager.Instance.LoadWADAudio(WADManager.Instance.LoadedWAD.sounds);
                });
            }
        }
    }
}
