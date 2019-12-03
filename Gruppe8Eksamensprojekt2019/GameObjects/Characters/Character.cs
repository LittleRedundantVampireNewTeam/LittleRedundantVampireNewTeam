using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
    enum AbilityType { Sunblock, Fire, Ice };

    abstract class Character : GameObject
    {
        protected int health;
        protected int damage;
        protected string name;


        protected virtual void UpdateHealth(int health, int amount)
        {

        }

        protected virtual void Attack()
        {

        }

        protected virtual void UseAbility(AbilityType ability)
        {

        }

        protected virtual void Speak()
        {

        }
    }
}
