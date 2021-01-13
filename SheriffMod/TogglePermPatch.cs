using System;
using HarmonyLib;

namespace SheriffMod
{
	[HarmonyPatch]
	public static class TogglePermPatch
	{
		[HarmonyPatch(typeof(BCLDBBKFJPK), "Toggle")]
		public static bool Prefix(BCLDBBKFJPK __instance)
		{
			bool flag = __instance.TitleText.Text == "Show Sheriff";
			bool result;
			if (flag)
			{
				CustomGameOptions.permOn = !CustomGameOptions.permOn;
				FFGALNAPKCD.LocalPlayer.RpcSyncSettings(FFGALNAPKCD.GameOptions);
				__instance.NHLMDAOEOAE = CustomGameOptions.permOn;
				__instance.CheckMark.enabled = CustomGameOptions.permOn;
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}
	}
}
