using System;

namespace CastleAdventure.Entities
{
    public class Coin : IEntity
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public char Model { get; set; }

        public Coin(int x, int y)
        {
            XPosition = x;
            YPosition = y;
            Model = 'o';

            DrawToScreen();
        }

        public void DrawToScreen()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Model);
            Console.ResetColor();
        }
    }
}