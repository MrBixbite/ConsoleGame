using System;
using System.Collections.Generic;
using CastleAdventure.Entities;

namespace CastleAdventure
{
    internal class Program
    {
        private static void Main()
        {
            //Removes cursor
            Console.CursorVisible = false;

            //Draw menu and await user selection
            Menu.DrawMenu();
            Menu.GetMenuSelection();

            //Draw game map
            GameDisplay.DrawMap();
            GameDisplay.DrawLegend();
            GameDisplay.DrawScore();
            GameDisplay.DrawObjective();

            //Create entities
            var random = new Random();
            var player = new Player(1, 1);
            var key = new Key(25, 10);
            var door = new Door(GameDisplay.GameWidth, GameDisplay.GameHeight / 2);
            var sword = new Sword(5, 5);
            var enemies = GetEnemyList(Settings.EnemyAmount, random);
            var coins = GetCoinList(5, random);

            while (GameConditions.GameOver == false)
            {
                player.Move();
                GameConditions.CheckForEntityInteractions(new EntityList(player, enemies, coins, key, door, sword));
            }
        }

        //Returns a list of Coins
        public static List<Coin> GetCoinList(int amount, Random random)
        {
            var coinList = new List<Coin>();

            for (var i = 0; i < amount; i++)
            {
                coinList.Add(new Coin(random.Next(1, GameDisplay.GameWidth - 1), random.Next(1, GameDisplay.GameHeight - 1)));
            }

            return coinList;
        }

        //Returns a list of Enemies
        public static List<Enemy> GetEnemyList(int amount, Random random)
        {
            var enemyList = new List<Enemy>();

            for (var i = 0; i < amount; i++)
            {
                enemyList.Add(new Enemy(random.Next(1, GameDisplay.GameWidth - 1), random.Next(1, GameDisplay.GameHeight - 1)));
            }

            return enemyList;
        }
    }
}