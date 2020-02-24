using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public class EllipseObject : VisualObject
    {
        public EllipseObject(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(Pens.White, Rect);
       
        }
        public override void Update()
        {
            _Position = new Point(
                _Position.X + _Direction.X,
                _Position.Y + _Direction.Y);

            if (_Position.X < 0)
                //_Direction.X *= -1;
                _Direction = new Point(-_Direction.X, _Direction.Y);
            if (_Position.Y < 0)
                _Direction = new Point(_Direction.X, -_Direction.Y);

            if (_Position.X > Game.Width)
                _Direction = new Point(-_Direction.X, _Direction.Y);
            if (_Position.Y > Game.Height)
                _Direction = new Point(_Direction.X, -_Direction.Y);



        }

    }
}
