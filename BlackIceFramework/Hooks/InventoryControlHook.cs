using HarmonyLib;
using UnityEngine;

namespace BlackIceFramework.Hooks
{
    class InventoryControlHook
    {
        [HarmonyPatch(typeof(InventoryControl), "Awake")]
        [HarmonyPrefix]
        static bool Awake()
        {
            return true;
        }

        [HarmonyPatch(typeof(InventoryControl), "Teleport")]
        [HarmonyPrefix]
        static bool Teleport(Vector3 spawnPoint, Quaternion rotation)
        {
            return true;
        }
    }
}
