using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Gruppe8Eksamensprojekt2019
{
    abstract class MoveableObject : GameObject
    {
        protected bool isCollidingMO;


        protected abstract void Push();
    }
}
