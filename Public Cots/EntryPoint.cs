namespace Public_Cots;

using HarmonyLib;
using KMod;

public class EntryPoint : UserMod2
{
    public override void OnLoad(Harmony harmony)
    {
        base.OnLoad(harmony);
        Debug.Log("MrPurple6411's Public Cots patched.");
    }
}
