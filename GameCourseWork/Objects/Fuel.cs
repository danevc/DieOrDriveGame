using GameCourseWork.Core;
using GameCourseWork.MonoHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace GameCourseWork.Objects
{
    class Fuel : Component
    {
        public int _qObst = 10; // количество препятствий
        ManagerCollision mc = new ManagerCollision();

        public Vector2 _pos;
        protected Texture2D _tex;
        protected Rectangle _sourceRect;
        protected Rectangle _posRect;
        protected Vector2 _origin;

        public Fuel()
        {
            _pos = RandomSet.RandomSetting(_pos, -500);
        }

        internal override void LoadContent(ContentManager Content)
        {
            _tex = Content.Load<Texture2D>("fuel_tex");
            _origin.X = _tex.Width / 2;
            _origin.Y = _tex.Height / 2;
        }

        internal override void Update(GameTime gameTime)
        {
            _pos += Data.Velocity;
            if (_pos.Y > Data.ScreenH + _tex.Height)
            {
                _pos = RandomSet.RandomSetting(_pos, -500);
            }
            _posRect = new Rectangle((int)_pos.X, (int)_pos.Y, _tex.Width, _tex.Height);
            _sourceRect = new Rectangle(0, 0, _tex.Width, _tex.Height);

            if (mc.isCollisionFuel(_posRect, gameTime))
            {
                _pos = RandomSet.RandomSetting(_pos, -500);
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _tex,
                _posRect,
                _sourceRect,
                Color.White,
                0,
                _origin,
                SpriteEffects.None,
                1);
            Dashboard.beforeFuel(-(int)_pos.Y / 300);
        }
    }
}
