using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace GF40k
{
    [HarmonyPatch]
    public class SpawnedBuildingFaction
    {
        [HarmonyPatch(typeof(GenSpawn), "Spawn", new Type[]
        {
            typeof(Thing),
            typeof(IntVec3),
            typeof(Map),
            typeof(WipeMode)
        }, new []
        {
            ArgumentType.Normal,
            ArgumentType.Normal,
            ArgumentType.Normal,
            ArgumentType.Normal
        })]
        [HarmonyPostfix]
        public static void Postfix(ref Thing __result)
        {
            if (__result.def.HasModExtension<DefModExtension_SpawnedBuildingFaction>())
            {
                __result.SetFaction(Faction.OfPlayer);
            }
        }
    }
}