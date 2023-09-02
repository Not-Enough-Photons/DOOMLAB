using MelonLoader;
using NEP.DOOMLAB.WAD;
using BoneLib;
using NEP.DOOMLAB.Game;
using UnityEngine;
using SLZ.Marrow.Warehouse;
using NEP.DOOMLAB.Entities;
using System.IO;
using NEP.DOOMLAB.Sound;
using NEP.DOOMLAB.Rendering;

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
            SpriteLumpGenerator.Initialize();

            DoomGame game = new DoomGame();

            BoneLib.Hooking.OnLevelInitialized += OnSceneLoaded;
        }

        public override void OnUpdate()
        {
            DoomGame.Instance.Update();

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                MobjManager.Instance.SpawnMobj(player.transform.position + player.transform.forward * 3f, Data.MobjType.MT_POSSESSED);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                MobjManager.Instance.SpawnMobj(player.transform.position + player.transform.forward * 3f, Data.MobjType.MT_SERGEANT);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                MobjManager.Instance.SpawnMobj(player.transform.position + player.transform.forward * 3f, Data.MobjType.MT_BARREL);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                MobjManager.Instance.SpawnMobj(player.transform.position + player.transform.forward * 3f, Data.MobjType.MT_TROOP);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                MobjManager.Instance.SpawnMobj(player.transform.position + player.transform.forward * 3f, Data.MobjType.MT_CYBORG);
            }
            else if(Input.GetKeyDown(KeyCode.Alpha6))
            {
                MobjManager.Instance.SpawnMobj(player.transform.position + player.transform.forward * 3f, Data.MobjType.MT_BOSSBRAIN);
            }
        }

        public void OnSceneLoaded(LevelInfo info)
        {
            new GameObject("[DOOMLAB] - Sound Manager").AddComponent<SoundManager>();
            new GameObject("[DOOMLAB] - MOBJ Manager").AddComponent<MobjManager>();

            player = BoneLib.Player.physicsRig.m_chest.gameObject.AddComponent<Mobj>();
            player.flags ^= MobjFlags.MF_SHOOTABLE;
            player.playerHealth = BoneLib.Player.rigManager.health;
        }
    }
}
