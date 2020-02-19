using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class SpaceShip
    {
        private Vector2D _Position = new Vector2D(5, 7);

        public Vector2D Position { get => _Position; set => _Position = value; }

        public SpaceShip()
        {

        }

        public SpaceShip(Vector2D Position)
        {
            _Position = Position;
        }
    }

    struct Vector2D
    {
        private double _X;
        //private double _Y;

        public double X { get { return _X; } set { _X = value; } }
        //public double Y { get => _Y; set => _Y = value; }
        public double Y { get; /*private*/ set; }

        public double Length => Math.Sqrt(X * X + Y * Y);

        public Vector2D(double X, double Y)
        {
            _X = X;
            this.Y = Y;
        }


    }
}
