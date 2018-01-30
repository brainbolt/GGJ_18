using System;
using System.Collections.Generic;

namespace GGJ_18
{
    class LevelFactory
    {
        public Level GetLevel(int id)
        {
            int maxX = Console.LargestWindowWidth;
            int maxY = Console.LargestWindowHeight;



            if (id == 0)
            {
                int levelMaxWidth = Convert.ToInt32(maxX * .1);
                int levelMaxHeight = Convert.ToInt32(maxY * .1);
                var startingPosition = new Position(1, levelMaxHeight / 2);
                var level = new Level(levelMaxWidth, levelMaxHeight, startingPosition, 5);
                var sr = new LevelScopedRandom(new Random(), level);
                level.AddLevelScopedRandom(sr);

                var coins = new List<GameItem>()
                {
                    new Coin(new Position(startingPosition.FromLeft, startingPosition.FromTop), level),
                    new Coin(new Position(startingPosition.FromLeft + 1, startingPosition.FromTop), level),
                    new Coin(new Position(startingPosition.FromLeft + 2, startingPosition.FromTop), level),
                    new Coin(new Position(startingPosition.FromLeft + 3, startingPosition.FromTop), level),
                    new Coin(new Position(startingPosition.FromLeft + 4, startingPosition.FromTop), level),
                };

                level.AddItems(coins);
                level.Id = 0;
                return level;
            }
            else
            {
                var items = new List<GameItem>();
                int levelMaxWidth = Convert.ToInt32(maxX * .5);
                int levelMaxHeight = Convert.ToInt32(maxY * .5);

                var startingPosition = new Position(0, Console.WindowHeight / 2);

                var level = new Level(levelMaxWidth, levelMaxHeight, startingPosition, 10);
                var sr = new LevelScopedRandom(new Random(), level);

                int numCoins = 50;

                for (int i = 0; i < numCoins; i++)
                {
                    items.Add(new Coin(new Position(sr.GetRandWidth(), sr.GetRandHeight()), level));
                }

                int numKillers = 50;

                for (int i = 0; i < numKillers; i++)
                {
                    items.Add(new Killer(new Position(sr.GetRandWidth(), sr.GetRandHeight()), sr.Random, level));
                }
                
                level.AddItems(items);
                level.Id = 1;

                return level;
            }
        }
    }
}
