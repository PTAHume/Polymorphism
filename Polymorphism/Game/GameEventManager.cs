using System;

namespace PolymorphismC
{
    internal static class GameEventManager
    {
        public delegate void GameEvent();

        /*Events are forced to behave like a list (+=/-=) 
          foo += mydelgate or foo -= mydelgate is ok but foo = mydelgate is not ok
            Delgate allows signing of = so foo = mydelgate is now ok as is the above 
            but deligate will be overidden whenever set so only set the once
        */
        public static event GameEvent OnGameStart, OnGameOver;

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
