using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
	class Enemy : Character
	{
		private SoundEffect enemyAttackSound;
        private bool enemyHasAttacked;


		public Enemy(string name, int health, Vector2 position, Ability ability)
		{

		}

        public Enemy(Vector2 position)
        {
            base.position = position;
        }

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = GameWorld.EnemySprite;

            sprite = content.Load<Texture2D>("Vampire ozzy2 '");
            spriteUp = content.Load<Texture2D>("VampireOzzyUp2");
            spriteDown = content.Load<Texture2D>("VampireOzzyDown");
            attackRight = content.Load<Texture2D>("SlashAttackRight");
            attackLeft = content.Load<Texture2D>("SlashAttackLeft");
            attackUp = content.Load<Texture2D>("SlashAttackUp");
            attackDown = content.Load<Texture2D>("SlashAttackDown");
            enemyHasAttacked = false;
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

		protected override void OnCollision(GameObject other)
		{
            //Do something when we collid with another object
            if (other is Wall || other is Vase || other is Sun || other is Chest || other is Crate || other is Door /*&& doorLocked == true*/)
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
