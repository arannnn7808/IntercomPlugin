using System;
using Exiled.API.Features;
using HarmonyLib;

namespace IntercomPlugin
{
    public class Class1 : Plugin<Config, Translations>
    {
        public override string Name { get; } = "IntercomPlugin";
        public override string Author { get; } = "Aran";
        public override string Prefix { get; } = "intercomplugin";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 9, 5);

        public override void OnEnabled()
        {
            instance = this;
            Harmony harmony = new Harmony("testid");
            harmony.PatchAll();
            Log.Info("========================================");
            Log.Info("Enabled: Created by: Aran.");
            Log.Info("Thank you for using it!");
            Log.Info("========================================");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            instance = null;
            Log.Info("========================================");
            Log.Info("Disabled: Created by: Aran.");
            Log.Info("Thank you for using it!");
            Log.Info("========================================");
            base.OnDisabled();
        }
        
        public static Class1 instance;
    }
}