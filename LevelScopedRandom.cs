using System;

namespace GGJ_18
{
    class LevelScopedRandom
    {
        private Level level;

        public Random Random { get; set; }

        public LevelScopedRandom(Random rand, Level level)
        {
            Random = rand;
            this.level = level;
            level.AddLevelScopedRandom(this);
        }

        public int GetRandWidth()
        {
            return Random.Next(0, level.MaxWidth - 1);
        }

        public int GetRandHeight()
        {
            return Random.Next(1, level.MaxHeight - 1);
        }

        public int Next(int min, int max)
        {
            return Random.Next(min, max);
        }
    }
}
