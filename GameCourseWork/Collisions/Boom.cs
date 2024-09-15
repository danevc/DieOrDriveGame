using GameCourseWork.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.Collisions
{
    class Boom : Component
    {
        protected static Texture2D _texBoom;
        protected static Rectangle _rect;
        protected Rectangle sourceRect;
        protected static bool _off;
        protected static Color _color;

        internal override void LoadContent(ContentManager Content)
        {
            _texBoom = Content.Load<Texture2D>("crash_tex");
        }

        protected void AnimacionBoom(GameTime gameTime)
        {
            int i = gameTime.TotalGameTime.Milliseconds % 8;
            if (i == 0)
            {
                sourceRect = new Rectangle(0, 0, _texBoom.Width / 3, _texBoom.Height);
            }
            if (i == 3)
            {
                sourceRect = new Rectangle(_texBoom.Width / 3, 0, _texBoom.Width / 3, _texBoom.Height);
            }
            if (i == 6)
            {
                sourceRect = new Rectangle(_texBoom.Width / 3 * 2, 0, _texBoom.Width / 3, _texBoom.Height);
            }
            if (i > 6)
                _off = false;
        }

        internal override void Update(GameTime gameTime)
        {
            if (_off)
                AnimacionBoom(gameTime);
        }

        public static void Position(Vector2 pos, Color color)
        {
            _off = true;
            _color = color;
            _rect = new Rectangle((int)pos.X, (int)pos.Y,_texBoom.Width/3,_texBoom.Height);
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            if(_off)
                spriteBatch.Draw(_texBoom, _rect, sourceRect, _color);
        }
    }
}
