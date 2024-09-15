using GameCourseWork.Core;
using GameCourseWork.MonoHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace GameCourseWork.Objects
{
    class ObstBarrier : Component
    {
        public int _qObst = 10; // количество препятствий
        ManagerCollision mc = new ManagerCollision();

        public Vector2[] _pos;
        protected Texture2D[] _tex;
        protected Rectangle[] _sourceRect;
        protected Rectangle[] _posRect;
        protected Vector2 _origin;

        public ObstBarrier()
        {
            _pos = new Vector2[_qObst];
            _tex = new Texture2D[_qObst];
            _sourceRect = new Rectangle[_qObst];
            _posRect = new Rectangle[_qObst];
            for (int i = 0; i < _qObst; i++)
            {
                _pos[i] = RandomSet.RandomSetting(_pos[i], -300);
            }
        }

        internal override void LoadContent(ContentManager Content)
        {
            for (int i = 0; i < _qObst; i++)
            {
                _tex[i] = Content.Load<Texture2D>("barrier_tex");
            }
            _origin.X = _tex[0].Width / 2;
            _origin.Y = _tex[0].Height / 2;
        }
        
        internal override void Update(GameTime gameTime)
        {
            for (int i = 0; i < _qObst; i++)
            {
                _pos[i] += Data.Velocity;
                if (_pos[i].Y > Data.ScreenH + _tex[0].Height)
                {
                    _pos[i] = RandomSet.RandomSetting(_pos[i], -400);
                }
                _posRect[i] = new Rectangle((int)_pos[i].X, (int)_pos[i].Y, _tex[0].Width - 20, _tex[0].Height - 10);
                _sourceRect[i] = new Rectangle(0, 0, _tex[0].Width, _tex[0].Height);

                ManagerCollision.GetRectBarrier(_posRect[i]);

                if (mc.isCollisionBarrier(gameTime))
                {
                    _pos[i] = RandomSet.RandomSetting(_pos[i], -400);
                }
                
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _qObst; i++)
            {
                spriteBatch.Draw(
                    _tex[i],
                    _posRect[i],
                    _sourceRect[i],
                    Color.White,
                    0,
                    _origin,
                    SpriteEffects.None,
                    1);
            }
        }
    }
}
