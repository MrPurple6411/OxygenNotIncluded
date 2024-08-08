namespace NoFloodWranglePoint;

using HarmonyLib;
using KMod;
using System;

public class EntryPoint : UserMod2
{
    public static EntryPoint Instance { get; private set; }

    public override void OnLoad(Harmony harmony)
    {
        Instance = this;
        var typesToPatch = new string[]{ "CreatureDeliveryPointConfig", "CritterDropOffConfig", "CritterPickUpConfig" };
        foreach (var typeName in typesToPatch)
        {
            Type typeToPatch = AccessTools.TypeByName(typeName);
            if (typeToPatch != null)
            {
                var method = AccessTools.Method(typeToPatch, "CreateBuildingDef");
                if (method == null)
                    continue;

                harmony.Patch(method, postfix: new HarmonyMethod(typeof(EntryPoint), nameof(CreateBuildingDef_Postfix)));
                Debug.Log($"[{Instance.mod.title}] successfully patched {typeName}.CreateBuildingDef");
            }
        }
        Debug.Log($"MrPurple6411's {Instance.mod.title} points patched.");
    }

    public static void CreateBuildingDef_Postfix(ref BuildingDef __result)
    {
        __result.Floodable = false;
    }
}
