using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField
{
    // A class to hold all the constants used in the project
    // i.e. colors/fonts/etc
    static class Constants
    {
        public const int NUMBER_OF_MINES = 10;
        public const int MINE_PREVIEW_SECONDS = 3;
        public const bool PLAY_MUSIC = false;
        public const int NUMBER_OF_LIVES = 3;

        // App Colours  
        public const ConsoleColor HERO_COLOR = ConsoleColor.White;
        public const ConsoleColor BACKGROUND_COLOR = ConsoleColor.Black;
        public const ConsoleColor PATH_COLOR = ConsoleColor.White;
        public const ConsoleColor EXPLOSION_COLOR = ConsoleColor.Red;

        // The size of the console window
        public const int WINDOW_WIDTH = 160;
        public const int WINDOW_HEIGHT = 50;

        // The number of internal character spaces in a grid square
        public const int INTERNAL_SQUARE_WIDTH = 7;
        public const int INTERNAL_SQUARE_HEIGHT = 3;

        // At the moment the grid isn't drawn dynamically, so these should not be changed
        // however, the rest of the code has been designed with this feature in mind
        // to avoid reworking the entire project in the future
        public const int GRID_WIDTH = 8;
        public const int GRID_HEIGHT = 8;

        // The top left coordinate of the grid. Calculated dynamically and used for game piece positioning
        public const int START_X = (WINDOW_WIDTH / 2) - (((GRID_WIDTH * (INTERNAL_SQUARE_WIDTH + 1)) + 1) / 2);
        public const int START_Y = 7;
    }
}
