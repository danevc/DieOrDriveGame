using GameCourseWork.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.Objects
{
    class Road : Component
    {
        protected Texture2D _texRoad1;
        protected Texture2D _texRoad2;
        protected Vector2 _posRoad1 = new Vector2(0,0);
        protected Vector2 _posRoad2 = new Vector2(0, -720);

        internal override void LoadContent(ContentManager Content)
        {
            _texRoad1 = Content.Load<Texture2D>("road_tex");
            _texRoad2 = Content.Load<Texture2D>("road_tex");
        }

        internal override void Update(GameTime gameTime)
        {
            _posRoad1 += Data.Velocity;
            _posRoad2 += Data.Velocity;
            if (_posRoad1.Y > 720)
                _posRoad1 = new Vector2(0, -720);
            if (_posRoad2.Y > 720)
                _posRoad2 = new Vector2(0, -720);
        }
        
        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texRoad2, _posRoad2, Color.White);
            spriteBatch.Draw(_texRoad1, _posRoad1, Color.White);
        }
    }
}
