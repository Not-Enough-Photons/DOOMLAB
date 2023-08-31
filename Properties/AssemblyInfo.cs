using MelonLoader;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(NEP.DOOMLAB.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(NEP.DOOMLAB.BuildInfo.Company)]
[assembly: AssemblyProduct(NEP.DOOMLAB.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + NEP.DOOMLAB.BuildInfo.Author)]
[assembly: AssemblyTrademark(NEP.DOOMLAB.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(NEP.DOOMLAB.BuildInfo.Version)]
[assembly: AssemblyFileVersion(NEP.DOOMLAB.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfo(typeof(NEP.DOOMLAB.Main), NEP.DOOMLAB.BuildInfo.Name, NEP.DOOMLAB.BuildInfo.Version, NEP.DOOMLAB.BuildInfo.Author, NEP.DOOMLAB.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]