﻿using Microsoft.Xna.Framework;
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
        protected Rectangle intersection;
        protected float distance;
        

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

        protected override void OnCollision(GameObject other)
        {
            // Do something when we collide with another object
            if (other is Wall || other is Vase || other is Sun || other is Chest || other is Door && doorLocked == true)
            {
                intersection = Rectangle.Intersect(other.CollisionBox, CollisionBox);

                if (intersection.Width > intersection.Height) // TOP OG BOTTOM
                {
                    if (other.Position.Y > position.Y) //Top
                    {
                        collidingTop = true;
                        distance = CollisionBox.Bottom - other.CollisionBox.Top;
                        position.Y -= distance;
                    }

                    if (other.Position.Y < position.Y) //Bottom
                    {
                        collidingBottom = true;
                        distance = other.CollisionBox.Bottom - CollisionBox.Top;
                        position.Y += distance;
                    }
                }

                else
                {
                    if (other.Position.X < position.X) //Left collision
                    {
                        collidingLeft = true;
                        distance = other.CollisionBox.Right - CollisionBox.Left;
                        position.X += distance;
                    }

                    if (other.Position.X > position.X) //Right
                    {
                        collidingRight = true;
                        distance = CollisionBox.Right - other.CollisionBox.Left;
                        position.X -= distance;
                    }
                }
            }
        }
    }
}
