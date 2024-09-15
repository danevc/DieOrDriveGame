using GameCourseWork.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.Objects
{
    class Dashboard : Component
    {
        Texture2D _texDown;
        Texture2D _texUp;
        Texture2D _texLevelOfFuel;
        protected static int b = 0;
        Vector2 _pos;

        internal override void LoadContent(ContentManager Content)
        {
            _texDown = Content.Load<Texture2D>("UPpanel_tex");
            _texUp = Content.Load<Texture2D>("DOWNpanel_tex");
            _texLevelOfFuel = Content.Load<Texture2D>("level_fuel_tex");
        }

        internal override void Update(GameTime gameTime)
        {
            Data.LevelFuel -= 0.06f;
        }

        public static void beforeFuel(int d)
        {
            if (d < 0)
                d = 0;
            b = d;
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            _pos = new Vector2(Data.LevelFuel, 91);
            spriteBatch.Draw(_texLevelOfFuel, _pos, Color.White);
            spriteBatch.Draw(_texDown, new Vector2(0, 46), Color.White);
            spriteBatch.Draw(_texUp, new Vector2(0, 0), Color.White);
            MonoHelper.PrintText.Draw(spriteBatch, $"{b}", new Vector2(30, 100), Color.OrangeRed, 0.4f);
        }
    }
}
