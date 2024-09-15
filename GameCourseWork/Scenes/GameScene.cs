using GameCourseWork.Collisions;
using GameCourseWork.Core;
using GameCourseWork.MonoHelper;
using GameCourseWork.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameCourseWork.Scenes
{
    class GameScene : Component
    {
        Fuel f = new Fuel();
        ManagerBullet bullet = new ManagerBullet();
        Road _road = new Road();
        MyCar _car = new MyCar();
        ObstBarrier _barrier = new ObstBarrier();
        Coin coin = new Coin();
        Boom boom = new Boom();
        Dashboard db = new Dashboard();
        private int i = Data.Score;

        internal override void LoadContent(ContentManager Content)
        {
            _road.LoadContent(Content);
            _barrier.LoadContent(Content);
            coin.LoadContent(Content);
            boom.LoadContent(Content);
            _car.LoadContent(Content);
            bullet.LoadContent(Content);
            db.LoadContent(Content);
            f.LoadContent(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Data.scene = Data.scenes.pause;
            _road.Update(gameTime);
            _car.Update(gameTime);
            _barrier.Update(gameTime);
            coin.Update(gameTime);
            boom.Update(gameTime);
            bullet.Update(gameTime);
            db.Update(gameTime);
            f.Update(gameTime);
            Controllers.KeyboardControl.ShopBuy(gameTime);

            if (Data.LevelFuel < -24)
                Data.Velocity.Y -= 0.1f;    

            if(Data.Velocity.Y < 0)
                Data.scene = Data.scenes.gameover;

            if (Data.Score > Data.Record)
                Data.Record = Data.Score;

            if (Data.Velocity.Y < 11)
                Data.Velocity.Y += 0.002f;

            i++;
            if (i % 200 == 0)
                Data.Score += 1;
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            _road.Draw(spriteBatch);
            coin.Draw(spriteBatch);
            f.Draw(spriteBatch);
            _barrier.Draw(spriteBatch);
            boom.Draw(spriteBatch);
            _car.Draw(spriteBatch);
            bullet.Draw(spriteBatch);
            db.Draw(spriteBatch);

            PrintText.Draw(spriteBatch, $"{Data.Coins}", new Vector2(216, 52), Color.Gold, 0.7f);
            PrintText.Draw(spriteBatch, $"{Data.Score}", new Vector2(370, 80), Color.Gold, 0.7f);
            PrintText.Draw(spriteBatch, $"{Data.Bullets}", new Vector2(216, 90), Color.Gold, 0.7f);
        }
    }
}
