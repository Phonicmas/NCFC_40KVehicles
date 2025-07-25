using SmashTools;
using Verse;

namespace GF40k
{
    public class DefModExtension_DecreaseEffectivnessWithoutGunner : DefModExtension
    {
        public LinearCurve warmUpTimerMultiplierPerCrewCount;

        public LinearCurve maxRangeMultiplierPerCrewCount;

        public LinearCurve rotationSpeedMultiplierPerCrewCount;
    }
}