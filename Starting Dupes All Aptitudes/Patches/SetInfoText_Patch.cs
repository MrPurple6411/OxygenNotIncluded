namespace Starting_Dupes_All_Aptitudes.Patches;

using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
	using HarmonyLib;

[HarmonyPatch(typeof(CharacterContainer), "SetInfoText")]
	public class SetInfoText_Patch
	{
		[HarmonyTranspiler]
		public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			List<CodeInstruction> list = new List<CodeInstruction>(instructions);
			for (int i = 0; i < instructions.Count<CodeInstruction>(); i++)
			{
				CodeInstruction codeInstruction = (i > 0) ? list[i - 1] : null;
				CodeInstruction codeInstruction2 = list[i];
				CodeInstruction codeInstruction3 = (i + 1 < instructions.Count<CodeInstruction>()) ? list[i + 1] : null;
				if (codeInstruction != null && codeInstruction3 != null && codeInstruction.opcode == OpCodes.Callvirt && codeInstruction2.opcode == OpCodes.Ldc_I4_1 && codeInstruction3.opcode == OpCodes.Sub)
				{
					list[i] = new CodeInstruction(OpCodes.Call, typeof(GenerateAttributes_Patch).GetMethod("SubtractRequired"));
					list[i + 1] = new CodeInstruction(OpCodes.Nop, null);
				}
			}
			return list.AsEnumerable<CodeInstruction>();
		}

		public static int SubtractRequired(int Aptitudes_Count)
		{
			if (Aptitudes_Count >= 3)
			{
				return 2;
			}
			return Aptitudes_Count - 1;
		}
	}
