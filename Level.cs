using System;
using System.Collections.Generic;

namespace GGJ_18
{
    class Level
    {
        public int Id { get; set; }
        public List<GameItem> Items { get; private set; }
        public bool IsEnded { get; private set; }
        public Goal Goal { get; private set; }
        public int MaxWidth { get; private set; }
        public int MaxHeight { get; private set; }
        public Position PlayerStartingPosition { get; private set; }

        private LevelScopedRandom sr;
        public Level(int maxWidth, int maxHeight, Position playerStartingPosition, int coinsRequired)
        {
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
            Items = new List<GameItem>();
            Goal = new Goal(new Position(MaxWidth - 1, MaxHeight / 2), this, coinsRequired);
            PlayerStartingPosition = playerStartingPosition;
        }

        public void AddItems(IList<GameItem> items)
        {
            Items.AddRange(items);
        }

        public void AddLevelScopedRandom(LevelScopedRandom sr)
        {
            this.sr = sr;
        }

        public void GoalReached()
        {
            IsEnded = true;
        }

        public void EndingSequence()
        {
            string message = $"Congratulations!! You completed level {Id}"; 
            int height = MaxHeight / 2;
            int width = (MaxWidth - message.Length) / 2;
            Console.Clear();
            Console.SetCursorPosition(width, height);
            Console.Write(message);
        }
    }
}
