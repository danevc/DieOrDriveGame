using GameCourseWork.MonoHelper;
using GameCourseWork.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.Core
{ 
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        GameStateManager _gameState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = Data.ScreenW;
            _graphics.PreferredBackBufferHeight = Data.ScreenH;
            _graphics.ApplyChanges();

            _gameState = new GameStateManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gameState.LoadContent(Content);
            PrintText._font = Content.Load<SpriteFont>("font1");
            PrintText._fontBig = Content.Load<SpriteFont>("BigFont");
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Data.Exit) Exit();

            _gameState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Orchid);

            _spriteBatch.Begin();
            _gameState.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
