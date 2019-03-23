﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField.Game_Piece_Classes
{
    public class Mine : BasePiece
    {
        public Mine(int start_x, int start_y, Random rnd)
        {
            // generate a random square from 1 - 8
            Coordinate loc = GenerateRandomCoordinate(Constants.GRID_WIDTH, Constants.GRID_HEIGHT, rnd);

            // convert into coordinate on grid
            int x = start_x + (loc.X * Constants.INTERNAL_SQUARE_WIDTH) + loc.X;
            int y = start_y + (loc.Y * Constants.INTERNAL_SQUARE_HEIGHT) + loc.Y;

            Coordinate c = new Coordinate();
            c.X = x;
            c.Y = y;

            location = c;
            color = ConsoleColor.Red;
            background_color = ConsoleColor.Black;
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
        public Coordinate GenerateRandomCoordinate(int grid_width, int grid_height, Random rnd)
        {
            Coordinate location = new Coordinate();
            
            location.X = rnd.Next(1, grid_width+1);
            location.Y = rnd.Next(1, grid_height+1);

            // Check it's not first or last square
            // (actually avoiding mines in A1 - B2 and G7 - H8 squares)
            if ((location.X < 3 && location.Y < 3) || (location.X > grid_width - 2 && location.Y > grid_height - 2))
            {
                location = GenerateRandomCoordinate(grid_width, grid_height, rnd);
            }

            return location;
        }
    }
}
