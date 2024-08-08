namespace Starting_Dupes_All_Aptitudes.Patches;

using UnityEngine;
using HarmonyLib;
using UnityEngine.UI;

[HarmonyPatch(typeof(CharacterSelectionController), "InitializeContainers")]
	public class CharacterSelectionController_Patch
	{
		[HarmonyPostfix]
		public static void Postfix(CharacterSelectionController __instance)
		{
			LayoutElement[] array = Object.FindObjectsOfType<LayoutElement>();
			if (array != null)
			{
				foreach (LayoutElement layoutElement in array)
				{
					if (layoutElement.gameObject.name == "AptitudeContainer")
					{
						Object.Destroy(layoutElement);
					}
				}
			}
		}
	}
