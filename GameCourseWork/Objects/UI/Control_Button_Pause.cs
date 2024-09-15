using GameCourseWork.Controllers;
using GameCourseWork.Core;
using GameCourseWork.MonoHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.Objects.UI
{

    class Control_Button_Pause : Component
    {
        Texture2D _texBContinue;
        Texture2D _texEXIT;
        Texture2D _texBToMenu;

        Rectangle _rectBContinue;
        Rectangle _rectEXIT;
        Rectangle _rectBToMenu;

        Color _colorBContinue;
        Color _colorEXIT;
        Color _colorBToMenu;

        public Control_Button_Pause()
        {
            Cursor.LeftButtonClick += Click;
        }

        protected void Click(Vector2 pos)
        {
            if (new Rectangle((int)pos.X, (int)pos.Y, 1, 1).Intersects(_rectEXIT))
                Data.Exit = true;

            if (new Rectangle((int)pos.X, (int)pos.Y, 1, 1).Intersects(_rectBContinue))
                Data.scene= Data.scenes.game;

            if (new Rectangle((int)pos.X, (int)pos.Y, 1, 1).Intersects(_rectBToMenu))
                Data.scene= Data.scenes.menu;
        }

        internal override void LoadContent(ContentManager Content)
        {
            _texEXIT = Content.Load<Texture2D>("exit_button_tex");
            _texBContinue = Content.Load<Texture2D>("pButtonToContinue");
            _texBToMenu = Content.Load<Texture2D>("pButtonToMenu");
        }

        internal override void Update(GameTime gameTime)
        {
            _rectBContinue = new Rectangle(100, 578, _texBContinue.Width, _texBContinue.Height);
            _rectBToMenu = new Rectangle(100, 651, _texBContinue.Width, _texBContinue.Height);
            _rectEXIT = new Rectangle(340, 740, _texEXIT.Width / 2, _texEXIT.Height / 2);

            if (ManagerCollision.isCollisPLAYbutton(_rectEXIT))
                _colorEXIT = Color.Gray;
            else
                _colorEXIT = Color.Plum;

            if (ManagerCollision.isCollisPLAYbutton(_rectBContinue))
                _colorBContinue = Color.LightGray;
            else
                _colorBContinue = Color.White;

            if (ManagerCollision.isCollisPLAYbutton(_rectBToMenu))
                _colorBToMenu = Color.LightGray;
            else
                _colorBToMenu = Color.White;
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texBContinue, _rectBContinue, _colorBContinue);
            spriteBatch.Draw(_texBToMenu, _rectBToMenu, _colorBToMenu);
            spriteBatch.Draw(_texEXIT, _rectEXIT, _colorEXIT);
        }
    }
}

