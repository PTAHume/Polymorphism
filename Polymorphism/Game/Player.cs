using System;

namespace PolymorphismC
{
    public class Player
    {
        public string _PlayerName { get; set; }

        public Player(string name)
        {
            _PlayerName = name;
            GameEventManager.OnGameStart += StartGame;
            GameEventManager.OnGameOver += GameOver;
        }

        private void StartGame()
        {
            Console.WriteLine($"Spawning Player with ID: {_PlayerName}");

        }
        private void GameOver()
        {
            Console.WriteLine($"Removing Player with ID: {_PlayerName}");

        }

    }
}
