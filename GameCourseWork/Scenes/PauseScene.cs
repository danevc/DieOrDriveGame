using GameCourseWork.Collisions;
using GameCourseWork.Controllers;
using GameCourseWork.Core;
using GameCourseWork.MonoHelper;
using GameCourseWork.Objects;
using GameCourseWork.Objects.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.Scenes
{
    class PauseScene : Component
    {
        ManagerBullet bullet = new ManagerBullet();
        Road _road = new Road();
        MyCar _car = new MyCar();
        ObstBarrier _barrier = new ObstBarrier();
        Coin coin = new Coin();
        Boom boom = new Boom();
        Dashboard db = new Dashboard();
        Texture2D _texPauseBack;
        Texture2D _texPause;
        Control_Button_Pause cbp = new Control_Button_Pause();

        internal override void LoadContent(ContentManager Content)
        {
            _road.LoadContent(Content);
            _barrier.LoadContent(Content);
            coin.LoadContent(Content);
            boom.LoadContent(Content);
            _car.LoadContent(Content);
            bullet.LoadContent(Content);
            db.LoadContent(Content);
            cbp.LoadContent(Content);
            _texPauseBack = Content.Load<Texture2D>("pauseBack_tex");
            _texPause = Content.Load<Texture2D>("Pause_tex");
            Cursor._cursorTex = Content.Load<Texture2D>("cursor_tex");
        }

        internal override void Update(GameTime gameTime)
        {
            cbp.Update(gameTime);
            Cursor.Update();
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            _road.Draw(spriteBatch);
            coin.Draw(spriteBatch);
            _barrier.Draw(spriteBatch);
            boom.Draw(spriteBatch);
            _car.Draw(spriteBatch);
            bullet.Draw(spriteBatch);
            db.Draw(spriteBatch);

            PrintText.Draw(spriteBatch, $"{Data.Coins}", new Vector2(216, 52), Color.Gold, 0.7f);
            PrintText.Draw(spriteBatch, $"{Data.Score}", new Vector2(370, 80), Color.Gold, 0.7f);
            PrintText.Draw(spriteBatch, $"{Data.Bullets}", new Vector2(216, 90), Color.Gold, 0.7f);
            
            spriteBatch.Draw(_texPauseBack, new Vector2(0, 0), Color.Gray * 0.8f);
            cbp.Draw(spriteBatch);
            spriteBatch.Draw(_texPause, new Vector2(53, 455), Color.White);
            Cursor.Draw(spriteBatch);

        }
    }
}
