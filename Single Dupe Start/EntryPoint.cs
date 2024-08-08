namespace Single_Dupe_Start;

using HarmonyLib;
using KMod;

public class EntryPoint: UserMod2
{
    public override void OnLoad(Harmony harmony)
    {
        base.OnLoad(harmony);
        Debug.Log("MrPurple6411's Single Dupe Start patched.");
		}
	}
