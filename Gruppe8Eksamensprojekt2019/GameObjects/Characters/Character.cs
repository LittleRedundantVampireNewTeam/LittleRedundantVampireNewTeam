using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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

        protected float distance;
        protected Rectangle intersection;

		protected float cooldown;
		protected string characterDirection;

        protected bool collidingTop;
        protected bool collidingBottom;
        protected bool collidingLeft;
        protected bool collidingRight;

        protected Texture2D attackRight;
        protected Texture2D attackLeft;
        protected Texture2D attackUp;
        protected Texture2D attackDown;
        protected bool hasAttacked;
        protected SoundEffect attackSound;

		protected SoundEffect attackSound;
		protected bool hasAttacked;

		

		protected virtual void UpdateHealth(int health, int amount)
        {

        }

        protected virtual void Attack(GameTime gameTime)
        {
			if (characterDirection == "R")
			{
				GameWorld.Instantiate(new EnemyAttack(attackRight, new Vector2(position.X + sprite.Width / 2, position.Y), new Vector2(0, 0)));
			}
			if (characterDirection == "L")
			{
				GameWorld.Instantiate(new EnemyAttack(attackLeft, new Vector2(position.X - sprite.Width / 2, position.Y), new Vector2(0, 0)));
			}
			if (characterDirection == "U")
			{
				GameWorld.Instantiate(new EnemyAttack(attackUp, new Vector2(position.X, position.Y - (sprite.Height / 2 + sprite.Height / 4)), new Vector2(0, 0)));
			}
			if (characterDirection == "D")
			{
				GameWorld.Instantiate(new EnemyAttack(attackDown, new Vector2(position.X, position.Y + (sprite.Height / 2 + sprite.Height / 4)), new Vector2(0, 0)));
			}
			//GameWorld.newCollisionObjects.Add();
			hasAttacked = true;
		}

        protected virtual void UseAbility(AbilityType ability)
        {
			
        }

        protected virtual void Speak()
        {

        }
    }
}
