using System;

namespace CastleAdventure.Entities
{
    public class Door : IEntity
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public char Model { get; set; }

        public Door(int x, int y)
        {
            XPosition = x;
            YPosition = y;
            Model = '▒';

            DrawToScreen();
        }

        public void DrawToScreen()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.Write(Model);
        }
    }

    public class Player : IEntity
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public char Model { get; set; }

        public Player(int x, int y)
        {
            XPosition = x;
            YPosition = y;
            Model = 'X';

            DrawToScreen();
        }

        public void Move()
        {
            var pressedKey = Console.ReadKey(true);

            RemoveFromScreen();
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (YPosition - 1 > 0) YPosition--;
                    break;
                case ConsoleKey.RightArrow:
                    if (XPosition + 1 < GameDisplay.GameWidth) XPosition++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (XPosition - 1 > 0) XPosition--;
                    break;
                case ConsoleKey.DownArrow:
                    if (YPosition + 1 < GameDisplay.GameHeight) YPosition++;
                    break;
            }
            DrawToScreen();
        }

        public void DrawToScreen()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Model);
            Console.ResetColor();
        }

        public void RemoveFromScreen()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.Write(' ');
        }
    }
}
