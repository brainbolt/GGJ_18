using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GGJ_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;


            Player player;
            var levelService = new LevelFactory();
            var level = levelService.GetLevel(1);

            Console.SetWindowSize(level.MaxWidth + 1, level.MaxHeight + 1);
            Console.SetBufferSize(level.MaxWidth + 1, level.MaxHeight + 1);

            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            start:
            {
                player = new Player(level);
                Start(player, level);
            }

            if (player.IsDead)
            {
                Alert("You Died!", level);
            }
            
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = GetKey();
                    if (key == ConsoleKey.Spacebar)
                    {
                        goto start;
                    }
                    else if (key == ConsoleKey.Q)
                    {
                        break;
                    }
                }
            }
        }

        private static void Alert(string message, Level level)
        {
            string instructions = "Press 'space' to restart or 'q' to quit";
            int height = level.MaxHeight / 2;
            int width = (level.MaxWidth - message.Length) / 2;
            Console.Clear();
            Console.SetCursorPosition(width, height);
            Console.Write(message);
            height += 3;
            width = (level.MaxWidth - instructions.Length) / 2;
            Console.SetCursorPosition(width, height);
            Console.Write(instructions);
        }

        static void Start(Player player, Level level)
        {
            Draw(player, level);

            while (!player.IsDead)
            {
                if (Console.KeyAvailable)
                {
                    player.Move(GetKey());
                    Draw(player, level);
                }
            }
        }

        static void Draw(Player player, Level level)
        {
            Console.Clear();

            level.Goal.Draw();

            GameItem itemToRemove = null;

            if(player.Pos.Equals(level.Goal.Pos))
            {
                level.Goal.ActOnPlayer(player);
            }
            else
            {
                foreach (var item in level.Items)
                {
                    item.Draw();

                    if (item.Pos.Equals(player.Pos))
                    {
                        
                        if (item.ActOnPlayer(player))
                        {
                            itemToRemove = item;
                        }
                    }
                }
            }

            if (itemToRemove != null)
            {
                level.Items.Remove(itemToRemove);
            }

            player.Draw();
        }

        static ConsoleKey GetKey()
        {
            return Console.ReadKey().Key;
        }
    }
}
