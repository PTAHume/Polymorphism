using System;

namespace PolymorphismC.Game
{
    public class AudioSystem
    {
        public AudioSystem()
        {
            GameEventManager.OnGameStart += StartGame;
            GameEventManager.OnGameOver += GameOver;
        }

        private void StartGame()
        {
            Console.WriteLine($"Audio System Started");
            Console.WriteLine($"Playing Audio...");

        }
        private void GameOver()
        {
            Console.WriteLine($"Audio System Stopped");

        }
    }
}
