using System.Collections.Generic;
using HarmonyLib;
using ModLoader;
using ModLoader.Helpers;
using UITools;

namespace BuildSearchMod
{
    public class Main : Mod
    {

        public override string ModNameID => "Roshan.BuildSearchMod";
        public override string DisplayName => "Build Search Mod";
        public override string Author => "Roshan";
        public override string MinimumGameVersionNecessary => "1.5.10.2";
        public override string ModVersion => "v1.0.0";
        public override string Description => "Allows you to search for parts in the build scence";

        public override Dictionary<string, string> Dependencies { get; } = new Dictionary<string, string>
        {
            { "UITools", "1.1.5" }
        };

        public override void Load()
        {
            ModLoader.Helpers.SceneHelper.OnBuildSceneLoaded += GUI.ShowGUI;
        }

        public override void Early_Load()
        {
        }
    }
}