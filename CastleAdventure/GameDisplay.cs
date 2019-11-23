using System;
using System.IO;
using CastleAdventure.Entities;

namespace CastleAdventure
{
    public abstract class GameDisplay
    {
        //Declare properties
        public static int GameWidth { get; set; } = 50;
        public static int GameHeight { get; set; } = 20;

        //Draw game map
        public static void DrawMap()
        {
            //Declare local variables
            const char wallModel = '█';
            const char space = ' ';

            //Loop through each axis and draw walls
            for (var y = 0; y <= GameHeight; y++)
            {
                const int minimumWidth = 0;
                for (var x = minimumWidth; x <= GameWidth; x++)
                {
                    if (x == minimumWidth || y == minimumWidth || x == GameWidth || y == GameHeight) Console.Write(wallModel);
                    else Console.Write(space);
                }
                Console.WriteLine();
            }
        }

        //Draw the legend
        public static void DrawLegend()
        {
            Console.SetCursorPosition(GameWidth + 5, 3);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" Legend");
            Console.SetCursorPosition(GameWidth + 5, 4);
            Console.Write("---------");
            Console.ResetColor();

            Console.SetCursorPosition(GameWidth + 5, 6);
            Console.Write("Player = ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write('X');
            Console.ResetColor();

            Console.SetCursorPosition(GameWidth + 5, 7);
            Console.Write("Enemy = ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('$');
            Console.ResetColor();

            Console.SetCursorPosition(GameWidth + 5, 8);
            Console.Write("Coin = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write('o');
            Console.ResetColor();

            Console.SetCursorPosition(GameWidth + 5, 9);
            Console.Write("Key = ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write('!');
            Console.ResetColor();

            Console.SetCursorPosition(GameWidth + 5, 10);
            Console.Write("Sword = ");
            Console.Write('|');
        }

        //Draw the players score
        public static void DrawScore()
        {
            Console.SetCursorPosition(GameWidth + 5, 12);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Score = ");
            Console.Write(GameConditions.Score + "   ");
            Console.ResetColor();
        }

        //Draws the instructions/objective for the game
        public static void DrawObjective()
        {
            Console.SetCursorPosition(1, GameHeight + 2);
            Console.Write("Kill all enemies and find a way to escape.");
        }

        //Draws message when player gets a coin
        public static void DrawMessage(Coin coin)
        {
            Console.SetCursorPosition(1, GameHeight + 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("You got a coin!                      ");
            Console.ResetColor();
        }

        //Draws message when player approaches door without a key
        public static void DrawMessage(Door door)
        {
            Console.SetCursorPosition(1, GameHeight + 5);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("You need a key to unlock this door...");
            Console.ResetColor();
        }

        //Draws message when player gets the key
        public static void DrawMessage(Key key)
        {
            Console.SetCursorPosition(1, GameHeight + 5);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("You found a key!                     ");
            Console.ResetColor();
        }

        //Draws win screen if player wins
        public static void DrawWinScreen()
        {
            Console.Clear();

            var reader = new StreamReader("winscreen.txt");
            var line = reader.ReadLine();
            Console.SetCursorPosition(0, 3);
            while (line != null)
            {
                Console.WriteLine(line);
                line = reader.ReadLine();
            }
            reader.Close();

            Console.SetCursorPosition(36, 25);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your score was {0}",GameConditions.Score);
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        //Draws lose screen if player loses TODO Implement
        public static void DrawLoseScreen()
        {
            Console.Clear();

            var reader = new StreamReader("losescreen.txt");
            var line = reader.ReadLine();
            Console.SetCursorPosition(0, 3);
            while (line != null)
            {
                Console.WriteLine(line);
                line = reader.ReadLine();
            }
            reader.Close();

            Console.SetCursorPosition(36, 25);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your score was {0}", GameConditions.Score);
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}