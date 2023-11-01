using System;

namespace PolymorphismC
{
    internal static class GameEventManager
    {
        public delegate void GameEvent();

        public static GameEvent OnGameStart, OnGameOver;

        public static void TriggerGameStart()
        {
            if (OnGameStart != null)
            {
                Console.WriteLine("The game has started...");
                OnGameStart();
            }
        }

        public static void TriggerGameOver()
        {
            if (OnGameOver != null)
            {
                Console.WriteLine("The game is over...");
                OnGameOver();
            }
        }
    }
}