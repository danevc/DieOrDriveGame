using GameCourseWork.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.Objects
{
    class BackGroundMenu : Component
    {
        private Texture2D _texShooting;

        internal override void LoadContent(ContentManager Content)
        {
            _texShooting = Content.Load<Texture2D>("MenuBack_tex");
        }

        internal override void Update(GameTime gameTime)
        {
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texShooting, new Vector2(0,0), Color.LightGray);
        }
    }
}
