using System.Collections.Generic;
using CastleAdventure.Entities;

namespace CastleAdventure
{
    //This class is used for certain methods to reduce long parameter lists 
    public class EntityList
    {
        public EntityList(Player player, List<Enemy> enemies, List<Coin> coin, Key key, Door door, Sword sword)
        {
            Player = player;
            Enemies = enemies;
            Coins = coin;
            Key = key;
            Door = door;
            Sword = sword;
        }

        public Player Player { get; }
        public List<Enemy> Enemies { get; }
        public List<Coin> Coins { get; }
        public Key Key { get; }
        public Door Door { get; }
        public Sword Sword { get; }
    }
}