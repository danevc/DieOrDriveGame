using GameCourseWork.Controllers;
using GameCourseWork.Core;
using GameCourseWork.MonoHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameCourseWork.Scenes
{
    class GameOver : Component
    {
        Texture2D _texBack;
        Texture2D _texBToMenu;
        Texture2D _texGameOver;

        Rectangle _rectBToMenu;

        Color _colorBToMenu;

        protected void Click(Vector2 pos)
        {
            if (new Rectangle((int)pos.X, (int)pos.Y, 1, 1).Intersects(_rectBToMenu))
                Data.scene = Data.scenes.menu;
        }

        public GameOver()
        {
            Cursor.LeftButtonClick += Click;
        }

        internal override void LoadContent(ContentManager Content)
        {
            _texBToMenu = Content.Load<Texture2D>("pButtonToMenu");
            _texBack = Content.Load<Texture2D>("MenuBack_tex");
            _texGameOver = Content.Load<Texture2D>("gameOver_tex");
        }

        internal override void Update(GameTime gameTime)
        {
            _rectBToMenu = new Rectangle(100, 651, _texBToMenu.Width, _texBToMenu.Height);
            if (ManagerCollision.isCollisPLAYbutton(_rectBToMenu))
                _colorBToMenu = Color.LightGray;
            else
                _colorBToMenu = Color.White;

            Cursor.Update();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Data.scene = Data.scenes.menu;
            }
            ManagerCollision._timerFix = false;
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texBack, new Vector2(0,0),Color.White);
            spriteBatch.Draw(_texBToMenu, _rectBToMenu, _colorBToMenu);
            spriteBatch.Draw(_texGameOver, new Vector2(65, 424), Color.White);
            PrintText.DrawBig(spriteBatch, $"{Data.Score}", new Vector2(250, 200), Color.Plum, 1);
            PrintText.Draw(spriteBatch, $"{Data.Record}", new Vector2(170, 728), Color.Plum, 0.8f);

            Cursor.Draw(spriteBatch);
        }
    }
}
