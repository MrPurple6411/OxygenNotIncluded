namespace ResearchIncluded;

using HarmonyLib;
using KMod;
using UnityEngine;

[HarmonyPatch]
public class EntryPoint : UserMod2
{
    public override void OnLoad(Harmony harmony)
    {
        base.OnLoad(harmony);
        Debug.Log("MrPurple6411's ResearchIncluded patched.");
    }

    [HarmonyPatch(typeof(Tech), nameof(Tech.IsComplete)), HarmonyPostfix]
    public static void Postfix(Tech __instance, ref bool __result)
    {
        if (__result || Research.Instance == null)
            return;

        __result = true;
    }
}