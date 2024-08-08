namespace Public_Cots.Patches;

using HarmonyLib;
using UnityEngine;

[HarmonyPatch]
public static class Patches
{
    [HarmonyPatch(typeof(Bed), "RemoveEffects"), HarmonyPostfix]
    public static void Postfix(Bed __instance)
    {
        if (__instance.effects[0] == "BedStamina")
            __instance.GetComponent<Ownable>().Assign(null);
    }

    [HarmonyPatch(typeof(Assignable), "RestoreAssignee"), HarmonyPostfix]
    public static void Postfix(Assignable __instance)
    {
        Bed component = __instance.GetComponent<Bed>();
        if (component != null && component.effects[0] == "BedStamina")
        {
            __instance.Assign(null);
        }
    }

    [HarmonyPatch(typeof(SleepChoreMonitor.Instance), nameof(SleepChoreMonitor.Instance.UpdateBed)), HarmonyPostfix]
    public static void Postfix_UpdateBed(SleepChoreMonitor.Instance __instance)
    {
        Ownables soleOwner = __instance.sm.masterTarget.Get(__instance.smi).GetComponent<MinionIdentity>().GetSoleOwner();
        Assignable assignable = soleOwner.GetAssignable(Db.Get().AssignableSlots.Bed);

        if (assignable != null)
        {
            Bed component = assignable.GetComponent<Bed>();
            if (component != null && component.effects[0] == "BedStamina")
            {
                assignable.Assign(soleOwner.GetAssignableIdentity());
            }
        }
    }
}
