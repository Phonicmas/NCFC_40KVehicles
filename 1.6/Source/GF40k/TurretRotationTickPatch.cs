using System;
using HarmonyLib;
using Vehicles;

namespace GF40k
{
    [HarmonyPatch(typeof(VehicleTurret), "TurretRotationTick")]
    public class TurretRotationTickPatch
    {
        public static bool Prefix(ref bool __result, VehicleTurret __instance)
        {
            if (!__instance.def.HasModExtension<DefModExtension_DecreaseEffectivnessWithoutGunner>())
            {
                return true;
            }
            var num = GF40kUtils.RotationSpeed(__instance.def, __instance.vehicle);
            var turretRotationTargeted = __instance.TurretRotationTargeted;
            if (__instance.TurretRotation != __instance.TurretRotationTargeted)
            {
                var num2 = __instance.TurretRotation + 90f;
                var num3 = __instance.TurretRotationTargeted + 90f;
                if (Math.Abs(num2 - num3) < num)
                {
                    __instance.TurretRotation = __instance.TurretRotationTargeted;
                }
                else
                {
                    var num4 = ((num2 < num3) ? ((Math.Abs(num2 - num3) < 180f) ? 1 : (-1)) : ((!(Math.Abs(num2 - num3) < 180f)) ? 1 : (-1)));
                    __instance.TurretRotation += num * (float)num4;
                    foreach (var childTurret in __instance.childTurrets)
                    {
                        childTurret.TurretRotation += num * num4;
                    }
                }
                __result = true;
            }
            __result = false;
            return false;
        }
    }
}