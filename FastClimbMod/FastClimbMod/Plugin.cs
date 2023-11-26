using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastClimbMod
{
    [BepInPlugin(modGUID, modBase, modVer)]
    public class ClimbMod : BaseUnityPlugin
    {
        private const string modGUID = "lionelvlv.LCFastClimbMod";
        private const string modBase = "FastClimbMod";
        private const string modVer = "1.0.0";

        private readonly Harmony harmony = new HarmonyLib.Harmony(modGUID);
        private static ClimbMod Instance;
        internal ManualLogSource wls;
        void Awake()
        {
            if (Instance == null) { 
                Instance = this;
            }
            wls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            wls.LogInfo("FastClimbMod loaded");
            harmony.PatchAll(typeof(ClimbMod));
            harmony.PatchAll(typeof(Patches.PlayerControllerPatch));
        }
    }
}
