using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField.Game_Piece_Classes
{
    public class Mine : BasePiece
    {
        public Mine(int start_x, int start_y, int square_w, int square_h, int grid_width, int grid_height, Random rnd)
        {
            Coordinate location = GenerateRandomCoordinate(grid_width, grid_height, rnd);

            int x = start_x + (location.X * square_w) + location.X;
            int y = start_y + (location.Y * square_h) + location.Y;

            Coordinate c = new Coordinate();
            c.X = x;
            c.Y = y;

            this.location = c;
        }
        
        public void Draw()
        {
            Console.BackgroundColor = Constants.BACKGROUND_COLOR;
            Console.ForegroundColor = Constants.HERO_COLOR;
            Console.CursorVisible = false;
            Console.SetCursorPosition(location.X, location.Y);
            Console.Write("X");
        }

        public void Explode()
        {
            Console.ForegroundColor = Constants.EXPLOSION_COLOR;
            Console.SetCursorPosition(location.X - 3, location.Y - 1);
            Console.Write("/ / / /\n");
            Console.SetCursorPosition(location.X - 3, location.Y);
            Console.Write(" / / / \n");
            Console.SetCursorPosition(location.X - 3, location.Y + 1);
            Console.Write("/ / / /\n");
            Console.ForegroundColor = Constants.HERO_COLOR;
            Console.CursorVisible = false;
            Console.SetCursorPosition(location.X, location.Y);
            Console.Write("X");
        }

        public void Remove()
        {
            Console.BackgroundColor = Constants.BACKGROUND_COLOR;
            Console.CursorVisible = false;
            Console.SetCursorPosition(location.X, location.Y);
            Console.Write(" ");
        }

        public Coordinate GenerateRandomCoordinate(int grid_width, int grid_height, Random rnd)
        {
            Coordinate location = new Coordinate();
            
            location.X = rnd.Next(1, grid_width+1);
            location.Y = rnd.Next(1, grid_height+1);

            // Check it's not first or last square
            if ((location.X < 3 && location.Y < 3) || (location.X > grid_width - 2 && location.Y > grid_height - 2))
            {
                location = GenerateRandomCoordinate(grid_width, grid_height, rnd);
            }

            return location;
        }
    }
}
