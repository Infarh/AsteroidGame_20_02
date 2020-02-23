using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects.Interfaces
{
    public interface ICollision
    {
        Rectangle Rect { get; }

        bool CheckCollision(ICollision obj);
    }
}
