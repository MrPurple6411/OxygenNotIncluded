namespace MapRevealer;

using HarmonyLib;
using Klei;
using KMod;
using UnityEngine;

[HarmonyPatch]
public class EntryPoint : UserMod2
{
    public override void OnLoad(Harmony harmony)
    {
        base.OnLoad(harmony);
        Debug.Log("MrPurple6411's Map Revealer patched.");
    }

    //[HarmonyPatch(typeof(GenericGameSettings), nameof(GenericGameSettings.disableFogOfWar), MethodType.Getter), HarmonyPrefix]
    //public static bool GenericGameSettings_disableFogOfWar_Getter_Prefix(ref bool __result)
    //{
    //    __result = true;
    //    return false;
    //}

    [HarmonyPatch(typeof(GridVisibility), nameof(GridVisibility.Reveal)), HarmonyPostfix]
    public static void GridVisibility_Reveal_Postfix(int baseX, int baseY)
    {
        int num = (int)Grid.WorldIdx[baseY * Grid.WidthInCells + baseX];

        for (int i = 0; i < Grid.HeightInCells; i++)
        {
            for (int j = 0; j < Grid.WidthInCells; j++)
            {
                int num4 = i * Grid.WidthInCells + j;
                if (Grid.Visible[num4] < 255 && num == (int)Grid.WorldIdx[num4])
                {
                    Grid.Reveal(num4, 255, true);
                }
            }
        }
        SaveGame.Instance.worldGenSpawner.SpawnEverything();
    }
}
