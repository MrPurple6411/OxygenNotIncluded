namespace Public_Dining_Tables.Patches;

using UnityEngine;
using HarmonyLib;

[HarmonyPatch(typeof(EatChore.StatesInstance), "ApplySaltEffect")]
	public class EatChore_StatesInstance_ApplySaltEffect_Patch
	{
		[HarmonyPostfix]
		public static void Postfix(EatChore.StatesInstance __instance)
		{
			if (__instance != null && __instance.sm != null && __instance.sm.messstation != null)
        {
            GameObject gameObject = __instance.sm.messstation.Get(__instance);
            if(gameObject != null)
            {
                Room roomOfGameObject = Game.Instance.roomProber.GetRoomOfGameObject(gameObject);
                if(roomOfGameObject == null || !roomOfGameObject.roomType.Name.Contains("Hospital"))
                {
                    Assignable component = gameObject.GetComponent<Assignable>();
                    if(component == null)
                    {
                        return;
                    }
                    component.Assign(null);
                }
            }
        }
		}
	}
