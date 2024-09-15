using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.GameEnums;

namespace ProjectMonoGame01.Controllers
{
    class ControllerKeyboardAdvanced : ControllerKeyboardBase
    {
        public ControllerKeyboardAdvanced(Game game) : base(game)
        {
            _layout = new KeyboardLayoutArrows();
        }

        public override void Update(GameTime gameTime)
        {
            if (_attached == null) return;

            Vector2 delta = new Vector2(0, 0);
            float distance = 2.0f;
            float rotation = 1.0f;
            // 1) состояние клавиатуры считаем методом предка
            base.Update(gameTime);
            // 2) возьмём список нажатых клавиш
            Keys[] keys = _ksCurrent.GetPressedKeys();
            // 3) циклом смотрим нажатые клавиши и
            // находим для каждой - действие кот записано в Раскладке
            foreach (var attached in _attached)
            {
                foreach (var k in keys)
                {
                    // ищем действие для клавиши в раскладке
                    EnumAction action = _layout[k];
                    switch (action)
                    {
                        case EnumAction.None:
                            break;
                        case EnumAction.ActionLeft:
                            foreach (var item in _attached)
                            {
                                item.RotateDegrees(-rotation);
                            }

                            break;
                        case EnumAction.ActionRight:
                            foreach (var item in _attached)
                            {
                                item.RotateDegrees(rotation);
                            }
                            break;
                        case EnumAction.ActionForward:
                            {
                                float alpha = _attached[0].Direction;
                                delta.X = (float)(distance * Math.Cos(alpha));
                                delta.Y = (float)(distance * Math.Sin(alpha));
                            }
                            break;
                        case EnumAction.ActionBackward:
                            {
                                float alpha = _attached[0].Direction;
                                delta.X = -(float)(distance * Math.Cos(alpha));
                                delta.Y = -(float)(distance * Math.Sin(alpha));
                            }
                            break;
                        case EnumAction.ActionJump:
                            break;
                        case EnumAction.ActionAttack:
                            ActionAttack(k);
                            break;
                    }
                }
                attached.Move(delta);
            }
            
        }
    }
}
