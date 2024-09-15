using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.GameEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMonoGame01.Controllers
{
    public class ControllerKeyboardSimple : ControllerKeyboardBase
    {

        public ControllerKeyboardSimple(Game game):base(game)
        {
            _layout = new KeyboardLayoutArrows();
        }

        public override void Update(GameTime gameTime)
        {
            if (_attached == null) return;

            // 1) состояние клавиатуры считаем методом предка
            base.Update(gameTime);

            // 2) возьмём список нажатых клавиш
            Keys[] keys = _ksCurrent.GetPressedKeys();
            // 3) циклом смотрим нажатые клавиши и
            // находим для каждой - действие кот записано в Раскладке
            Vector2 delta = new Vector2(0, 0);
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
                            delta.X = -1;
                            break;
                        case EnumAction.ActionRight:
                            delta.X = 1;
                            break;
                        case EnumAction.ActionForward:
                            delta.Y = -1;
                            break;
                        case EnumAction.ActionBackward:
                            delta.Y = 1;
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
