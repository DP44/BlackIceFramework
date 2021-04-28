using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;
using BlackIceFramework.Hooks;
using Assets.Scripts.Systems.Bounty;

namespace BlackIceFramework
{
    [BepInPlugin("org.kuteket.plugins.blackiceframework", "Black Ice Framework", frameworkVersion)]
    public class BlackIceFramework : BaseUnityPlugin
    {
        /// --==========================================================================================--
        /// TODO: Test GUI handling. (use EndGameGUI as an example)
        /// --==========================================================================================--

        // The current framework version.
        public const string frameworkVersion = "0.1";

        // Our class tracker.
        private ClassTracker classTracker;

        // Our source for logging.
        internal static new ManualLogSource Logger;

        // Our config entries.
        private static ConfigEntry<bool> _enabled;
        private static ConfigEntry<KeyboardShortcut> _showDebugInfoKey;
        // private static ConfigEntry<KeyboardShortcut> _runCustomCode;
        private static ConfigEntry<bool> _debugShown;

        // Called on script startup.
        void Start()
        {
            // Assign our class tracker.
            classTracker = new ClassTracker();

            // Assign our logger.
            Logger = base.Logger;

            // -------------------------------------------------------
            // Config entries.

            // General entries.
            _enabled = Config.Bind("General", "Enabled", true, "Enable the ability to run our code.");
            // _runCustomCode = Config.Bind("General", "ToggleKey", new KeyboardShortcut(KeyCode.U, KeyCode.LeftShift), "A key that runs our code when pressed.");

            // Debug entries.
            _showDebugInfoKey = Config.Bind("Debug", "ShowDebugInfoKey", new KeyboardShortcut(KeyCode.U, KeyCode.LeftShift), "The key used to toggle debug information.");
            _debugShown = Config.Bind("Debug", "ShowDebugInfo", false, "Show the debug window.");

            // -------------------------------------------------------
            // Our patches.
            // Harmony.CreateAndPatchAll(typeof(Hooks.GameStateMachineHook));
            // Harmony.CreateAndPatchAll(typeof(Hooks.InventoryControlHook));
            // Harmony.CreateAndPatchAll(typeof(Hooks.EnemyAIHook));

            // Logger.LogMessage("Hooking BountyManager.");
            // Harmony.CreateAndPatchAll(typeof(Hooks.BountyManagerHook));
        }

        // Called every frame.
        void Update()
        {
            classTracker.TrackClasses();

            if (_showDebugInfoKey.Value.IsDown())
            {
                // Toggle _debugShown.
                _debugShown.Value = !_debugShown.Value;

                Logger.LogMessage("_debugShown toggled.");
            }

            if (classTracker.gameStateMachine_Running)
            {
                // Update code here.
            }
        }
    }
}