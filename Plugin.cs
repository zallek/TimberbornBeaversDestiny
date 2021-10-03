using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace ToolShortcuts
{
    [BepInPlugin("Timberborn.BeaversDestiny", "BeaverDestiny", "0.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;

        private void Awake()
        {
            Log = base.Logger;

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        }
    }
}