using GameCourseWork.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.Scenes
{
    class GameStateManager : Component
    {
        private GameScene gs = new GameScene();
        private MenuScene ms = new MenuScene();
        private GameOver go = new GameOver();
        private PauseScene ps = new PauseScene();


        internal override void LoadContent(ContentManager Content)
        {
            ms.LoadContent(Content);
            gs.LoadContent(Content);
            go.LoadContent(Content);
            ps.LoadContent(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            switch (Data.scene)
            {
                case Data.scenes.menu:
                    ms.Update(gameTime);
                    break;
                case Data.scenes.game:
                    gs.Update(gameTime);
                    break;
                case Data.scenes.pause:
                    ps.Update(gameTime);
                    break;
                case Data.scenes.gameover:
                    go.Update(gameTime);
                    break;
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            switch (Data.scene)
            {
                case Data.scenes.menu:
                    ms.Draw(spriteBatch);
                    break;
                case Data.scenes.game:
                    gs.Draw(spriteBatch);
                    break;
                case Data.scenes.pause:
                    ps.Draw(spriteBatch);
                    break;
                case Data.scenes.gameover:
                    go.Draw(spriteBatch);
                    break;
            }
        }
    }
}
