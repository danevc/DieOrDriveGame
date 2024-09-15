using GameCourseWork.Core;
using Microsoft.Xna.Framework;

namespace GameCourseWork.MonoHelper
{
    class RandomSet
    {
        private static int first = -62;

        public static Vector2 RandomSetting(Vector2 pos, int delta)
        {
            int rnd = GetRandom.IntRandom(1, 5);
            int rnd2 = GetRandom.IntRandom(500, 3000);
            float multiplier = rnd2 / 100;
            switch (rnd)
            {
                case 1:
                    pos = new Vector2(first + Data.distBtwRoads, delta * multiplier);
                    break;
                case 2:
                    pos = new Vector2(first + Data.distBtwRoads*2, delta * multiplier);
                    break;
                case 3:
                    pos = new Vector2(first + Data.distBtwRoads*3, delta * multiplier);
                    break;
                case 4:
                    pos = new Vector2(first + Data.distBtwRoads*4, delta * multiplier);
                    break;
            }
            return pos;
        }
    }
}
