using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Gruppe8Eksamensprojekt2019
{
    class Player : Character
    {
        

        private int regeneration;
        private bool isColliding;

		//private Texture2D attackRight;
		//private Texture2D attackLeft;
		//private Texture2D attackUp;
		//private Texture2D attackDown;

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

        public int Health
        {
            get { return health; }
        }

        public Player(Vector2 position)
        {
            name = "Ozzy Bloodbourne";
            health = 10;
            speed = (int)(200 * GameWorld.Scale);
            base.position = position;
            characterDirection = "R";
            drawLayer = 0.5f;
            hasAttacked = false;

            for (int i = 0; i < health; i++)
            {
                GameWorld.UiHeartList.Add(new UiHeart(this));
            }
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
                invincible = true;

                if (health > 0)
                {
                    //HEALTHSYSTEM HERE*************
                    
                    GameWorld.UiHeartList.RemoveAt(health-1);
                    health--;
                    Console.WriteLine($"Health: {health}");
                }
            }
        }

        protected override void OnCollision(GameObject other)
        {
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

            // Checks if the player is colliding with a sunray and marks them as 'in the sun'
            if (other is SunRay && inShadow == false)
            {
                inSun = true;
            }

            // Do something when we collid with another object
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

            if (other is Crate)
            {

            }

            if (other is Key)
            {
                //if (keyState.IsKeyDown(Keys.V))
                //{
                //    GameWorld.Destroy(other);
                //}
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

            attackSound     = content.Load<SoundEffect>("Whoosh sound effect");

            hasAttacked     = false;

			sprites = new Texture2D[4];

			fps = 5f;
			characterDirection = "D";

            
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
				characterDirection = "L";
				isMoving = true;
            }

            if (keyState.IsKeyDown(Keys.Right) && collidingRight == false)
            {
                collidingLeft = false;
                collidingTop = false;
                collidingBottom = false;

                velocity.X = +3f;
                characterDirection = "R";
                isMoving = true;
            }

            if (keyState.IsKeyDown(Keys.Up) && collidingBottom == false)
            {
                collidingRight = false;
                collidingLeft = false;
                collidingTop = false;

                velocity.Y = -3f;
                characterDirection = "U";
                isMoving = true;
            }

            if (keyState.IsKeyDown(Keys.Down) && collidingTop == false)
            {
                collidingRight = false;
                collidingBottom = false;
                collidingLeft = false;

                velocity.Y = +3f;
				characterDirection = "D";
				isMoving = true;
			}
			if (keyState.IsKeyUp(Keys.Left)&&keyState.IsKeyUp(Keys.Right)&&keyState.IsKeyUp(Keys.Up)&&keyState.IsKeyUp(Keys.Down))
			{
				isMoving = false;
			}
			if (keyState.IsKeyDown(Keys.A) && hasAttacked == false)
			{
				Attack(gameTime);
                attackSound.Play();
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
                inSun = false;
                UiHeart.DrawHealthUI = true;
                if (cooldownTimer > TimeSpan.Zero)
                {
                    cooldownTimer -= gameTime.ElapsedGameTime;
                }
                if (cooldownTimer <= TimeSpan.Zero)
                {
                    invincible = false;
                    UiHeart.DrawHealthUI = false;
                    cooldownTimer = new TimeSpan(0, 0, 2);
                }
            }
        }

		protected override void Attack(GameTime gameTime)
		{
			if (characterDirection == "R")
			{
				GameWorld.Instantiate(new PlayerAttack(attackRight, new Vector2(position.X + sprite.Width / 2, position.Y), new Vector2(0, 0)));
			}
			if (characterDirection == "L")
			{
				GameWorld.Instantiate(new PlayerAttack(attackLeft, new Vector2(position.X - sprite.Width / 2, position.Y), new Vector2(0, 0)));
			}
			if (characterDirection == "U")
			{
				GameWorld.Instantiate(new PlayerAttack(attackUp, new Vector2(position.X, position.Y - (sprite.Height / 2 + sprite.Height / 4)), new Vector2(0, 0)));
			}
			if (characterDirection == "D")
			{
				GameWorld.Instantiate(new PlayerAttack(attackDown, new Vector2(position.X, position.Y + (sprite.Height / 2 + sprite.Height / 4)), new Vector2(0, 0)));
			}

			hasAttacked = true;
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
			switch(characterDirection)
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

					switch(characterDirection)
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
	}
}
