using GF40k;
using Vehicles;

namespace GF40k
{
    public class GF40kUtils
    {
        public static float RotationSpeed(VehicleTurretDef turretDef, VehiclePawn vehicle)
        {
            var num = turretDef.rotationSpeed;
            var modExtension = turretDef.GetModExtension<DefModExtension_DecreaseEffectivnessWithoutGunner>();
            if (modExtension.rotationSpeedMultiplierPerCrewCount != null)
            {
                var allCannonCrew = vehicle.PawnsByHandlingType[HandlingType.Turret];
                num *= modExtension.rotationSpeedMultiplierPerCrewCount.Evaluate((float)allCannonCrew.Count);
            }

            return num;
        }
    }
}