using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;

namespace BlackIceFramework
{
    [BepInPlugin("org.kuteket.plugins.blackiceframework", "Black Ice Framework", "1.0.0.0")]
    public class BlackIceFramework : BaseUnityPlugin
    {
        /// --==========================================================================================--
        /// TODO: Test GUI handling. (use EndGameGUI as an example)
        /// --==========================================================================================--

        // Our class tracker.
        private ClassTracker classTracker;

        // Our source for logging.
        internal static new ManualLogSource Logger;

        // Our config entries.
        private static ConfigEntry<bool> _enabled;
        private static ConfigEntry<KeyboardShortcut> _runCustomCode;

        // Called on script startup.
        void Start()
        {
            // Assign our class tracker.
            classTracker = new ClassTracker();

            // Assign our logger.
            Logger = base.Logger;

            // Config entries.
            _enabled = Config.Bind("General", "Enabled", true, "Enable the ability to run our code.");
            _runCustomCode = Config.Bind("General", "ToggleKey", new KeyboardShortcut(KeyCode.U, KeyCode.LeftShift), "A key that runs our code when pressed.");
        }

        // Called every frame.
        void Update()
        {
            classTracker.TrackClasses();

            if (_runCustomCode.Value.IsDown())
            {
                if (classTracker.gameStateMachine_Running)
                {
                    Logger.LogMessage("Worked!");
                    Logger.LogMessage(GameStateMachine.instance.GetInventory().XP.ToString());

                    /*
                    // TODO: Test this.
                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
                    }
                    */
                }
            }
        }
    }
}