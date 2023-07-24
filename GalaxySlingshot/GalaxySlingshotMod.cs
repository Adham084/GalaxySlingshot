using System.Collections.Generic;
using HarmonyLib;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Tools;

namespace GalaxySlingshot
{
	public class GalaxySlingshotMod : Mod
	{
		public override void Entry(IModHelper helper)
		{
			Harmony harmony = new(ModManifest.UniqueID);

			harmony.Patch(
				AccessTools.Method(typeof(Utility), nameof(Utility.getAdventureShopStock)),
				postfix: new HarmonyMethod(typeof(GalaxySlingshotMod), nameof(GetAdventureShopStockPostfix))
			);
		}

		public static void GetAdventureShopStockPostfix(Dictionary<ISalable, int[]> __result)
		{
			if (Game1.player.mailReceived.Contains("galaxySword"))
			{
				__result.Add(new Slingshot(34), new int[2] { 25000, int.MaxValue });
			}
		}
	}
}
