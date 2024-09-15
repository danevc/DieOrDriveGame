using GameCourseWork.Animacions;
using GameCourseWork.Core;
using GameCourseWork.MonoHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.Objects
{
    class Coin : Component
    {
        protected int _qObst = 3;

        public Vector2[] _pos;
        protected Texture2D[] _tex;
        protected Rectangle[] _sourceRect;
        protected Rectangle[] _posRect;

        public Coin()
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

        protected Rectangle AnimacionCoin(Rectangle Rect, Texture2D tex, GameTime gameTime)
        {
            int W = tex.Width / 6;
            int H = tex.Height;
            int i = gameTime.TotalGameTime.Milliseconds % 90;
            switch (i)
            {
                case 0:
                    Rect = new Rectangle(W * (i / 15), 0, W, H);
                    break;
                case 15:
                    Rect = new Rectangle(W * (i / 15), 0, W, H);
                    break;
                case 30:
                    Rect = new Rectangle(W * (i / 15), 0, W, H);
                    break;
                case 45:
                    Rect = new Rectangle(W * (i / 15), 0, W, H);
                    break;
                case 60:
                    Rect = new Rectangle(W * (i / 15), 0, W, H);
                    break;
                case 75:
                    Rect = new Rectangle(W * (i / 15), 0, W, H);
                    break;
            }
            return Rect;
        } 
        
        internal override void LoadContent(ContentManager Content)
        {
            for (int i = 0; i < _qObst; i++)
            {
                _tex[i] = Content.Load<Texture2D>("coin_tex_sprite");
            }
        }

        internal override void Update(GameTime gameTime)
        {
            for (int i = 0; i < _qObst; i++)
            {
                _pos[i] += Data.Velocity;
                if (_pos[i].Y > Data.ScreenH + _tex[0].Height)
                    _pos[i] = RandomSet.RandomSetting(_pos[i], -300);

                _posRect[i] = new Rectangle((int)_pos[i].X - 20, (int)_pos[i].Y, _tex[0].Width / 6, _tex[0].Height);
                _sourceRect[i] = new Rectangle(_tex[i].Width / 6 * Animacion.Anim(250, 6, gameTime), 0, _tex[i].Width / 6, _tex[i].Height);

                if (ManagerCollision.isCollisionCoin(_posRect[i]))
                    _pos[i] = RandomSet.RandomSetting(_pos[i], -300);
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
                    new Vector2(0,0),
                    SpriteEffects.None,
                    1);
            }
        }
    }
}
