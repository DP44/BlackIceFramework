using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;

namespace BlackIceFramework.Hooks
{
    class EnemyAIHook
    {
        /*
        [HarmonyPatch(typeof(EnemyAI), "GetNearbyPositions")]
        [HarmonyPrefix]
        static bool GetNearbyPositions(Vector3 center, float radius, List<Vector3> positions)
        {
            return true;
        }
        */

        /*
        [HarmonyPatch(typeof(EnemyAI), "VisualizePath")]
        [HarmonyPrefix]
        static bool VisualizePath()
        {
            return true;
        }
        */
    }
}
