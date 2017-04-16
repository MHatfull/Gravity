using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Gravity
{
    class Planet : ITickable
    {
        public float Mass { get; }
        public Vector2 Position { get; private set; }
        public Vector2 Force { set; get; }
        public Vector2 Velocity { get; private set; }
        public Ellipse Circle = new Ellipse();
        private Canvas _canvas;

        public Planet(Vector2 position, Vector2 v0, float mass, Canvas canvas)
        {
            _canvas = canvas;
            Mass = mass;
            Position = position;
            Velocity = v0;
            Force = Vector2.zero;
            Circle.Width = 20;
            Circle.Height = 20;
            Circle.Stroke = new SolidColorBrush(Colors.Red);
        }

        public void Tick(float deltaTime)
        {
            Vector2 a = Force / Mass;
            Velocity += a * deltaTime;
            Position += Velocity * deltaTime;
            Circle.Margin = new Thickness((Position.X * _canvas.Height)-Circle.Width/2f, (Position.Y * _canvas.Height) -Circle.Height/2f, 0, 0);
        }
    }
}
