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
    class MenuScene : Component
    {
        MenuAnimShooting shoot = new MenuAnimShooting();
        BackGroundMenu bg = new BackGroundMenu();
        Control_Button_Menu cbm = new Control_Button_Menu();

        internal override void LoadContent(ContentManager Content)
        {
            Cursor._cursorTex = Content.Load<Texture2D>("cursor_tex");
            shoot.LoadContent(Content);
            bg.LoadContent(Content);
            cbm.LoadContent(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            shoot.Update(gameTime);
            bg.Update(gameTime);
            cbm.Update(gameTime);
            
            Cursor.Update();

            NewGame.newGame();
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            bg.Draw(spriteBatch);
            shoot.Draw(spriteBatch);
            cbm.Draw(spriteBatch);

            PrintText.Draw(spriteBatch,$"{Data.Record}", new Vector2(170,728), Color.Plum, 0.8f);

            Cursor.Draw(spriteBatch);
        }
    }
}
