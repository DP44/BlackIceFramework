namespace BlackIceFramework
{
    // A class responsible for keeping track of which classes have loaded.
    class ClassTracker
    {
        /// --==========================================================================================--
        /// TODO: Track these classes:
        /// 
        /// Managers:
        ///     AbilityContainer
        ///     AchievementManager
        ///     AnalyticsManager
        ///     CameraShakeManager
        ///     ControlManager
        ///     CorporationManager
        ///     DamageFlashManager
        ///     EnemyAffixManager
        ///     EnemyAggroManager
        ///     FactionManager
        ///     FloatingTextManager
        /// 
        /// Other classes:
        ///     CacheInventoryControllerUGUI
        ///     ChatGUI
        ///     CombinedUIController
        ///     EnemyNetworkDamage
        ///     EventContainer
        /// --==========================================================================================--

        // Tracking GameStateMachine.
        public bool gameStateMachine_Loading;
        public bool gameStateMachine_Running;

        // Tracking managers.
        public bool spawnManager;
        public bool worldManager;
        public bool difficultyManager;

        // Traking other classes.
        public bool inbox;

        // Called when the plugin is loaded.
        public ClassTracker()
        {
            // GameStateMachine.
            gameStateMachine_Loading = false;
            gameStateMachine_Running = false;

            // Managers.
            spawnManager = false;
            worldManager = false;
            difficultyManager = false;

            // Others.
            inbox = false;
        }

        // Responsible for tracking classes.
        public void TrackClasses()
        {
            // TODO: Find a cleaner way to do this.
            if (GameStateMachine.instance != null)
            {
                TrackGameStateMachine();
            } 
            else
            {
                gameStateMachine_Loading = false;
                gameStateMachine_Running = false;
            }

            // Tracking managers.
            if (SpawnManager.instance != null) { TrackSpawnManager(); } else { spawnManager = false; }
            if (WorldManager.Instance != null) { TrackWorldManager(); } else { worldManager = false; }
            if (DifficultyManager.instance != null) { TrackDifficultyManager(); } else { difficultyManager = false; }

            // Tracking other classes.
            if (Inbox.instance != null) { TrackInbox(); } else { inbox = false; }
        }

        // --==========================================================================================--
        //                                            Trackers
        // --==========================================================================================--

        // GameStateMachine tracker.
        private void TrackGameStateMachine()
        {
            if (!gameStateMachine_Loading && GameStateMachine.instance.State == GameState.Loading)
            {
                gameStateMachine_Loading = true;
            }

            if (!gameStateMachine_Running && GameStateMachine.instance.State == GameState.Running)
            {
                gameStateMachine_Running = true;
            }
        }

        // Manager trackers.
        private void TrackSpawnManager() { if (!spawnManager) { spawnManager = true; }}
        private void TrackWorldManager() { if (!worldManager) { worldManager = true; }}
        private void TrackDifficultyManager() { if (!difficultyManager) { difficultyManager = true; }}

        // Other trackers.
        private void TrackInbox() { if (!inbox) { inbox = true; }}
    }
}
