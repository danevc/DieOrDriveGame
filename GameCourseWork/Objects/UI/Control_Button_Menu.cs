using GameCourseWork.Controllers;
using GameCourseWork.Core;
using GameCourseWork.MonoHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.Objects.UI
{
    public delegate void GameObjectEventHandler();

    class Control_Button_Menu : Component
    {
        Timer1 t = new Timer1();
        Texture2D _texWASD;
        Texture2D _texARROWS;
        Texture2D _texPLAY;
        Texture2D _texSPACE;
        Texture2D _texEXIT;

        Rectangle _rectWASD;
        Rectangle _rectARROWS;
        Rectangle _rectPLAY;
        Rectangle _rectSPACE;
        Rectangle _rectEXIT;

        Color _colorWASD;
        Color _colorARROWS;
        Color _colorPLAY;
        Color _colorSPACE;
        Color _colorEXIT;

        public Control_Button_Menu()
        {
            Cursor.LeftButtonClick += Click;
        }

        protected void Click(Vector2 pos)
        {
            if (new Rectangle((int)pos.X, (int)pos.Y, 1, 1).Intersects(_rectWASD))
                Data.layout = Data.layouts.wasd;

            if (new Rectangle((int)pos.X, (int)pos.Y, 1, 1).Intersects(_rectARROWS))
                Data.layout = Data.layouts.arrows;

            if (new Rectangle((int)pos.X, (int)pos.Y, 1, 1).Intersects(_rectPLAY))
                Data.scene = Data.scenes.game;

            if (new Rectangle((int)pos.X, (int)pos.Y, 1, 1).Intersects(_rectEXIT))
                Data.Exit = true;

            if (new Rectangle((int)pos.X, (int)pos.Y, 1, 1).Intersects(_rectSPACE))
            {
                if(!Data.isMenuShooting)
                    Data.isMenuShooting = true;
                else
                    Data.isMenuShooting = false;
            }
            
        }

        internal override void LoadContent(ContentManager Content)
        {
            _texWASD = Content.Load<Texture2D>("WASD_tex_button");
            _texARROWS = Content.Load<Texture2D>("ARROWS_tex_button");
            _texPLAY = Content.Load<Texture2D>("play_button_tex");
            _texSPACE = Content.Load<Texture2D>("space_button_tex");
            _texEXIT = Content.Load<Texture2D>("exit_button_tex");
        }

        internal override void Update(GameTime gameTime)
        {
            _rectWASD = new Rectangle(22, 257, _texWASD.Width, _texWASD.Height);
            _rectARROWS = new Rectangle(272, 257, _texWASD.Width, _texWASD.Height);
            _rectPLAY = new Rectangle(109, 480, _texPLAY.Width, _texPLAY.Height);
            _rectSPACE = new Rectangle(184, 400, _texSPACE.Width, _texSPACE.Height);
            _rectEXIT = new Rectangle(340, 740, _texEXIT.Width/2, _texEXIT.Height/2);

            if(Data.layout == Data.layouts.wasd)
                _colorWASD = Color.Gold;
            else
                _colorWASD = Color.White;

            if (Data.layout == Data.layouts.arrows)
                _colorARROWS = Color.Gold;
            else
                _colorARROWS = Color.White;

            if (Data.isMenuShooting)
                _colorSPACE = Color.Gold;
            else
                _colorSPACE = Color.White;

            if (ManagerCollision.isCollisPLAYbutton(_rectPLAY))
                _colorPLAY = Color.Peru;
            else
                _colorPLAY = Color.LightGray;

            if (ManagerCollision.isCollisPLAYbutton(_rectEXIT))
                _colorEXIT = Color.Gray;
            else
                _colorEXIT = Color.Plum;
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texWASD,_rectWASD,_colorWASD);
            spriteBatch.Draw(_texARROWS, _rectARROWS, _colorARROWS);
            spriteBatch.Draw(_texPLAY, _rectPLAY, _colorPLAY);
            spriteBatch.Draw(_texSPACE,_rectSPACE,_colorSPACE);
            spriteBatch.Draw(_texEXIT, _rectEXIT, _colorEXIT);
        }
    }
}
