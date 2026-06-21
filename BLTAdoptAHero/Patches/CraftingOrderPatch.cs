using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BLTAdoptAHero.Patches
{
    // CraftingCampaignBehavior.CreateTownOrder crashes with NullRef when the orderOwner
    // is a BLT adopted hero — they lack some properties expected by the crafting system.
    [HarmonyPatch("TaleWorlds.CampaignSystem.CampaignBehaviors.CraftingCampaignBehavior",
        "CreateTownOrder"), UsedImplicitly]
    public static class CraftingOrderPatch
    {
        [UsedImplicitly]
        public static bool Prefix(Hero orderOwner)
        {
            return orderOwner == null || !orderOwner.IsAdopted();
        }
    }
}
