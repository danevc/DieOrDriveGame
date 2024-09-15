using GameCourseWork.Core;
using GameCourseWork.MonoHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GameCourseWork.Objects
{

    class ManagerBullet : Component
    {
        Timer1 time = new Timer1();
        ManagerCollision mc = new ManagerCollision();
        Texture2D _tex;
        Vector2 _pos;
        List<Bullet> _bullets = new List<Bullet>();
        KeyboardState _ksCurrent;
        KeyboardState _ksPrevious;

        public ManagerBullet()
        {
            MyCar.changedPos += changePos;
        }

        protected void changePos(Vector2 Pos)
        {
            _pos = Pos;
        }

        internal override void LoadContent(ContentManager Content)
        {
            _tex = Content.Load<Texture2D>("bullet_tex");
        }

        internal override void Update(GameTime gameTime)
        {
            _ksPrevious = _ksCurrent;
            _ksCurrent = Keyboard.GetState();
            if (_ksCurrent.IsKeyDown(Keys.Space) && _ksPrevious.IsKeyUp(Keys.Space) && Data.improve == Data.improvements.simple)
            {
                Shoot();
                if (Data.Bullets > 0)
                    Data.Bullets--;
            }
            if(Data.improve == Data.improvements.destroyer)
            {
                if (time.cycleTimer(200, gameTime))
                    Shoot();
            }

            foreach (var b in _bullets)
            {
                ManagerCollision.GetRectBullet(b._pos);

                b._pos.Y -= (int)Data.Velocity.Y + 4;
                if (b._pos.Y < 0 || ManagerCollision.isCollisionBullet())
                {
                    b._isVisible = false;
                }
            }
            for (int i = 0; i < _bullets.Count; i++)
            {
                if (!_bullets[i]._isVisible)
                {
                    _bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Shoot()
        {
            Bullet b = new Bullet(_tex);
            b._pos = new Vector2((int)_pos.X, (int)_pos.Y);
            b._isVisible = true;

            if (_bullets.Count < Data.Bullets + _bullets.Count)
            {
                _bullets.Add(b);
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var b in _bullets)
            {
                spriteBatch.Draw(b._tex, b._pos, Color.White);
            }
        }
    }
}
