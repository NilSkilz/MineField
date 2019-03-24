using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MineField.Game_Piece_Classes;
using System.Threading;
using System.Media;
using WMPLib;
using System.IO;

namespace MineField
{
    public class Coordinate
    {
        public int X { get; set; } //Left
        public int Y { get; set; } //Top
    }

    class Program
    {
        // Keep count of the number of moves taken
        static int moves;

        // Allow user input - not sure if this is the best way to do this in C#...
        static bool allow_user_input = false;

        // Toggle the music
        static bool play_music = false;

        // Will represent our hero that's moving around :P/>
        static Hero hero { get; set; }

        // Handles drawing the U (Grid, lives, rules, etc)
        static ScreenManager manager { get; set; }

        // A list of the current mines
        static List<Mine> mines { get;  set;}

        static SoundPlayer player;

        static void Main(string[] args)
        {
            // Set the window size to show the entire grid + rules etc
            Console.SetWindowSize(Constants.WINDOW_WIDTH, Constants.WINDOW_HEIGHT);

            
            // Init the game and draw the assets
            InitGame();

            // Start the music!!!!
            PlayMusic();

            // Detect key presses
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {

                    // Height and Width need '+1' to include the border 
                    case ConsoleKey.UpArrow:
                        if (allow_user_input)
                            MoveHero(0, -Constants.INTERNAL_SQUARE_HEIGHT - 1);
                        break;

                    case ConsoleKey.RightArrow:
                        if (allow_user_input)
                            MoveHero(Constants.INTERNAL_SQUARE_WIDTH + 1, 0);
                        break;

                    case ConsoleKey.DownArrow:
                        if (allow_user_input)
                            MoveHero(0, Constants.INTERNAL_SQUARE_HEIGHT + 1);
                        break;

                    case ConsoleKey.LeftArrow:
                        if (allow_user_input)
                            MoveHero(-Constants.INTERNAL_SQUARE_WIDTH - 1, 0);
                        break;

                    case ConsoleKey.Enter:
                        Reset();
                        break;

                    case ConsoleKey.Spacebar:
                        ToggleMusic();
                        break;
                }
            }
        }

        //-----------------------------------
        // Hero Moving


        // Move the Hero and update the UI
        static void MoveHero(int x, int y)
        {
            Hero newHero = new Hero(hero.lives);
            Coordinate newLocation = new Coordinate()
            {
                X = hero.location.X + x,
                Y = hero.location.Y + y
            };

            newHero.location = newLocation;

            if (CanMove(newHero.location))
            {
                if (x == 0 && y == 0)
                {
                    
                } else
                {
                    hero.RemoveHero();
                }
                newHero.Move();
                hero = newHero;
            }
        }


        /// <summary>
        /// Make sure that the new coordinate is not outside the grid
        /// Detect Mine collisions
        /// </summary>
        static bool CanMove(Coordinate c)
        {
            moves += 1;
            manager.UpdateMoves(moves);

            if (c.X < Constants.START_X || c.X >= Constants.START_X + (Constants.GRID_WIDTH * (Constants.INTERNAL_SQUARE_WIDTH + 1)))
                return false;

            if (c.Y < Constants.START_Y || c.Y >= Constants.START_Y + (Constants.GRID_HEIGHT * (Constants.INTERNAL_SQUARE_HEIGHT + 1)))
                return false;

            foreach (Mine mine in mines)
            {
                if (mine.hasCollided(c))
                {
                    if (!hero.TakeLife())
                    {
                        LoseGame();
                        return false;
                    }
                    manager.UpdateLives(hero.lives);
                    mine.Explode();
                    return false;
                }
            }

            // Get bottom right square
            // Start x/y + number of squares -1 (i.e. 7) * the internal width + border (i.e. 8)
            if (c.X > Constants.START_X + ((Constants.GRID_WIDTH -1) * (Constants.INTERNAL_SQUARE_WIDTH + 1)) &&
                c.Y > Constants.START_Y + ((Constants.GRID_HEIGHT -1) * (Constants.INTERNAL_SQUARE_HEIGHT + 1)))
            {
                WinGame();
                return false;
            }

                return true;
        }

        //-----------------------------------
        // Game 


        static void Reset()
        {
            allow_user_input = false;
            InitGame();
        }


        static void WinGame()
        {
            allow_user_input = false;
            Console.Clear();
            manager.YouWin(moves);
        }


        static void LoseGame()
        {
            allow_user_input = false;
            Console.Clear();
            manager.GameOver();
        }

        // Paint a background color
        static void SetBackgroundColor()
        {
            Console.BackgroundColor = Constants.BACKGROUND_COLOR;
            Console.Clear(); //Important!
        }


        static void InitGame()
        {
            // Paint the background color
            SetBackgroundColor();

            // Reset the number of moves
            moves = -1;

            // Create a new hero
            hero = new Hero(Constants.NUMBER_OF_LIVES);

            // Draw the UI assets
            DrawAssets();

            // Position hero on 1st square
            hero.location = new Coordinate()
            {
                X = Constants.START_X + 1 + (int)Math.Floor((Double)Constants.INTERNAL_SQUARE_WIDTH / 2), // Start X plus border plus half square width 
                Y = Constants.START_Y + 1 + (int)Math.Floor((Double)Constants.INTERNAL_SQUARE_HEIGHT / 2)  // Start Y plus border plus 
            };

            // Init the mines array
            mines = new List<Mine>();
            GenerateMines();

            // Draw the hero
            MoveHero(0, 0);
        }


        static void DrawAssets()
        {
            manager = new ScreenManager();
            manager.DrawAssets();
            manager.DrawGrid(Constants.GRID_WIDTH, Constants.GRID_HEIGHT);

            manager.UpdateLives(hero.lives);
            manager.UpdateMoves(moves);
        }


        // Generate an array of random coordinates
        static void GenerateMines()
        {
            Random rnd = new Random();
            for (int i = 0; i < Constants.NUMBER_OF_MINES; i++)
            {
                Mine mine = new Mine(rnd);

                // Check if one exists
                bool exists = false;
                foreach(Mine m in mines)
                {
                    if (m.location.X == mine.location.X && m.location.Y == mine.location.Y)
                    {
                        // Try again
                        exists = true;
                    }
                }

                if (!exists)
                {
                    mines.Add(mine);
                } else
                {
                    i--;
                }
            }

            // If there is a mine preview set, then show the mines for a short time
            PreviewMines();
        }

        // Show the mines for a short time. 
        static void PreviewMines()
        {
            if (Constants.MINE_PREVIEW_SECONDS > 0)
            {
                int delay = Constants.MINE_PREVIEW_SECONDS * 1000;
                foreach(Mine mine in mines)
                {
                    mine.Draw();
                }

                Thread.Sleep(delay);
                foreach (Mine mine in mines)
                {
                    mine.Remove();
                }

                allow_user_input = true;
            } else
            {
                allow_user_input = true;
            }
        }

        static void ToggleMusic()
        {
            play_music = !play_music;
            PlayMusic();
        }

        // What's an ASCII based Retro game without music?!
        static void PlayMusic()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string path = projectDirectory + "\\music.wav";

            if (!File.Exists(path))
            {
                return;
            }

            if (player == null)
            {
                player = new System.Media.SoundPlayer(path);
            }

            if (play_music)
            {
                player.Play();
            } else
            {
                player.Stop();
            }
        }
    }
}