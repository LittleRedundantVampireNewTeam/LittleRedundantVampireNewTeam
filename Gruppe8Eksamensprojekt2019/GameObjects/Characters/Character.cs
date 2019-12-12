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

		protected Texture2D spriteDownWalk1;
		protected Texture2D spriteDownWalk2;
		protected Texture2D spriteUpWalk1;
		protected Texture2D spriteUpWalk2;
		protected Texture2D spriteWalk1;
		protected Texture2D spriteWalk2;


		protected virtual void UpdateHealth(int health, int amount)
        {

        }

		protected void ChangeDirection()
		{
			switch (characterDirection)
			{
				case "L":
					sprites[0] = sprite;
					sprites[1] = spriteWalk1;
					sprites[2] = sprite;
					sprites[3] = spriteWalk2;
					break;
				case "R":
					sprites[0] = sprite;
					sprites[1] = spriteWalk1;
					sprites[2] = sprite;
					sprites[3] = spriteWalk2;
					break;
				case "U":
					sprites[0] = spriteUp;
					sprites[1] = spriteUpWalk1;
					sprites[2] = spriteUp;
					sprites[3] = spriteUpWalk2;
					break;
				case "D":
					sprites[0] = spriteDown;
					sprites[1] = spriteDownWalk1;
					sprites[2] = spriteDown;
					sprites[3] = spriteDownWalk2;
					break;
			}
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

		public override void Draw(SpriteBatch spriteBatch)
		{

			switch (isMoving)
			{
				case true:
					if (characterDirection == "R" || characterDirection == "U" || characterDirection == "D")
					{
						spriteBatch.Draw(sprites[currentIndex], position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, drawLayer);
					}
					if (characterDirection == "L")
					{
						spriteBatch.Draw(sprites[currentIndex], position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.FlipHorizontally, drawLayer);
					}
					break;
				case false:

					switch (characterDirection)
					{
						case "R":
							spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, drawLayer);
							break;
						case "L":
							spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.FlipHorizontally, drawLayer);
							break;
						case "U":
							spriteBatch.Draw(spriteUp, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, drawLayer);
							break;
						case "D":
							spriteBatch.Draw(spriteDown, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, drawLayer);
							break;
					}
					break;
			}
		}

		//public override void Draw(SpriteBatch spriteBatch)
		//{
		//	if (characterDirection == "R" || characterDirection == "U" || characterDirection == "D")
		//	{
		//		spriteBatch.Draw(sprites[currentIndex], position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, drawLayer);
		//	}
		//	if (characterDirection == "L")
		//	{
		//		spriteBatch.Draw(sprites[currentIndex], position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.FlipHorizontally, drawLayer);
		//	}
		//}

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
