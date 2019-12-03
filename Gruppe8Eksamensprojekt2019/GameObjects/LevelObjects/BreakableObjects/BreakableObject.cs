using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
    abstract class BreakableObject : GameObject
    {
        protected bool isBroken;

        protected abstract void Break();
    }
}
