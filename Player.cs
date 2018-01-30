using System;

namespace GGJ_18
{
    class Player
    {
        private char c = 'M';
        private Level level;

        public Player(Level level)
        {
            this.level = level;
            Pos = new Position(level.PlayerStartingPosition.FromLeft, level.PlayerStartingPosition.FromTop);
        }

        public Position Pos { get; set; }
        public bool IsDead { get; set; }
        public bool GoalReached { get; set; }
        public int Coins { get; set; }

        public void Draw()
        {
            Console.SetCursorPosition(0,0);
            Console.Write($"Coins: {Coins}/{level.Goal.CoinsRequired}");

            Console.SetCursorPosition(Pos.FromLeft, Pos.FromTop);
            Console.Write(c);
        }

        public void Change()
        {
            c = c == 'M' ? 'F' : 'M';
        }

        public void Move(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (Pos.FromLeft > 0)
                    {
                        Pos.FromLeft -= 1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (Pos.FromTop > 0)
                    {
                        Pos.FromTop--;

                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (Pos.FromLeft < Console.BufferWidth - 1)
                    {
                        Pos.FromLeft += 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (Pos.FromTop < Console.BufferHeight - 1)
                    {
                        Pos.FromTop++;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
