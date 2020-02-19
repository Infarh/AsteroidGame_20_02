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
}
