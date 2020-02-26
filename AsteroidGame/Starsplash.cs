using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    class StarSplash : VisualObject
    {
        public StarSplash(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
        {

        }
        public override void Draw(Graphics g)
        {

            g.DrawLine(Pens.LightCyan,
             _Position.X, _Position.Y,
             _Position.X + _Size.Width, _Position.Y + _Size.Height);

            g.DrawLine(Pens.LightCyan,
                _Position.X + _Size.Width, _Position.Y,
                _Position.X, _Position.Y + _Size.Height);

            g.DrawLine(Pens.Red,
                _Position.X, _Position.Y + _Size.Height / 2,
                _Position.X + _Size.Width, _Position.Y + _Size.Height/2);


        }

        public override void Update()
        {
            if (_Position.X < 1200 && _Position.X > 0)
                _Position.X += _Direction.X;
            else
            {
                _Position.X = 600;
                _Position.Y = 450;

            }
            if (_Position.Y < 900 && _Position.Y > 0)
                _Position.Y += _Direction.Y;
            else
            {
                _Position.X = 600;
                _Position.Y = 450;

            }

        }
    }
}