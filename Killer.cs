using System;

namespace GGJ_18
{
    class Killer : MovableGameItem
    {
        private Random r;
        public Killer(Position pos, Random rand, Level level) : base('x', pos, level)
        {
            r = rand;
        }

        public override bool ActOnPlayer(Player p)
        {
            p.IsDead = true;
            return false;
        }

        public override void Draw()
        {
            Move();
            base.Draw();
        }

        private void Move()
        {
            switch (r.Next(1, 9))
            {
                case 1:
                    MoveLeft();
                    MoveDown();
                    break;
                case 2:
                    MoveDown();
                    break;
                case 3:
                    MoveRight();
                    MoveDown();
                    break;
                case 4:
                    MoveRight();
                    break;
                case 5:
                    MoveUp();
                    MoveRight();
                    break;
                case 6:
                    MoveUp();
                    break;
                case 7:
                    MoveLeft();
                    MoveUp();
                    break;
                case 8:
                    MoveLeft();
                    break;
            }
        }

        public void MoveRight()
        {
            if (Pos.FromLeft < level.MaxWidth - 1) Pos.FromLeft++;
        }

        public void MoveLeft()
        {
            if (Pos.FromLeft > 1) Pos.FromLeft--;
        }

        public void MoveUp()
        {
            if (Pos.FromTop > 1) Pos.FromTop--;
        }

        public void MoveDown()
        {
            if (Pos.FromTop < level.MaxHeight - 1) Pos.FromTop++;

        }
    }
}
