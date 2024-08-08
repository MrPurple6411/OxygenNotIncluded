namespace Public_Dining_Tables.Patches;

using HarmonyLib;
[HarmonyPatch(typeof(Assignable), "RestoreAssignee")]
	public class Assignable_RestoreAssignee_Patch
	{
		[HarmonyPostfix]
		public static void Postfix(Assignable __instance)
		{
			if (((__instance != null) ? __instance.GetComponent<MessStation>() : null) != null)
			{
				Room roomOfGameObject = Game.Instance.roomProber.GetRoomOfGameObject(__instance.gameObject);
				if (roomOfGameObject == null || !roomOfGameObject.roomType.Name.Contains("Hospital"))
				{
					__instance.Assign(null);
				}
			}
		}
	}
