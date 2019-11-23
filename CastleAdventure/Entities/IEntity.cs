namespace CastleAdventure.Entities
{
    internal interface IEntity
    {
        int XPosition { get; set; }
        int YPosition { get; set; }
        char Model { get; set; }

        void DrawToScreen();
    }
}
