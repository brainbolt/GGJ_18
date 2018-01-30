using System;

namespace GGJ_18
{
    class Coin : GameItem
    {
        private char c = 'c';

        public Coin(Position pos, Level level) : base('c', pos, level)
        {

        }

        public override bool ActOnPlayer(Player p)
        {
            p.Coins++;
            return true;
        }
    }
}
