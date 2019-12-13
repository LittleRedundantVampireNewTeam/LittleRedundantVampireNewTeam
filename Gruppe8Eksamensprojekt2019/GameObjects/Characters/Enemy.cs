using Microsoft.Xna.Framework;
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

        public Enemy(Vector2 position)
        {
            base.position = position;
			health = 3;
			speed = (int)(80 * GameWorld.Scale);
			drawLayer = 0.5f;
		}

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
			HandleDirection();
			SwitchState(gameTime);
			ChangeDirection();
			Animate(gameTime);
			InvincibleTimer(gameTime);
			UpdateHealth();

			if (HitByAttack == true && invincible == false)
			{
				invincible = true;
				takeDamage = true;
				HitByAttack = false;
			}
		}

		public void UpdateDistance(Player target)
		{
			targetDistanceX = target.Position.X - position.X;
			targetDistanceY = target.Position.Y - position.Y;
		}

        public override void LoadContent(ContentManager content)
        {
			fps = 5f;
			isMoving = true;
			healthIsShown = false;
			cooldownTimer = new TimeSpan(0, 0, 1);

			sprite = content.Load<Texture2D>("VampireOzzyStill");
			spriteUp = content.Load<Texture2D>("VampireOzzyUp2");
			spriteDown = content.Load<Texture2D>("VampireOzzyDown");
			spriteWalk1 = content.Load<Texture2D>("Vampire ozzy2 '");
			spriteWalk2 = content.Load<Texture2D>("VampireOzzyWalking");
			spriteDownWalk1 = content.Load<Texture2D>("VampireOzzyDownWalk1");
			spriteDownWalk2 = content.Load<Texture2D>("VampireOzzyDownWalk2");
			spriteUpWalk1 = content.Load<Texture2D>("VampireOzzyUpWalk1");
			spriteUpWalk2 = content.Load<Texture2D>("VampireOzzyUpWalk2");

			sprites = new Texture2D[4];

			patrolDistance = 2*sprite.Width;
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

		//protected override void UpdateHealth(int health, int amount)
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
			if ((targetDistanceX >= -sprite.Width * 2 && targetDistanceX <= sprite.Width * 2) &&
				(targetDistanceY >= -sprite.Height * 2 && targetDistanceY <= sprite.Height * 2))
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

			if (targetDistanceX > sprite.Width * 2 || targetDistanceX < -sprite.Width * 2 || targetDistanceY > sprite.Height * 2 || targetDistanceY < -sprite.Height * 2)
			{
				velocity = new Vector2(0f, 0f);
				Patrol();
			}

			if (health <= 0)
			{
				GameWorld.Destroy(this);
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

		
	}
}
