using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField
{
    public class Grid
    {
        public int hHorizontal_squares;
        public int hVertical_squares;
        public Coordinate hLocation;
        public ConsoleColor hBorderColor;

        const int SQUARE_WIDTH = 7;
        const int SQUARE_HEIGHT = 3;

        public Grid(int horizontal_squares, int vertical_squares, ConsoleColor borderColor)
        {
            hHorizontal_squares = horizontal_squares;
            hVertical_squares = vertical_squares;
            //hLocation = location;
            hBorderColor = borderColor;

            int grid_width = (SQUARE_WIDTH * 8) + 1;
            int centre_x = Console.WindowWidth / 2;
            hLocation = new Coordinate();
            hLocation.Y = 7;
            hLocation.X = centre_x - ((grid_width / 2)+1);
        }

        public Coordinate Location
        {
            get { return hLocation; }
            set { hLocation = value; }
        }

        public int Horizontal_squares
        {
            get { return hHorizontal_squares; }
            set { hHorizontal_squares = value; }
        }

        public int Vertical_squares
        {
            get { return hVertical_squares; }
            set { hVertical_squares = value; }
        }

        public ConsoleColor BorderColor
        {
            get { return hBorderColor; }
            set { hBorderColor = value; }
        }

        public void Draw()
        {
            // TODO: Do this in code and make it beautiful

            Console.ForegroundColor = BorderColor;
            Console.CursorTop = hLocation.Y;
            Console.CursorLeft = hLocation.X;
            Console.Write("┌───────┬───────┬───────┬───────┬───────┬───────┬───────┬───────┐\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("├───────┼───────┼───────┼───────┼───────┼───────┼───────┼───────┤\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("├───────┼───────┼───────┼───────┼───────┼───────┼───────┼───────┤\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("├───────┼───────┼───────┼───────┼───────┼───────┼───────┼───────┤\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("├───────┼───────┼───────┼───────┼───────┼───────┼───────┼───────┤\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("├───────┼───────┼───────┼───────┼───────┼───────┼───────┼───────┤\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("├───────┼───────┼───────┼───────┼───────┼───────┼───────┼───────┤\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("├───────┼───────┼───────┼───────┼───────┼───────┼───────┼───────┤\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │       │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("└───────┴───────┴───────┴───────┴───────┴───────┴───────┴───────┘\n");
            Console.ResetColor();
        }
    }
}
