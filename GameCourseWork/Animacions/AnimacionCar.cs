using GameCourseWork.Core;
using Microsoft.Xna.Framework;

namespace GameCourseWork.Animacions
{
    class AnimacionCar
    {
        static float _rotation = 0;
        static bool _direction = true;
        static int first = -62;

        static public Vector2 TurnRight(Vector2 pos)
        {
            switch (Data.condition)
            {
                case 1:
                    pos.X = first + Data.distBtwRoads * 2;
                    Data.condition = 2;
                    break;
                case 2:
                    pos.X = first + Data.distBtwRoads * 3;
                    Data.condition = 3;
                    break;
                case 3:
                    pos.X = first + Data.distBtwRoads * 4;
                    Data.condition = 4;
                    break;
            }
            _rotation = 0.12f;

            return pos;
        }
        
        static public Vector2 TurnLeft(Vector2 pos)
        {
            switch (Data.condition)
            {
                case 2:
                    pos.X = first + Data.distBtwRoads;
                    Data.condition = 1;
                    break;
                case 3:
                    pos.X = first + Data.distBtwRoads * 2;
                    Data.condition = 2;
                    break;
                case 4:
                    pos.X = first + Data.distBtwRoads * 3;
                    Data.condition = 3;
                    break;
            }
            _rotation = -0.12f;

            return pos;
        }

        static public float Drive()
        {
            if (_direction)
                _rotation += 0.005f;
            if (!_direction)
                _rotation -= 0.005f;
            if (_rotation < -0.02)
                _direction = true;
            if (_rotation > 0.02)
                _direction = false;

            return _rotation;
        }

    }
}
