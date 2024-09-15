using Microsoft.Xna.Framework;

namespace GameCourseWork.MonoHelper
{
    class Timer1
    {
        private float _elapsed;

        public Timer1()
        {
            _elapsed = 0;
            elapsed1 = 0;
        }

        public bool timer(float delay, GameTime gameTime)
        {
            elapsed1 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed1 >= delay)
            {
                elapsed1 = 0;
                return true;
            }
            return false;
        }

        private float elapsed1;

        public bool cycleTimer(float delay, GameTime gameTime)
        {
            _elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_elapsed >= delay)
            {
                _elapsed = 0;
                return true;
            }
            return false;
        }
    }
}
