namespace Public_Dining_Tables;

using HarmonyLib;
using KMod;

public class EntryPoint: UserMod2
{
    public override void OnLoad(Harmony harmony)
    {
        base.OnLoad(harmony);
        Debug.Log("MrPurple6411's Public Dining Tables patched.");
		}
	}
