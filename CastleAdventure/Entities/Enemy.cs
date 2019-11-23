using System;

namespace CastleAdventure.Entities
{
    public class Enemy : IEntity
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public char Model { get; set; }

        public Enemy(int x, int y)
        {
            XPosition = x;
            YPosition = y;
            Model = '$';

            DrawToScreen();
        }

        public void DrawToScreen()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.ForegroundColor = ConsoleColor.Red;
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