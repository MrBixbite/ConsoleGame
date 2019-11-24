namespace CastleAdventure
{
    public abstract class GameConditions
    {
        public static bool GameOver { get; set; }
        public static int Score { get; set; }
        public static bool HasKey { get; set; }
        public static bool HasSword { get; set; }

        public static void CheckForEntityInteractions(EntityList entityList)
        {
            //Check if object is visible to player TODO FIX
            foreach (var enemy in entityList.Enemies)
            {
                if (entityList.Player.XPosition == enemy.XPosition &&
                    entityList.Player.YPosition == enemy.YPosition &&
                    !HasSword)
                {
                    Score -= 100;
                    GameDisplay.DrawScore();
                    enemy.XPosition = 0;
                    enemy.YPosition = 0;
                }
                else if (entityList.Player.XPosition == enemy.XPosition &&
                         entityList.Player.YPosition == enemy.YPosition &&
                         HasSword)
                {
                    Score += 200;
                    GameDisplay.DrawScore();
                    enemy.XPosition = 0;
                    enemy.YPosition = 0;
                }
            }

            //Check if player overlaps coin
            foreach (var coin in entityList.Coins)
            {
                if (entityList.Player.XPosition == coin.XPosition &&
                    entityList.Player.YPosition == coin.YPosition)
                {
                    Score += 100;
                    GameDisplay.DrawScore();
                    coin.XPosition = 0;
                    coin.YPosition = 0;
                    GameDisplay.DrawMessage(coin);
                }
            }

            //Checks if player overlaps key
            if (entityList.Player.XPosition == entityList.Key.XPosition &&
                entityList.Player.YPosition == entityList.Key.YPosition)
            {
                HasKey = true;
                entityList.Key.XPosition = 0;
                entityList.Key.YPosition = 0;
                GameDisplay.DrawMessage(entityList.Key);
            }

            //Checks if player unlocks door
            if (entityList.Player.XPosition == entityList.Door.XPosition - 1 &&
                entityList.Player.YPosition == entityList.Door.YPosition && HasKey)
            {
                GameOver = true;
                GameDisplay.DrawWinScreen();
            }
            else if (entityList.Player.XPosition == entityList.Door.XPosition - 1 &&
                     entityList.Player.YPosition == entityList.Door.YPosition && !HasKey)
            {
                GameDisplay.DrawMessage(entityList.Door);
            }

            //Checks if player collects sword
            if (entityList.Player.XPosition == entityList.Sword.XPosition &&
                entityList.Player.YPosition == entityList.Sword.YPosition)
                HasSword = true;
        }
    }
}