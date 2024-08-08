namespace Single_Dupe_Start.Patches;

using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using UnityEngine;
using HarmonyLib;
using UnityEngine.UI;

[HarmonyPatch(typeof(CharacterSelectionController), "InitializeContainers")]
	public class CharacterSelectionController_Patch
	{
		[HarmonyTranspiler]
		public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			List<CodeInstruction> list = new List<CodeInstruction>(instructions);
			for (int i = 0; i < instructions.Count(); i++)
			{
				CodeInstruction codeInstruction = (i > 0) ? list[i - 1] : null;
				CodeInstruction codeInstruction2 = list[i];
				CodeInstruction codeInstruction3 = (i < instructions.Count()) ? list[i + 1] : null;
				if (codeInstruction != null && codeInstruction3 != null && codeInstruction.opcode == OpCodes.Ldarg_0 && codeInstruction2.opcode == OpCodes.Ldc_I4_3 && codeInstruction3.opcode == OpCodes.Stfld)
				{
					list[i] = new CodeInstruction(OpCodes.Ldc_I4_1, null);
					break;
				}
			}
			return list.AsEnumerable();
		}

		[HarmonyPostfix]
		public static void Postfix(CharacterSelectionController __instance)
		{
			if (__instance.IsStarterMinion)
			{
				LocText[] array = Object.FindObjectsOfType<LocText>();
				if (array != null)
				{
					foreach (LocText locText in array)
					{
						if (locText.key == "STRINGS.UI.IMMIGRANTSCREEN.SELECTYOURCREW")
						{
							Object.Destroy(locText.gameObject);
							break;
						}
					}
				}
				GridLayoutGroup[] array3 = Object.FindObjectsOfType<GridLayoutGroup>();
				if (array3 != null)
				{
					foreach (GridLayoutGroup gridLayoutGroup in array3)
					{
						if (gridLayoutGroup.gameObject.name == "CharacterContainers")
						{
							gridLayoutGroup.childAlignment = TextAnchor.UpperRight;
							gridLayoutGroup.constraint = 0;
							return;
						}
					}
				}
			}
		}
	}
