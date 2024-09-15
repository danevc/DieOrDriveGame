using GameCourseWork.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameCourseWork.Animacions;
using GameCourseWork.Controllers;
using GameCourseWork.MonoHelper;

namespace GameCourseWork.Objects
{
    public delegate void Pos(Vector2 vect);
    class MyCar : Component
    {
        public static event Pos changedPos;
        protected Texture2D _texCar;
        public Vector2 _posCar = new Vector2(62, 720);
        protected float _rotation = 0;
        protected Vector2 _origin = new Vector2(34, 61);
        public Rectangle _sourceRectCar;
        public Rectangle _posRectCar;

        internal override void LoadContent(ContentManager Content)
        {
            _texCar = Content.Load<Texture2D>("car_tex");
            _origin = new Vector2(_texCar.Width / 2, _texCar.Height / 2);
        }

        internal override void Update(GameTime gameTime)
        {
            _posCar = KeyboardControl.SetObj(_posCar);
            _posRectCar = new Rectangle((int)_posCar.X, (int)_posCar.Y,_texCar.Width,_texCar.Height);
            _sourceRectCar = new Rectangle(0, 0, _texCar.Width, _texCar.Height);

            ManagerCollision.GetRectCar(_posRectCar);

            changedPos?.Invoke(_posCar);

            if (Data.isNewGame)
            {
                _posCar = new Vector2(62, 720);
                Data.isNewGame = false;
            }

            _rotation = AnimacionCar.Drive();
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _texCar,
                _posRectCar, 
                _sourceRectCar,
                Color.White, 
                _rotation, 
                _origin,
                SpriteEffects.None, 
                1);
        }
    
    }
}
