using GameCourseWork.Core;

namespace GameCourseWork.MonoHelper
{
    class NewGame
    {
        public static void newGame()
        {
            Data.LevelFuel = 69;
            Data.isNewGame = true;
            Data.Score = 0;
            Data.Coins = 40;
            Data.Bullets = 3;
            Data.Velocity.Y = 6;
            Data.improve = Data.improvements.simple;
            Data.condition = 1;
        }
    }
}
