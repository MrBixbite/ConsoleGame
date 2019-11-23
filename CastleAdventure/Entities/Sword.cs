using System;

namespace CastleAdventure.Entities
{
    public class Sword : IEntity
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public char Model { get; set; }

        public Sword(int x, int y)
        {
            XPosition = x;
            YPosition = y;
            Model = '|';

            DrawToScreen();
        }

        public void DrawToScreen()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.Write(Model);
            Console.ResetColor();
        }
    }
}