using System;

namespace GameCourseWork.MonoHelper
{
    class GetRandom
    {
        static Random rnd = new Random();
        static public int IntRandom(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }
}
