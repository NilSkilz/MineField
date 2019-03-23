using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField
{
    class Game
    {
        public void Draw()
        {
            // TODO: Do this in code and make it beautiful

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
            Console.WriteLine("     Rules: Move using the cursor, avoid the mines!");
            Console.WriteLine("            Press Enter to reset the game");
            
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
            Console.Write("Number of Moves: " + moves.ToString());
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
            Console.Write("                           Score: " + score.ToString());
            Console.CursorLeft = left_position;
            Console.Write("\n\n                      Press ENTER to play again");
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
    }
}