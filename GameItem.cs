using System;

namespace GGJ_18
{
    class GameItem
    {
        protected Level level;
        public char DisplayChar { get; set; }
        public Position Pos { get; set; }

        public GameItem(char displayChar, Position pos, Level level)
        {
            DisplayChar = displayChar;
            Pos = pos;
            this.level = level;
        }

        public virtual bool ActOnPlayer(Player p)
        {
            return false;
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition(Pos.FromLeft, Pos.FromTop);
            Console.Write(DisplayChar);
        }
    }
}
