using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField.Game_Piece_Classes
{
    public class Hero : BasePiece
    {
        public const ConsoleColor colour = Constants.HERO_COLOR;
        public int lives;

        public Hero()
        {
            this.location = new Coordinate()
            {
                X = 14,
                Y = 4
            };
            lives = 3;
        }

        public void RemoveHero()
        {
            Console.ForegroundColor = Constants.PATH_COLOR;
            Console.BackgroundColor = Constants.BACKGROUND_COLOR;
            Console.SetCursorPosition(location.X - 3, location.Y - 1);
            Console.Write("/ / / /\n");
            Console.SetCursorPosition(location.X - 3, location.Y);
            Console.Write(" / / / \n");
            Console.SetCursorPosition(location.X - 3, location.Y + 1);
            Console.Write("/ / / /\n");
        }

        public void Move()
        {
            Console.ForegroundColor = Constants.HERO_COLOR;
            Console.CursorVisible = false;
            Console.SetCursorPosition(location.X, location.Y);
            Console.Write("O");
        }

        public bool TakeLife()
        {
           if (lives == 1)
            {
                // Game Over
                return false;
            }
            lives --;
            return true;
        }
    }
}
