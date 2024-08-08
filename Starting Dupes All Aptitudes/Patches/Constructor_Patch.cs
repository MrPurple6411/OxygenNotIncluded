namespace Starting_Dupes_All_Aptitudes.Patches;

using System;
using HarmonyLib;

[HarmonyPatch(typeof(MinionStartingStats), MethodType.Constructor, new Type[] { typeof(bool), typeof(string), typeof(string), typeof(bool) })]
	public static class Constructor_Patch
	{
		[HarmonyPrefix]
		public static void Prefix(bool is_starter_minion)
		{
			Constructor_Patch.starter = is_starter_minion;
		}

		public static bool starter;
	}
