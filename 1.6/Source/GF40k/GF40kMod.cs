using HarmonyLib;
using Verse;

namespace GF40k
{
    public class GF40KMod : Mod
    {
        public static Harmony harmony;

        public GF40KMod(ModContentPack content)
            : base(content)
        {
            harmony = new Harmony("GF40K.Mod");
            harmony.PatchAll();
        }
    }
}