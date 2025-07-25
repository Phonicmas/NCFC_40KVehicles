using HarmonyLib;
using Vehicles;

namespace GF40k
{
    [HarmonyPatch(typeof(VehicleTurret), "MaxRange", MethodType.Getter)]
    public class MaxRangePatch
    {
        public static bool Prefix(ref float __result, VehicleTurret __instance)
        {
            if (__instance == null || __instance.def == null || !__instance.def.HasModExtension<DefModExtension_DecreaseEffectivnessWithoutGunner>())
            {
                return true;
            }
            var modExtension = __instance.def.GetModExtension<DefModExtension_DecreaseEffectivnessWithoutGunner>();
            var num = __instance.def.maxRange;
            if (__instance.def.maxRange < 0f)
            {
                num = 9999f;
            }
            else if (modExtension.maxRangeMultiplierPerCrewCount != null)
            {
                var allCannonCrew = __instance.vehicle.PawnsByHandlingType[HandlingType.Turret];
                num *= modExtension.maxRangeMultiplierPerCrewCount.Evaluate(allCannonCrew.Count);
            }
            __result = num;
            return false;
        }
    }
}