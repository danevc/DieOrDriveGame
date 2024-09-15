using Microsoft.Xna.Framework;

namespace GameCourseWork.Core
{
    public static class Data
    {
        public static int ScreenW  = 500;

        public static int ScreenH = 800;

        public static Vector2 Velocity = new Vector2(0, 6);

        public static int condition = 1;

        public static int Score = 0;

        public static int Coins = 50;

        public static float LevelFuel = 69;

        public static int Record = 0;

        public static int Bullets = 5;

        public static int distBtwRoads = 125;

        public static bool Exit = false;

        public static bool isMenuShooting = false;

        public static bool isNewGame = true;

        public enum scenes { menu, game, pause, gameover }
        public static scenes scene = scenes.menu;
        
        public enum layouts { wasd, arrows }
        public static layouts layout = layouts.wasd;

        public enum improvements { destroyer, simple }
        public static improvements improve = improvements.simple;
    }
}
