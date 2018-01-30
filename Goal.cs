using System;

namespace GGJ_18
{
    class Goal : GameItem
    {
        public int CoinsRequired { get; private set; }
        private Level Level;

        public Goal(Position pos, Level level, int coinsRequired) : base('H', pos, level)
        {
            CoinsRequired = coinsRequired;
            Level = level;
        }

        public override bool ActOnPlayer(Player p)
        {
            if (p.Coins >= CoinsRequired)
            {
                p.Coins -= CoinsRequired;
                p.GoalReached = true;
                p.Change();
                Level.GoalReached();

                string message = "Success!!";
                int width = (level.MaxWidth - message.Length) / 2;
                int height = level.MaxHeight / 2;
                Console.SetCursorPosition(width, height);
                Console.Write(message);
            }
            else
            {
                Console.Clear();
                string message = "Not enough coins!!";
                int width = (level.MaxWidth - message.Length) / 2;
                int height = level.MaxHeight / 2;
                Console.SetCursorPosition(width, height);
                Console.Write(message);
                Console.SetCursorPosition(p.Pos.FromLeft, p.Pos.FromTop);
            }

            return false;
        }
    }
}
