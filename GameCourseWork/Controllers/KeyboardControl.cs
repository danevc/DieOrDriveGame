using GameCourseWork.Animacions;
using GameCourseWork.Core;
using GameCourseWork.MonoHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameCourseWork.Controllers
{
    class KeyboardControl
    {
        static Timer1 time = new Timer1();
        
        protected static KeyboardState _ksPrevious;
        protected static KeyboardState _ksCurrent;

        protected static float elapsed;
        protected static int frames;

        protected static bool boolean = false;

        public static Vector2 SetObj(Vector2 pos)
        {
            switch (Data.layout)
            {
                case Data.layouts.wasd:
                    if (Keyboard.GetState().IsKeyDown(Keys.W) && pos.Y >= 300)
                    {
                        pos.Y -= 2.3f;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.S) && pos.Y <= 720)
                    {
                        pos.Y += 2.3f;
                    }
                    if (_ksCurrent.IsKeyDown(Keys.D) && _ksPrevious.IsKeyUp(Keys.D))
                    {
                        pos = AnimacionCar.TurnRight(pos);
                    }
                    if (_ksCurrent.IsKeyDown(Keys.A) && _ksPrevious.IsKeyUp(Keys.A))
                    {
                        pos = AnimacionCar.TurnLeft(pos);
                    }
                    break;
                case Data.layouts.arrows:
                    if (Keyboard.GetState().IsKeyDown(Keys.Up)&& pos.Y >= 300)
                    {
                        pos.Y -= 2.3f;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Down) && pos.Y <= 720)
                    {
                        pos.Y += 2.3f;
                    }
                    if (_ksCurrent.IsKeyDown(Keys.Right) && _ksPrevious.IsKeyUp(Keys.Right))
                    {
                        pos = AnimacionCar.TurnRight(pos);
                    }
                    if (_ksCurrent.IsKeyDown(Keys.Left) && _ksPrevious.IsKeyUp(Keys.Left))
                    {
                        pos = AnimacionCar.TurnLeft(pos);
                    }
                    break;
            }
            return pos;
        }

        public static void ShopBuy(GameTime gameTime)
        {
            _ksPrevious = _ksCurrent;
            _ksCurrent = Keyboard.GetState();
            if (_ksCurrent.IsKeyDown(Keys.Q) && _ksPrevious.IsKeyUp(Keys.Q))
            {
                if(Data.Coins >= 5)
                {
                    Data.Coins -= 5;
                    Data.Bullets++;
                }
            }
            if (_ksCurrent.IsKeyDown(Keys.E) && _ksPrevious.IsKeyUp(Keys.E))
            {
                boolean = true;
            }
            if (boolean)
            {
                if (Data.Coins >= 30)
                {
                    Data.Coins -= 30;
                    Data.improve = Data.improvements.destroyer;
                }

                if (time.timer(15000, gameTime))
                {
                    boolean = false;
                    Data.improve = Data.improvements.simple;
                }
            }
            if (_ksCurrent.IsKeyDown(Keys.F) && _ksPrevious.IsKeyUp(Keys.F))
            {
                if (Data.Coins >= 20)
                {
                    Data.Coins -= 20;
                    Data.LevelFuel = 69;
                }
            }



        }

        public static int timer(float delay, int shots, GameTime gameTime)
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
