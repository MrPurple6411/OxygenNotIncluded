namespace Starting_Dupes_All_Aptitudes.Patches;

	using System.Collections.Generic;
	using Database;
	using HarmonyLib;
	using TUNING;

	[HarmonyPatch(typeof(MinionStartingStats), "GenerateAptitudes")]
	public class GenerateAptitudes_Patch
	{
		[HarmonyPrefix]
		public static bool Prefix(MinionStartingStats __instance)
		{
			if (!Constructor_Patch.starter)
			{
				return true;
			}
			List<SkillGroup> list = new List<SkillGroup>(Db.Get().SkillGroups.resources);
			for (int i = 0; i < list.Count; i++)
			{
				__instance.skillAptitudes.Add(list[i], (float)DUPLICANTSTATS.APTITUDE_BONUS);
			}
			return false;
		}
	}
