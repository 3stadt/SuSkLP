using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using Skyless.Assets.Code.Skyless.Game.BehaviourScripts;
using UnityEngine;

namespace SuSkLP
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class SuSkLP : BasePlugin
    {
        internal static new ManualLogSource Log;
        private static ConfigEntry<bool> _enabled;
        private static ConfigEntry<int> _red;
        private static ConfigEntry<int> _green;
        private static ConfigEntry<int> _blue;
        private static ConfigEntry<int> _alpha;
        private static Material _transMat;

        public override void Load()
        {
            Log = base.Log;
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            _enabled = Config.Bind(
                "General",
                "Enabled",
                true,
                "Set to false to use the original panel background"
            );
            _red = Config.Bind(
                "BackgroundColor",
                "Red",
                0,
                "Red value for the main panel background color (0-255)"
            );
            _green = Config.Bind(
                "BackgroundColor",
                "Green",
                0,
                "Green value for the main panel background color (0-255)"
            );
            _blue = Config.Bind(
                "BackgroundColor",
                "Blue",
                0,
                "Blue value for the main panel background color (0-255)"
            );
            _alpha = Config.Bind(
                "BackgroundColor",
                "Alpha",
                80,
                "Red value for the main panel background color (0-100)"
            );

            _transMat = new Material(Shader.Find("Transparent/Diffuse"));
            _transMat.color = new Color(
                _red.Value,
                _green.Value,
                _blue.Value,
                (float) (_alpha.Value / 100.0));

            Harmony.CreateAndPatchAll(typeof(SuSkLP));
        }

        [HarmonyPatch(typeof(BlurPanelSwitchBehaviour), nameof(BlurPanelSwitchBehaviour.Update))]
        [HarmonyPrefix]
        static bool PortIndexOpened(BlurPanelSwitchBehaviour __instance)
        {
            if (__instance.name != "BlurBGMain" || !_enabled.Value)
            {
                return true;
            }

            __instance.WithBlur = _transMat;
            return true;
        }
    }
}