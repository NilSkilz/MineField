using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField
{
    class ScreenManager
    {
        const int SQUARE_WIDTH = 7;
        const int SQUARE_HEIGHT = 3;

        public void DrawAssets()
        {
            int left_position = (Console.WindowWidth / 2) - 15;

            Console.ForegroundColor = Constants.HERO_COLOR;
            Console.CursorTop = 2;
            Console.CursorLeft = left_position;
            Console.Write("   __  ____         _____     __   __\n");
            Console.CursorLeft = left_position;
            Console.Write("  /  |/  (_)__ ___ / __(_)__ / /__/ /\n");
            Console.CursorLeft = left_position;
            Console.Write(" / /|_/ / / _ \\/ -_) _// / -_) / _  /\n");
            Console.CursorLeft = left_position;
            Console.Write("/_/  /_/_/_//_/\\__/_/ /_/\\__/_/\\_,_/\n");


            Console.CursorTop = 42;
            Console.WriteLine("     Rules: Move your hero using the cursor to get to the treasure, but avoid the mines!");
            Console.WriteLine("            Press ENTER to reset the game or ESC to quit");
            
            Console.ResetColor();
        }

        public void UpdateLives(int lives)
        {
            Console.ForegroundColor = Constants.HERO_COLOR;
            Console.BackgroundColor = Constants.BACKGROUND_COLOR;
            Console.CursorTop = 20;
            Console.CursorLeft = 5;
            Console.Write("Number of Lives: " + lives.ToString());
        }

        public void UpdateMoves(int moves)
        {
            Console.ForegroundColor = Constants.HERO_COLOR;
            Console.BackgroundColor = Constants.BACKGROUND_COLOR;
            Console.CursorTop = 22;
            Console.CursorLeft = 5;
            Console.Write("Number of Moves: " + moves.ToString() + "   "); // Added extra spaces to avoid "units" showing on reset
        }

        public void YouWin(int score)
        {
            int left_position = (Console.WindowWidth / 2) - 35;

            Console.ForegroundColor = Constants.HERO_COLOR;
            Console.CursorTop = 10;
            Console.CursorLeft = left_position;
            Console.Write("▓██   ██▓ ▒█████   █    ██     █     █░ ██▓ ███▄    █  ▐██▌  ▐██▌ \n");
            Console.CursorLeft = left_position;
            Console.Write(" ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▓█░ █ ░█░▓██▒ ██ ▀█   █  ▐██▌  ▐██▌ \n");
            Console.CursorLeft = left_position;
            Console.Write("  ▒██ ██░▒██░  ██▒▓██  ▒██░   ▒█░ █ ░█ ▒██▒▓██  ▀█ ██▒ ▐██▌  ▐██▌ \n");
            Console.CursorLeft = left_position;
            Console.Write("  ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░█░ █ ░█ ░██░▓██▒  ▐▌██▒ ▓██▒  ▓██▒ \n");
            Console.CursorLeft = left_position;
            Console.Write("  ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░░██▒██▓ ░██░▒██░   ▓██░ ▒▄▄   ▒▄▄  \n");
            Console.CursorLeft = left_position;
            Console.CursorLeft = left_position;
            Console.Write("   ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒    ░ ▓░▒ ▒  ░▓  ░ ▒░   ▒ ▒  ░▀▀▒  ░▀▀▒ \n");
            Console.CursorLeft = left_position;
            Console.Write(" ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░      ▒ ░ ░   ▒ ░░ ░░   ░ ▒░ ░  ░  ░  ░ \n");
            Console.CursorLeft = left_position;
            Console.Write(" ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░      ░   ░   ▒ ░   ░   ░ ░     ░     ░ \n");
            Console.CursorLeft = left_position;
            Console.Write(" ░ ░         ░ ░     ░            ░     ░           ░  ░     ░    \n");
            Console.CursorLeft = left_position;
            Console.Write(" ░ ░                                                              \n\n\n\n");
            Console.CursorLeft = left_position;
            Console.Write("                           Score: " + score.ToString() + "\n\n");
            Console.CursorLeft = left_position;
            Console.Write("                      Press ENTER to play again");
        }

        public void GameOver()
        {
            int left_position = (Console.WindowWidth / 2) - 35;

            Console.ForegroundColor = Constants.HERO_COLOR;
            Console.CursorTop = 10;
            Console.CursorLeft = left_position;
            Console.Write("  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  \n");
            Console.CursorLeft = left_position;
            Console.Write(" ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒\n");
            Console.CursorLeft = left_position;
            Console.Write("▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒\n");
            Console.CursorLeft = left_position;
            Console.Write("░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  \n");
            Console.CursorLeft = left_position;
            Console.Write("░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒\n");
            Console.CursorLeft = left_position;
            Console.Write(" ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░\n");
            Console.CursorLeft = left_position;
            Console.Write("  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░\n");
            Console.CursorLeft = left_position;
            Console.Write("░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ \n");
            Console.CursorLeft = left_position;
            Console.Write("      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     \n");
            Console.CursorLeft = left_position;
            Console.Write("                                                     ░                   \n\n\n\n");
            Console.CursorLeft = left_position;
            Console.Write("                      Press ENTER to try again");
        }

        public void DrawGrid(int horizontal_squares, int vertical_squares)
        {

            int grid_width = (SQUARE_WIDTH * horizontal_squares) + 1;
            int centre_x = Console.WindowWidth / 2;
            Coordinate hLocation = new Coordinate();
            hLocation.Y = 7;
            hLocation.X = centre_x - ((grid_width / 2) + 1);
        
        // TODO: This could be generated with code, to enable dynamic numbers of rows/columns. However the spec
        // did not include this feature.

        Console.ForegroundColor = Constants.HERO_COLOR;
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
            Console.Write("│       │       │       │       │       │       │       │  ┌┴┐  │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("│       │       │       │       │       │       │       │  └─┘  │\n");
            Console.CursorLeft = hLocation.X;
            Console.Write("└───────┴───────┴───────┴───────┴───────┴───────┴───────┴───────┘\n");
            Console.ResetColor();
        }
    }
}