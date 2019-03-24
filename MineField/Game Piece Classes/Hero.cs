using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField.Game_Piece_Classes
{
    public class Hero : BasePiece
    {
        public int lives;

        public Hero(int number_of_lives)
        {
            lives = number_of_lives;
            color = ConsoleColor.White;
            background_color = ConsoleColor.Black;
        }

        public void RemoveHero()
        {
            Console.ForegroundColor = Constants.PATH_COLOR;
            Console.BackgroundColor = background_color;
            Console.SetCursorPosition(location.X - 3, location.Y - 1);
            Console.Write("/ / / /\n");
            Console.SetCursorPosition(location.X - 3, location.Y);
            Console.Write(" / / / \n");
            Console.SetCursorPosition(location.X - 3, location.Y + 1);
            Console.Write("/ / / /\n");
        }

        public void Move()
        {
            Console.ForegroundColor = color;
            Console.CursorVisible = false;
            Console.SetCursorPosition(location.X -1, location.Y -1);
            Console.Write(" O ");
            Console.SetCursorPosition(location.X -1, location.Y);
            Console.Write("/|\\");
            Console.SetCursorPosition(location.X -1, location.Y +1);
            Console.Write("/ \\");
        }

        public bool TakeLife()
        {
            lives--;
            if (lives == 0)
            {
                // Game Over
                return false;
            }
            return true;
        }
    }
}
