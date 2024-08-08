namespace Public_Dining_Tables.Patches;

using System.Collections.Generic;
	using HarmonyLib;

[HarmonyPatch(typeof(EatChore.StatesInstance), "UpdateMessStation")]
	public class EatChore_StatesInstance_UpdateMessStation_Patch
	{

		[HarmonyPrefix]
		public static bool Prefix(EatChore.StatesInstance __instance)
		{
			Ownables soleOwner = __instance.sm.eater.Get(__instance).GetComponent<MinionIdentity>().GetSoleOwner();
			List<Assignable> preferredAssignables = Game.Instance.assignmentManager.GetPreferredAssignables(soleOwner, Db.Get().AssignableSlots.MessStation);
			Assignable assignable = (preferredAssignables.Count > 0) ? preferredAssignables[0] : soleOwner.AutoAssignSlot(Db.Get().AssignableSlots.MessStation);
			__instance.sm.messstation.Set(assignable, __instance);
			return false;
		}
	}
