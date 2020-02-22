using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    class Line : VisualObject
    {
        public Line(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
        {
       
        }
        public override void Draw(Graphics g)
        {
            g.DrawLine(Pens.White,
                _Position.X, _Position.Y,
                _Position.X + _Size.Width, _Position.Y + _Size.Height);

          
        }

        public override void Update()
        {
            if (_Position.X < 800 && _Position.X > 0)
                _Position.X += _Direction.X;
            else
            {
                _Position.X = 400;
                _Position.Y = 300;

            }
            if (_Position.Y < 600 && _Position.Y>0)
                _Position.Y += _Direction.Y;
            else
            {
                _Position.X = 400;
                _Position.Y = 300;

            }

        }
    }
}
