using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.MonoHelper
{
    class PrintText
    {
        static public SpriteFont _font;
        static public SpriteFont _fontBig;

        static private Vector2 centr(string s)
        {
            Vector2 size = _fontBig.MeasureString(s);
            Vector2 center = new Vector2(size.X/2,size.Y/2);
            return center;
        }

        static public void Draw(SpriteBatch spriteBatch, string text, Vector2 pos, Color color, float scale)
        {
            spriteBatch.DrawString(_font, text, pos, color, 0, new Vector2(0,0), scale, SpriteEffects.None, 1);
        }

        static public void DrawBig(SpriteBatch spriteBatch, string text, Vector2 pos, Color color, float scale)
        {
            spriteBatch.DrawString(_fontBig, text, pos, color, 0, centr(text), scale, SpriteEffects.None, 1);
        }

    }
}
