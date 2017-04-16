using System;

namespace Gravity
{
    struct Vector2
    {
        public static Vector2 zero = new Vector2(0,0);

        private double _x;
        private bool _recalculateMagnitude;

        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                _recalculateMagnitude = true;
            }
        }

        private double _y;

        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
                _recalculateMagnitude = true;
            }
        }

        private double _magnitude;

        public double Magnitude
        {
            get
            {
                RecalculateMagnitude();
                return _magnitude;
            }
        }

        public Vector2(double x, double y)
        {
            _x = x;
            _y = y;
            _magnitude = 0;
            _recalculateMagnitude = true;
            RecalculateMagnitude();
        }

        private void RecalculateMagnitude()
        {
            if (_recalculateMagnitude)
            {
                _magnitude = Math.Sqrt(_x * _x + _y * _y);
            }
            _recalculateMagnitude = false;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        public static Vector2 operator *(Vector2 a, double b)
        {
            return new Vector2(a.X*b,a.Y*b);
        }

        public static Vector2 operator *(double b, Vector2 a)
        {
            return new Vector2(a.X * b, a.Y * b);
        }

        public static Vector2 operator /(Vector2 a, double b)
        {
            return new Vector2(a.X / b, a.Y / b);
        }

        public static Vector2 operator /(double b, Vector2 a)
        {
            return new Vector2(a.X / b, a.Y / b);
        }
    }
}
