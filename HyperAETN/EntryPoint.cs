namespace HyperAETN;

using HarmonyLib;
using Klei;
using KMod;

[HarmonyPatch]
public class EntryPoint : UserMod2
{
    public override void OnLoad(Harmony harmony)
    {
        base.OnLoad(harmony);
        Debug.Log("MrPurple6411's HyperAETN patched.");
    }
}
