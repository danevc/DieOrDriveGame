using GameCourseWork.Collisions;
using GameCourseWork.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.MonoHelper
{
    class ManagerCollision
    {
        Timer1 t = new Timer1();
        protected static Rectangle _carRect;
        protected static Rectangle _barrierRect;
        protected static Rectangle _coinRect;
        protected static Rectangle _mouseRect;
        protected static Rectangle _bulletRect;
        protected static double i = 0;
        public static bool _timerFix = false;
        protected static bool _plusOneCoin = true;
        protected static bool _isCollBandB = false;

        public static void GetRectCar(Rectangle Rect)
        {
            _carRect = new Rectangle(Rect.X, Rect.Y - 72, Rect.Width, Rect.Height + 40);
        }

        public static void GetRectMouse(Rectangle Rect)
        {
            _mouseRect = Rect;
        }

        public static void GetRectBarrier(Rectangle Rect)
        {
            _barrierRect = new Rectangle(Rect.X - 59, Rect.Y + 15, Rect.Width, Rect.Height - 40);
        }

        public static void GetRectBullet(Vector2 Pos)
        {
            _bulletRect = new Rectangle((int)Pos.X, (int)Pos.Y, 7, 7);
        }

        public static bool isCollisPLAYbutton(Rectangle Rect)
        {
            return _mouseRect.Intersects(Rect);
        }

        public bool isCollisionBarrier(GameTime gameTime)
        {
            if (_carRect.Intersects(_barrierRect) && Data.improve == Data.improvements.simple)
            {
                Vector2 pos = new Vector2(_carRect.X - 50, _carRect.Y - 48);
                Boom.Position(pos, Color.Red);
                _timerFix = true;
            }
            if (_timerFix)
            {
                if (t.cycleTimer(3500, gameTime))
                {
                    Data.scene = Data.scenes.gameover;
                }
            }
            if (_barrierRect.Intersects(_bulletRect))
            {
                _isCollBandB = true;
                return true;
            }
            else
            {
                _isCollBandB = false;
            }

            return _timerFix;
        }

        public static bool isCollisionCoin(Rectangle Rect)
        {
            _coinRect = new Rectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height);
            Vector2 pos;
            if (_carRect.Intersects(_coinRect))
            {
                pos = new Vector2(_carRect.X - 50, _carRect.Y - 48);
                Boom.Position(pos, Color.Yellow);
                if (_plusOneCoin)
                {
                    Data.Coins++;
                    _plusOneCoin = false;
                }
                return true;
            }
            _plusOneCoin = true;
            return false;
        }

        public bool isCollisionFuel(Rectangle Rect, GameTime gameTime)
        {
            _barrierRect = new Rectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height - 40);

            if (_carRect.Intersects(_barrierRect))
            {
                Data.LevelFuel = 69;
                return true;
            }
            return false;
        }

        public static bool isCollisionBullet()
        {
            
            if (_isCollBandB)
            {
                _isCollBandB = false;
                return true;
            }
            return false;
        }
        
    }
}
