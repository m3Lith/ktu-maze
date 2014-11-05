using System;

namespace Maze_try2
{
    public static class AppData
    {
        public enum AppStates
        {
            Idle,
            LongTask
        }

        public static AppStates AppState {get; set;}

        public static Random Rng { get; set; }
    }
}
