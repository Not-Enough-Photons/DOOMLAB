using MelonLoader;

using NEP.BWDOOM.Entities;
using NEP.BWDOOM.Level;
using NEP.BWDOOM.Sound;
using NEP.BWDOOM.Misc;
using NEP.BWDOOM.Rendering;
using NEP.BWDOOM.WAD;

using UnityEngine;

namespace NEP.BWDOOM
{
    public static class BuildInfo
    {
        public const string Name = "BWDOOM"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "Not Enough Photons, cyotek, Sinshu"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class Main : MelonMod
    {
        public static MelonLogger.Instance logger;

        public static AssetBundle bundle;

        public static bool play;

        private ThinkerManager thinkerManager;

        public override void OnApplicationStart()
        {
            Assembly.UseEmbeddedResource("NEP.BWDOOM.Resources.bwdoom.pack", bytes => bundle = AssetBundle.LoadFromMemory(bytes));

            WadDataManager wadManager = new WadDataManager();
            SpriteLookup.Start();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasInitialized(buildIndex, sceneName);

            try
            {
                // Initialize data
                Info.MobjActions mobjActions = new Info.MobjActions();
                Info.MobjInfos mobjInfos = new Info.MobjInfos();

                LoggerInstance.Msg(System.ConsoleColor.Green, "Initialized data");

                // Initialize logic and entity managers
                thinkerManager = new GameObject("ThinkerManager").AddComponent<ThinkerManager>();
                MOBJManager mobjManager = new GameObject("MOBJManager").AddComponent<MOBJManager>();
                DoomRNG doomRNG = new GameObject("DoomRNG").AddComponent<DoomRNG>();
                DoomGame doomGame = new GameObject("DoomGame").AddComponent<DoomGame>();

                LoggerInstance.Msg(System.ConsoleColor.Green, "Initialized logic and entity managers");

                // Set hide flags
                thinkerManager.hideFlags = HideFlags.DontUnloadUnusedAsset;
                mobjManager.hideFlags = HideFlags.DontUnloadUnusedAsset;
                doomRNG.hideFlags = HideFlags.DontUnloadUnusedAsset;
                doomGame.hideFlags = HideFlags.DontUnloadUnusedAsset;

                LoggerInstance.Msg(System.ConsoleColor.Green, "Set hide flags");
            }
            catch(System.Exception e)
            {
                LoggerInstance.Error($"Failed to initialize components at stack-trace: {e.StackTrace}");
            }
        }

        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasUnloaded(buildIndex, sceneName);

            play = false;
        }
    }

    public static class EmbeddedResourceUtilities
    {
        // from extraes
        public static void UseEmbeddedResource(this System.Reflection.Assembly assembly, string resourcePath, System.Action<byte[]> whatToDoWithResource)
        {
            using (System.IO.Stream stream = assembly.GetManifestResourceStream(resourcePath))
            {
                // Don't overallocate memory to the mstream (?).
                using (System.IO.MemoryStream mStream = new System.IO.MemoryStream((int)stream.Length))
                {
                    // Copy the stream to a memorystream. Why? Don't know, ask .NET 4.7.2 designers.
                    stream.CopyTo(mStream);
                    whatToDoWithResource(mStream.ToArray());
                }
            }
        }
    }
}
