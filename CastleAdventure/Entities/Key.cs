using System;

namespace CastleAdventure.Entities
{
    public class Key : IEntity
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public char Model { get; set; }

        public Key(int x, int y)
        {
            XPosition = x;
            YPosition = y;
            Model = '!';

            DrawToScreen();
        }

        public void DrawToScreen()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(Model);
            Console.ResetColor();
        }
    }
}