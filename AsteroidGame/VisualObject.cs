using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    class VisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;

        public VisualObject(Point Position, Point Direction, Size Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }

        public virtual void Draw(Graphics g)
        {
            g.DrawEllipse(Pens.White,
                _Position.X, _Position.Y,
                _Size.Width, _Size.Width);
        }

        public virtual void Update()
        {
            _Position = new Point(
                _Position.X + _Direction.X,
                _Position.Y + _Direction.Y);

            if (_Position.X < 0)
                //_Direction.X *= -1;
                _Direction = new Point(-_Direction.X, _Direction.Y);
            if (_Position.Y < 0)
                _Direction = new Point(_Direction.X, -_Direction.Y);

            if(_Position.X > Game.Width)
                _Direction = new Point(-_Direction.X, _Direction.Y);
            if (_Position.Y > Game.Height)
                _Direction = new Point(_Direction.X, -_Direction.Y);
        }
    }
}
