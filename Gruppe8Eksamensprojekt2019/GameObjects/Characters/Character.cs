using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        protected float distance;
        protected Rectangle intersection;

		protected float cooldown;
		protected string playerDirection;

        protected bool collidingTop;
        protected bool collidingBottom;
        protected bool collidingLeft;
        protected bool collidingRight;

        protected Texture2D attackRight;
        protected Texture2D attackLeft;
        protected Texture2D attackUp;
        protected Texture2D attackDown;


        protected virtual void UpdateHealth(int health, int amount)
        {

        }

        protected virtual void Attack(GameTime gameTime)
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
