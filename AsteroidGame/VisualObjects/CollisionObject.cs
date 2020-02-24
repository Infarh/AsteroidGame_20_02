using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsteroidGame.VisualObjects.Interfaces;

namespace AsteroidGame.VisualObjects
{
    public abstract class CollisionObject : VisualObject, ICollision
    {
        protected CollisionObject(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
        {
        }

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
   
    }

}
