using Microsoft.Xna.Framework;

namespace GameCourseWork.Animacions
{
    class Animacion
    {
        private static float elapsed;
        private static int frames = 0;

        public static int Anim(float delay, int shots, GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= delay)
            {
                if (frames >= shots - 1)
                    frames = 0;
                else
                    frames++;
                elapsed = 0;
            }
            return frames;
        }
    }
}
