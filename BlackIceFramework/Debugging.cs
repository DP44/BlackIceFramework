using HarmonyLib;

namespace BlackIceFramework
{
    // A class for debugging stuff.
    class Debugging
    {
        // Hooked Debug.IsDebugBuild().
        // [HarmonyPostfix, HarmonyPatch(typeof(UnityEngine.Debug), nameof(UnityEngine.Debug.isDebugBuild), MethodType.Getter)]
        // private static void IsDebugBuild(ref bool __result) => __result = true;
    }
}
