using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameCourseWork.Objects
{
    class Bullet
    {
        public Texture2D _tex;
        public Vector2 _pos;
        public bool _isVisible = true;

        public Bullet(Texture2D texture)
        {
            _tex = texture;
        }
    }
}
