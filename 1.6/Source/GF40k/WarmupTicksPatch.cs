using HarmonyLib;
using UnityEngine;
using Vehicles;

namespace GF40k
{
    [HarmonyPatch(typeof(VehicleTurret), "WarmupTicks", MethodType.Getter)]
    public class WarmupTicksPatch
    {
        public static bool Prefix(ref int __result, VehicleTurret __instance)
        {
            if (__instance == null || __instance.def == null || !__instance.def.HasModExtension<DefModExtension_DecreaseEffectivnessWithoutGunner>())
            {
                return true;
            }
            var modExtension = __instance.def.GetModExtension<DefModExtension_DecreaseEffectivnessWithoutGunner>();
            var num = __instance.def.warmUpTimer * 60f;
            if (modExtension.warmUpTimerMultiplierPerCrewCount != null)
            {
                var allCannonCrew = __instance.vehicle.PawnsByHandlingType[HandlingType.Turret];
                num *= modExtension.warmUpTimerMultiplierPerCrewCount.Evaluate(allCannonCrew.Count);
            }
            __result = Mathf.CeilToInt(num);
            return false;
        }
    }
}