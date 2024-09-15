using GameCourseWork.MonoHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameCourseWork.Controllers
{
    public delegate void MouseEventHandler(Vector2 position);

    class Cursor
    {
        static public Texture2D _cursorTex { get; set; }

        static public MouseState _mouseCurrentState;
        static public MouseState _mouseStatePrevious;

        static public Rectangle _mouseCurrentPosition;
        static public Vector2 _mousePosition;

        public static event MouseEventHandler LeftButtonClick;

        static public void Update()
        {
            _mouseStatePrevious = _mouseCurrentState;
            _mouseCurrentState = Mouse.GetState();

            if (_mouseCurrentState.LeftButton == ButtonState.Released)
            {
                if (_mouseStatePrevious.LeftButton == ButtonState.Pressed)
                {
                    LeftButtonClick?.Invoke(_mousePosition);
                }
            }

            _mousePosition = new Vector2(_mouseCurrentState.X, _mouseCurrentState.Y);
            _mouseCurrentPosition = new Rectangle(_mouseCurrentState.X, _mouseCurrentState.Y, _cursorTex.Width/5, _cursorTex.Height/5);

            ManagerCollision.GetRectMouse(new Rectangle(_mouseCurrentState.X, _mouseCurrentState.Y, 1, 1));
        }

        static public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_cursorTex, _mouseCurrentPosition, Color.White);
        }
    }
}
