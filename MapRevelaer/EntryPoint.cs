namespace MapRevealer;

using HarmonyLib;
using Klei;
using KMod;

[HarmonyPatch]
public class EntryPoint : UserMod2
{
    public override void OnLoad(Harmony harmony)
    {
        base.OnLoad(harmony);
        Debug.Log("MrPurple6411's Map Revealer patched.");
    }

    [HarmonyPatch(typeof(GenericGameSettings), nameof(GenericGameSettings.disableFogOfWar), MethodType.Getter), HarmonyPrefix]
    public static bool GenericGameSettings_disableFogOfWar_Getter_Prefix(ref bool __result)
    {
        __result = true;
        return false;
    }
}
