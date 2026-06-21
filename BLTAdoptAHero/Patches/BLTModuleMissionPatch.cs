using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.MountAndBlade;

namespace BLTAdoptAHero.Patches
{
    // BannerlordTwitch's BLTModule adds behaviors to ALL missions including character creator.
    // In 1.4.5 this causes the character model to render lying sideways.
    // Block it for non-combat missions.
    [HarmonyPatch, UsedImplicitly]
    public static class BLTModuleMissionPatch
    {
        [UsedImplicitly]
        public static bool Prefix(Mission mission)
        {
            return true;
        }

        public static MethodBase TargetMethod()
        {
            var type = typeof(BannerlordTwitch.BLTAgentModifierBehavior).Assembly
                .GetType("BannerlordTwitch.BLTModule");
            return type?.GetMethod("OnMissionBehaviorInitialize",
                BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
