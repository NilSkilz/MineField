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
        const int GRID_WIDTH = 8;
        const int GRID_HEIGHT = 8;

        const int INTERNAL_SQUARE_WIDTH = 7;
        const int INTERNAL_SQUARE_HEIGHT = 3;

        const int WINDOW_WIDTH = 160;
        const int WINDOW_HEIGHT = 50;

        const int PADDING_X = 10;
        const int PADDING_Y = 5;

        const int NUMBER_OF_MINES = 10;
        const int MINE_PREVIEW_SECONDS = 1;

        const int START_X = (WINDOW_WIDTH / 2) - (((GRID_WIDTH * (INTERNAL_SQUARE_WIDTH + 1)) + 1) / 2);
        const int START_Y = 7;

        public static int moves;

        public static Hero hero { get; set; } //Will represent our hero that's moving around :P/>
        public static Game game { get; set; }
        public static List<Mine> mines { get;  set;}

        static SoundPlayer music = new SoundPlayer("music");

        static void Main(string[] args)
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
            mines = new List<Mine>();

           // PlayMusic();

            InitGame();

            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {

                    // Height and Width need '+1' to include the border 
                    case ConsoleKey.UpArrow:
                        MoveHero(0, -INTERNAL_SQUARE_HEIGHT - 1);
                        break;

                    case ConsoleKey.RightArrow:
                        MoveHero(INTERNAL_SQUARE_WIDTH + 1, 0);
                        break;

                    case ConsoleKey.DownArrow:
                        MoveHero(0, INTERNAL_SQUARE_HEIGHT + 1);
                        break;

                    case ConsoleKey.LeftArrow:
                        MoveHero(-INTERNAL_SQUARE_WIDTH - 1, 0);
                        break;

                    case ConsoleKey.Enter:
                        Reset();
                        break;
                }
            }
        }

        /// <summary>
        /// Paint the new hero
        /// </summary>
        static void MoveHero(int x, int y)
        {
            Hero newHero = new Hero();
            Coordinate newLocation = new Coordinate()
            {
                X = hero.location.X + x,
                Y = hero.location.Y + y
            };

            newHero.location = newLocation;

            if (CanMove(newHero.location))
            {
                hero.RemoveHero();
                newHero.Move();
                hero = newHero;
            }


        }


        /// <summary>
        /// Make sure that the new coordinate is not placed outside the
        /// console window (since that will cause a runtime crash
        /// </summary>
        static bool CanMove(Coordinate c)
        {
            moves += 1;
            game.UpdateMoves(moves);

            if (c.X < START_X || c.X >= START_X + (GRID_WIDTH * (INTERNAL_SQUARE_WIDTH + 1)))
                return false;

            if (c.Y < START_Y || c.Y >= START_Y + (GRID_HEIGHT * (INTERNAL_SQUARE_HEIGHT + 1)))
                return false;

            foreach (Mine mine in mines)
            {
                if (mine.location.X == c.X && mine.location.Y == c.Y)
                {
                    if (!hero.TakeLife())
                    {
                        LoseGame();
                    }
                    game.UpdateLives(hero.lives);
                    mine.Explode();
                    return false;
                }
            }


            if (c.X > START_X + ((GRID_WIDTH -1) * (INTERNAL_SQUARE_WIDTH + 1)) &&
                c.Y > START_Y + ((GRID_HEIGHT -1) * (INTERNAL_SQUARE_HEIGHT + 1)))
            {
                WinGame();
                return false;
            }

                return true;
        }

        static void Reset()
        {
            InitGame();
        }

        static void WinGame()
        {
            Console.Clear();
            game.YouWin(moves);
        }

        static void LoseGame()
        {
            Console.Clear();
            game.GameOver();
        }

        /// <summary>
        /// Paint a background color
        /// </summary>
        /// <remarks>
        /// It is very important that you run the Clear() method after
        /// changing the background color since this causes a repaint of the background
        /// </remarks>
        static void SetBackgroundColor()
        {
            Console.BackgroundColor = Constants.BACKGROUND_COLOR;
            Console.Clear(); //Important!
        }

        /// <summary>
        /// Initiates the game by painting the background
        /// and initiating the hero
        /// </summary>
        static void InitGame()
        {
            SetBackgroundColor();
            CreateGrid();

            hero = new Hero();

            Coordinate location = new Coordinate()
            {
                X = START_X + 7,
                Y = START_Y + 2
            };

            hero.location = location;

            DrawTitle();

            MoveHero(0, 0);
            moves = 0;
            
            mines = GenerateMines();
            PreviewMines();

        }

        static void DrawTitle()
        {
            game = new Game();
            game.Draw();

            game.UpdateLives(hero.lives);
            game.UpdateMoves(moves);
        }

        static void CreateGrid()
        {

            Coordinate location = new Coordinate();

            location.X = PADDING_X;
            location.Y = PADDING_Y;

            Grid grid = new Grid(GRID_WIDTH, GRID_HEIGHT, Constants.HERO_COLOR);

            grid.Draw();
        }

        // Generate an array of random coordinates
        static List<Mine> GenerateMines()
        {
            List<Mine> mines = new List<Mine>();
            Random rnd = new Random();
            for (int i = 0; i < NUMBER_OF_MINES; i++)
            {
                Mine mine = new Mine(START_X-1, START_Y-2, INTERNAL_SQUARE_WIDTH, INTERNAL_SQUARE_HEIGHT, GRID_WIDTH, GRID_HEIGHT, rnd);
                // Check it doesn't exist already
                int milliseconds = 10;
                Thread.Sleep(milliseconds);

                mines.Add(mine);
            }

            return mines;
        }

        static void PlayMusic()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            player.SoundLocation = projectDirectory + "\\music.wav";
            player.Play();
        }

        static void PreviewMines()
        {
            if (MINE_PREVIEW_SECONDS > 0)
            {
                int delay = MINE_PREVIEW_SECONDS * 1000;
                foreach(Mine mine in mines)
                {
                    mine.Draw();
                }

                Thread.Sleep(delay);
                foreach (Mine mine in mines)
                {
                    mine.Remove();
                }

            }
        }
    }
}