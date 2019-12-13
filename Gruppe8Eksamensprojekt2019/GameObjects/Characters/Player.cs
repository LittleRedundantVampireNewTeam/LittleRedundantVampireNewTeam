﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Gruppe8Eksamensprojekt2019
{
    class Player : Character
    {
        private int regeneration;
        private SoundEffect playerAttackSound;
        private bool isColliding;

		private Texture2D attackRight;
		private Texture2D attackLeft;
		private Texture2D attackUp;
		private Texture2D attackDown;

		private Texture2D spriteDownWalk1;
		private Texture2D spriteDownWalk2;
		private Texture2D spriteUpWalk1;
		private Texture2D spriteUpWalk2;
		private Texture2D spriteWalk1;
		private Texture2D spriteWalk2;

		private KeyboardState keyState; /// NEW
        private TimeSpan cooldownTimer;// = new TimeSpan(0, 0, 2);

        private bool invincible = false;
        private bool inShadow = false;
        private bool inSun = false;
        private bool hasAttacked;

        public List<GameObject> playerKeys = new List<GameObject>();
        public static HashSet<GameObject> lockedDoors = new HashSet<GameObject>();


        public Player(Vector2 position)
        {
            name = "Ozzy Bloodbourne";
            health = 100;
            speed = 600;
            base.position = position;
            playerDirection = "R";
            drawLayer = 0.5f;
            hasAttacked = false;
        }


        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
            HandleInput(gameTime);
            InvincibleTimer(gameTime);

            ChangeDirection();

            if (isMoving == true)
            {
              Animate(gameTime);
            }

            //Checks if the player should be taking damage from standing in the sun
            if (inSun == true && invincible == false)
            {
                inSun = false;
                invincible = true;
                if (health > 0)
                {
                    //HEALTHSYSTEM HERE*************
                    health--;
                    Console.WriteLine($"Health: {health}");
                }
            }
        }

        protected override void OnCollision(GameObject other)
        {   
            if (other is Key && keyState.IsKeyDown(Keys.V))
            {
                playerKeys.Add(other);
                GameWorld.Destroy(other);
            }

            //Checks if the player is colliding with a shadow and marks them as 'in a shadow'
            if (other is Shadow)
            {
                inShadow = true;
                inSun = false;
            }
            else
            {
                inShadow = false;
            }

            //Checks if the player is colliding with a sunray and marks them as 'in the sun'
            if (other is SunRay && inShadow == false)
            {
                inSun = true;

                //Key1v1 key = new Key1v1();
                //Key1v1 key2 = new Key1v1();
                //Door1v1 door = new Door1v1(key);
                //Player p = new Player();
                //p.key = key;
                //if (key == key2)
                //{

                //}

                //if (door.MyKey == p.key)
                //{

                //}
            }

            if (other is Door)
            {
                if (playerKeys.Contains(other.Parrent))
                {
                    other.Unlocked = true;
                }
            }

            //Do something when we collid with another object
            if (other is Wall || other is Vase || other is Sun || other is Chest || other is Crate || (other is Door && other.Unlocked == false))
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

        public override void LoadContent(ContentManager content)
        {
			isMoving = false;
            cooldownTimer   = new TimeSpan(0, 0, 2);

			sprite          = content.Load<Texture2D>("VampireOzzyStill");
			spriteUp        = content.Load<Texture2D>("VampireOzzyUp2");
			spriteDown      = content.Load<Texture2D>("VampireOzzyDown");
			spriteWalk1     = content.Load<Texture2D>("Vampire ozzy2 '");
			spriteWalk2     = content.Load<Texture2D>("VampireOzzyWalking");
			spriteDownWalk1 = content.Load<Texture2D>("VampireOzzyDownWalk1");
			spriteDownWalk2 = content.Load<Texture2D>("VampireOzzyDownWalk2");
			spriteUpWalk1   = content.Load<Texture2D>("VampireOzzyUpWalk1");
			spriteUpWalk2   = content.Load<Texture2D>("VampireOzzyUpWalk2");

			attackRight     = content.Load<Texture2D>("SlashAttackRight");
			attackLeft      = content.Load<Texture2D>("SlashAttackLeft");
			attackUp        = content.Load<Texture2D>("SlashAttackUp");
			attackDown      = content.Load<Texture2D>("SlashAttackDown");

			sprites = new Texture2D[4];

			fps = 5f;
			playerDirection = "D";


			for (int i = 0; i < sprites.Length; i++)
			{
                /////////////////////////////////////////////////////////
			}
		}

        private void HandleInput(GameTime gameTime)
        {
            velocity = Vector2.Zero;
            keyState = Keyboard.GetState();

            /// Controls/moves the player sprite.
            if (keyState.IsKeyDown(Keys.Left) && collidingLeft == false)
            {
                collidingRight = false;
                collidingTop = false;
                collidingBottom = false;

                velocity.X = -3f;
				playerDirection = "L";
				isMoving = true;
            }

            if (keyState.IsKeyDown(Keys.Right) && collidingRight == false)
            {
                collidingLeft = false;
                collidingTop = false;
                collidingBottom = false;

                velocity.X = +3f;
                playerDirection = "R";
                isMoving = true;
            }

            if (keyState.IsKeyDown(Keys.Up) && collidingBottom == false)
            {
                collidingRight = false;
                collidingLeft = false;
                collidingTop = false;

                velocity.Y = -3f;
                playerDirection = "U";
                isMoving = true;
            }

            if (keyState.IsKeyDown(Keys.Down) && collidingTop == false)
            {
                collidingRight = false;
                collidingBottom = false;
                collidingLeft = false;

                velocity.Y = +3f;
				playerDirection = "D";
				isMoving = true;
			}
			if (keyState.IsKeyUp(Keys.Left)&&keyState.IsKeyUp(Keys.Right)&&keyState.IsKeyUp(Keys.Up)&&keyState.IsKeyUp(Keys.Down))
			{
				isMoving = false;
			}
			if (keyState.IsKeyDown(Keys.A) && hasAttacked == false)
			{
				Attack(gameTime);
				timer = new TimeSpan(0, 0, 0, 0, 500);
			}
			if (hasAttacked == true)
			{
				timer -= gameTime.ElapsedGameTime;
				if (timer <= TimeSpan.Zero)
				{
					hasAttacked = false;
				}
			}
            if (velocity != Vector2.Zero)
            {
                /// Ensures that the player sprite doesn't move faster if they hold down two move keys at the same time.
                velocity.Normalize();
            }
        }

        private void InvincibleTimer(GameTime gameTime)
        {
            /// Tæller ned fra 2, så invisiblilty frames ikke er for evigt.
            if (invincible == true)
            {
                if (cooldownTimer > TimeSpan.Zero)
                {
                    cooldownTimer -= gameTime.ElapsedGameTime;
                }
                if (cooldownTimer <= TimeSpan.Zero)
                {
                    invincible = false;
                    cooldownTimer = new TimeSpan(0, 0, 2);
                }
            }
        }

		protected override void Attack(GameTime gameTime)
		{
			if (playerDirection == "R")
			{
				GameWorld.Instantiate(new PlayerAttack(attackRight, new Vector2(position.X + sprite.Width/2, position.Y), new Vector2(0, 0)));
			}
			if (playerDirection == "L")
			{
				GameWorld.Instantiate(new PlayerAttack(attackLeft, new Vector2(position.X - sprite.Width/2, position.Y), new Vector2(0, 0)));
			}
			if (playerDirection == "U")
			{
				GameWorld.Instantiate(new PlayerAttack(attackUp, new Vector2(position.X, position.Y-(sprite.Height/2+sprite.Height/4)), new Vector2(0, 0)));
			}
			if (playerDirection == "D")
			{
				GameWorld.Instantiate(new PlayerAttack(attackDown, new Vector2(position.X, position.Y + (sprite.Height/2+sprite.Height/4)), new Vector2(0, 0)));
			}
			hasAttacked = true;

			//else
			//{

			//	if(cooldown <= 0)
			//	{
			//		hasAttacked = false;
			//	}
			//}
		}

        private void SuckAttack()
        {

        }

        protected override void UseAbility(AbilityType ability)
        {

        }

        private void UpdateInventory()
        {

        }

		private void ChangeDirection()
		{
			switch(playerDirection)
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


		public override void Draw(SpriteBatch spriteBatch)
		{

			switch(isMoving)
			{
				case true:
					if (playerDirection == "R" || playerDirection == "U" || playerDirection == "D")
					{
						spriteBatch.Draw(sprites[currentIndex], position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.scale, SpriteEffects.None, drawLayer);
					}
					if (playerDirection == "L")
					{
						spriteBatch.Draw(sprites[currentIndex], position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.scale, SpriteEffects.FlipHorizontally, drawLayer);
					}
					break;
				case false:

					switch(playerDirection)
					{
						case "R":
							spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.scale, SpriteEffects.None, drawLayer);
							break;
						case "L":
							spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.scale, SpriteEffects.FlipHorizontally, drawLayer);
							break;
						case "U":
							spriteBatch.Draw(spriteUp, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.scale, SpriteEffects.None, drawLayer);
							break;
						case "D":
							spriteBatch.Draw(spriteDown, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.scale, SpriteEffects.None, drawLayer);
							break;
					}
					break;
			}
		}
	}
}
