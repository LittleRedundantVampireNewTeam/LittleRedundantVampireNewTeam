﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
	class Enemy : Character
	{
		private float targetDistanceX;
		private float targetDistanceY;
		private float patrolDistance;
		private float previousDistance;
		private bool patrolRight;

		private SoundEffect enemyAttackSound;
        private bool enemyHasAttacked;


		public Enemy(string name, int health, Vector2 position, Ability ability)
		{

        }

        public Enemy(Vector2 position)
        {
            base.position = position;
			health = 3;
			speed = (int)(100 * GameWorld.Scale);
			drawLayer = 0.5f;
		}

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
			HandleDirection();
			SwitchState(gameTime);
		}

		public void UpdateDistance(Player target)
		{
			targetDistanceX = target.Position.X - position.X;
			targetDistanceY = target.Position.Y - position.Y;
		}

        public override void LoadContent(ContentManager content)
        {
            sprite = GameWorld.EnemySprite;
			patrolDistance = 4*sprite.Width;
			previousDistance = patrolDistance;

			attackRight = content.Load<Texture2D>("SlashAttackRight");
			attackLeft = content.Load<Texture2D>("SlashAttackLeft");
			attackUp = content.Load<Texture2D>("SlashAttackUp");
			attackDown = content.Load<Texture2D>("SlashAttackDown");

			attackSound = content.Load<SoundEffect>("Whoosh sound effect");

			hasAttacked = false;
		}

        protected override void UseAbility(AbilityType ability)
		{

		}

		protected override void UpdateHealth(int health, int amount)
		{

		}

		//protected override void Attack(GameTime gameTime)
		//{

		//}

		private void HandleDirection()
		{
			if (velocity.X > 0)
			{
				characterDirection = "R";
			}
			if (velocity.X < 0)
			{
				characterDirection = "L";
			}
			if (velocity.Y > 0)
			{
				characterDirection = "D";
			}
			if (velocity.Y < 0)
			{
				characterDirection = "U";
			}

		}

		private void SwitchState(GameTime gameTime)
		{
			if ((targetDistanceX >= -sprite.Width * 4 && targetDistanceX <= sprite.Width * 4) &&
				(targetDistanceY >= -sprite.Height * 4 && targetDistanceY <= sprite.Height * 4))
			{
				FollowTarget();

				if (hasAttacked == false)
				{
					Attack(gameTime);
					attackSound.Play();
					timer = new TimeSpan(0, 0, 0, 1, 0);
				}
				if (hasAttacked == true)
				{
					timer -= gameTime.ElapsedGameTime;
					if (timer <= TimeSpan.Zero)
					{
						hasAttacked = false;
					}
				}
			}

			if (targetDistanceX > sprite.Width * 4 || targetDistanceX < -sprite.Width * 4 || targetDistanceY > sprite.Height * 4 || targetDistanceY < -sprite.Height * 4)
			{
				velocity = new Vector2(0f, 0f);
				Patrol();
			}
		}

		private void Patrol()
		{
			if (patrolDistance <= 0)
			{
				patrolRight = true;
			}
			else if (patrolDistance >= previousDistance && patrolDistance <= previousDistance)
			{
				patrolRight = false;
			}
			else if (patrolDistance <= previousDistance && patrolRight == false)
			{
				velocity.X = -1f;
			}

			if (patrolRight == true)
			{
				patrolDistance += 1;
				velocity.X = 1f;
			}
			else
			{
				patrolDistance -= 1;
			}

		}

		private void FollowTarget()
		{
			if (targetDistanceX < -sprite.Width/2)
			{
				velocity.X = -1f;
			}
			else if (targetDistanceX > sprite.Width/2)
			{
				velocity.X = 1f;
			}
			else if (targetDistanceX == 0)
			{
				velocity.X = 0f;
			}

			if (targetDistanceY < -sprite.Height/2)
			{
				velocity.Y = -1f;
			}
			else if (targetDistanceY > sprite.Height/2)
			{
				velocity.Y = 1f;
			}
			else if (targetDistanceY == 0)
			{
				velocity.Y = 0f;
			}
		}

		protected override void OnCollision(GameObject other)
		{
            //Do something when we collid with another object
            if (other is Wall || other is Vase || other is Sun || other is Chest || other is Crate || other is Door && doorLocked == true)
            {
                intersection = Rectangle.Intersect(other.CollisionBox, CollisionBox);

                if (intersection.Width > intersection.Height) // TOP OG BOTTOM
                {
                    if (other.Position.Y > position.Y) //Top
                    {
                        distance = CollisionBox.Bottom - other.CollisionBox.Top;
                        position.Y -= distance;
                    }

                    if (other.Position.Y < position.Y) //Bottom
                    {
                        distance = other.CollisionBox.Bottom - CollisionBox.Top;
                        position.Y += distance;
                    }
                }

                else
                {
                    if (other.Position.X < position.X) //Left collision
                    {
                        distance = other.CollisionBox.Right - CollisionBox.Left;

                        position.X += distance;
                    }

                    if (other.Position.X > position.X) //Right
                    {
                        distance = CollisionBox.Right - other.CollisionBox.Left;

                        position.X -= distance;
                    }
                }
            }
        }
	}
}
