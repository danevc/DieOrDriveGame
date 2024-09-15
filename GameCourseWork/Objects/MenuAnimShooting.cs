using GameCourseWork.Animacions;
using GameCourseWork.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.Objects
{
    class MenuAnimShooting : Component
    {
        private Texture2D _texShooting;
        private Rectangle _sourceRectShooting;
        private Rectangle _posRect;

        internal override void LoadContent(ContentManager Content)
        {
            _texShooting = Content.Load<Texture2D>("menu_tex_sprite");
        }

        internal override void Update(GameTime gameTime)
        {
            _sourceRectShooting = new Rectangle(_texShooting.Width / 8 * Animacion.Anim(100, 8, gameTime), 0, _texShooting.Width / 8, _texShooting.Height);
            _posRect = new Rectangle(0, 0, _texShooting.Width / 8, _texShooting.Height);
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            if(Data.isMenuShooting)
                spriteBatch.Draw(_texShooting, _posRect, _sourceRectShooting, Color.White);
            else
                spriteBatch.Draw(_texShooting, _posRect, new Rectangle(0,0, _texShooting.Width / 8, _texShooting.Height), Color.White);
        }
    }
}
