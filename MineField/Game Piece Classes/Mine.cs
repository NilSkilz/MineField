using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField.Game_Piece_Classes
{
    public class Mine : BasePiece
    {
        public Mine(Random rnd)
        {
            // generate a random square from 1 - 8
            Coordinate loc = GenerateRandomCoordinate(rnd);
              
            // convert into coordinate on console
            Coordinate c = new Coordinate();
            c.X = Constants.START_X + (loc.X * (Constants.INTERNAL_SQUARE_WIDTH + 1)) - (int)(Math.Floor((double)Constants.INTERNAL_SQUARE_WIDTH / 2)) - 1;
            c.Y = Constants.START_Y + (loc.Y * (Constants.INTERNAL_SQUARE_HEIGHT + 1)) - (int)(Math.Floor((double)Constants.INTERNAL_SQUARE_HEIGHT / 2)) - 1;

            location = c;
            color = ConsoleColor.Red;
            background_color = ConsoleColor.Black;
        }

        public bool hasCollided(Coordinate coordinates)
        {
            if (location.X == coordinates.X && location.Y == coordinates.Y)
            {
                return true;
            }
            return false;
        }
        
        // Show mine temporarily for preview
        public void Draw()
        {
            Console.BackgroundColor = background_color;
            Console.ForegroundColor = color;
            Console.CursorVisible = false;
            Console.SetCursorPosition(location.X, location.Y);
            Console.Write("X");
        }

        // Show mine permenantly on view
        public void Explode()
        {
            Console.ForegroundColor = Constants.EXPLOSION_COLOR;
            Console.SetCursorPosition(location.X - 3, location.Y - 1);
            Console.Write("/ / / /\n");
            Console.SetCursorPosition(location.X - 3, location.Y);
            Console.Write(" / / / \n");
            Console.SetCursorPosition(location.X - 3, location.Y + 1);
            Console.Write("/ / / /\n");
            Console.ForegroundColor = color;
            Console.CursorVisible = false;
            Console.SetCursorPosition(location.X, location.Y);
            Console.Write("X");
        }


        // Remove the mine from view
        public void Remove()
        {
            Console.BackgroundColor = background_color;
            Console.CursorVisible = false;
            Console.SetCursorPosition(location.X, location.Y);
            Console.Write(" ");
        }

        // Random is passed in to avoid the same number being generated (random based on tick)
        public Coordinate GenerateRandomCoordinate(Random rnd)
        {
            Coordinate location = new Coordinate();
            
            location.X = rnd.Next(1, Constants.GRID_WIDTH);
            location.Y = rnd.Next(1, Constants.GRID_HEIGHT);

            // Check it's not first or last square
            // (actually avoiding mines in A1 - B2 and G7 - H8 squares)
            if ((location.X < 3 && location.Y < 3) || (location.X > Constants.GRID_WIDTH - 2 && location.Y > Constants.GRID_HEIGHT - 2))
            {
                location = GenerateRandomCoordinate(rnd);
            }

            return location;
        }
    }
}
