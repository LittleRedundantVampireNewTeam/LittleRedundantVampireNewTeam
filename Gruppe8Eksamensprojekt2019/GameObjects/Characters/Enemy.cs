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
		}

        protected override void UseAbility(AbilityType ability)
		{

		}

		protected override void UpdateHealth(int health, int amount)
		{

		}

		protected override void Attack(GameTime gameTime)
		{

		}

		private void SwitchState(GameTime gameTime)
		{
			if ((targetDistanceX >= -sprite.Width * 4 && targetDistanceX <= sprite.Width * 4) &&
				(targetDistanceY >= -sprite.Height * 4 && targetDistanceY <= sprite.Height * 4))
			{
				FollowTarget();
				Attack(gameTime);

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
	}
}
