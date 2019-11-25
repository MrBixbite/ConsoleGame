using System;

namespace CastleAdventure
{
    //TODO FIX SETTINGS!!
    public abstract class Settings
    {
        //Declare properties
        public static int EnemyAmount { get; set; } = 5;

        //Draw the settings
        public static void DrawSettings()
        {
            Console.Write("Amount of Enemies: " + EnemyAmount);
        }

        //Get user selection (input) for settings
        public static void GetSettingsSelection()
        {
            var pressedKey = Console.ReadKey(true);

            while (pressedKey.Key != ConsoleKey.Escape)
            {
                switch (pressedKey.Key)
                {
                    case ConsoleKey.W:
                        EnemyAmount++;
                        break;
                    case ConsoleKey.S:
                        EnemyAmount--;
                        break;
                }

                Console.Clear(); //TODO Temporary fix
                DrawSettings();
                pressedKey = Console.ReadKey(true);
            }

            Console.Clear();
            Menu.DrawMenu();
            Menu.GetMenuSelection();
        }
    }
}