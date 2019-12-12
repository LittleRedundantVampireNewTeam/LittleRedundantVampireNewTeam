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


	    private KeyboardState keyState; /// NEW

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
			UpdateHealth();
			ChangeDirection();

            if (isMoving == true)
            {
                Animate(gameTime);
            }

            //Checks if the player should be taking damage from standing in the sun
            if (invincible == false && (inSun == true || HitByAttack == true))
            {
                invincible = true;
				takeDamage = true;
				HitByAttack = false;
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

            if (other is Key)
            {
                //if (keyState.IsKeyDown(Keys.V))
                //{
                //    GameWorld.Destroy(other);
                //}
            }

            // Do something when we collide with another object
            if (other is Wall || other is Vase || other is Sun || other is Chest || other is Door && doorLocked == true)
            {
                intersection = Rectangle.Intersect(other.CollisionBox, CollisionBox);

                if (intersection.Width > intersection.Height) //Top and bottom.
                {
                    if (other.Position.Y > position.Y) // When player bottom hits object top.
                    {
                        collidingTop = true;
                        distance = CollisionBox.Bottom - other.CollisionBox.Top;
                        position.Y -= distance;
                    }

                    if (other.Position.Y < position.Y) // When player top hits object bottom.
                    {
                        collidingBottom = true;
                        distance = other.CollisionBox.Bottom - CollisionBox.Top;
                        position.Y += distance;
                    }
                }

                else // Left and right.
                {
                    if (other.Position.X < position.X) // When player left hits object right.
                    {
                        collidingLeft = true;
                        distance = other.CollisionBox.Right - CollisionBox.Left;
                        position.X += distance;
                    }

                    if (other.Position.X > position.X) // When player right hits object left.
                    {
                        collidingRight = true;
                        distance = CollisionBox.Right - other.CollisionBox.Left;
                        position.X -= distance;
                    }
                }
            }

            // Crates can't be walked through when they hit a solid object.
            if (other is Crate)
            {
                intersection = Rectangle.Intersect(other.CollisionBox, CollisionBox);

                if (intersection.Width > intersection.Height) // TOP OG BOTTOM
                {
                    if (other.Position.Y > position.Y && (other as Crate).PushDown == false) // When Player bottom hits object top. Pushes the object downwards.
                    {
                        collidingTop = true;
                        distance = CollisionBox.Bottom - other.CollisionBox.Top;
                        position.Y -= distance;
                    }

                    if (other.Position.Y < position.Y && (other as Crate).PushUp == false) // When Player top hits object bottom. Pushes the object upwards.
                    {
                        collidingBottom = true;
                        distance = other.CollisionBox.Bottom - CollisionBox.Top;
                        position.Y += distance;
                    }
                }

                else
                {
                    if (other.Position.X < position.X && (other as Crate).PushRight == false) // When player left hits object right. Pushes the object to the left.
                    {
                        collidingLeft = true;
                        distance = other.CollisionBox.Right - CollisionBox.Left;
                        position.X += distance;
                    }

                    if (other.Position.X > position.X && (other as Crate).PushLeft == false) // When player right hits object left. Pushes the object to the right.
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
			invincible = false;
			takeDamage = false;
			healthIsShown = true;
            hasAttacked = false;
            isMoving = false;
            fps = 5f;
            characterDirection = "D";
            cooldownTimer   = new TimeSpan(0, 0, 2);

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

			attackRight = content.Load<Texture2D>("SlashAttackRight");
            attackLeft = content.Load<Texture2D>("SlashAttackLeft");
            attackUp = content.Load<Texture2D>("SlashAttackUp");
            attackDown = content.Load<Texture2D>("SlashAttackDown");

            attackSound = content.Load<SoundEffect>("Whoosh sound effect");
			
        }

        private void HandleInput(GameTime gameTime)
        {
            velocity = Vector2.Zero;
            keyState = Keyboard.GetState();

            /// Controls/moves the player sprite.
            if (keyState.IsKeyDown(Keys.Left) && collidingLeft == false)
            {
                collidingBottom = false;
                collidingRight = false;
                collidingTop = false;
                isMoving = true;

                velocity.X = -3f;
				characterDirection = "L";
            }

            if (keyState.IsKeyDown(Keys.Right) && collidingRight == false)
            {
                collidingBottom = false;
                collidingLeft = false;
                collidingTop = false;
                isMoving = true;

                velocity.X = +3f;
                characterDirection = "R";
            }

            if (keyState.IsKeyDown(Keys.Up) && collidingBottom == false)
            {
                collidingRight = false;
                collidingLeft = false;
                collidingTop = false;
                isMoving = true;

                velocity.Y = -3f;
                characterDirection = "U";
            }

            if (keyState.IsKeyDown(Keys.Down) && collidingTop == false)
            {
                collidingBottom = false;
                collidingRight = false;
                collidingLeft = false;
                isMoving = true;

                velocity.Y = +3f;
				characterDirection = "D";
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

        protected override void InvincibleTimer(GameTime gameTime)
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
				GameWorld.Instantiate(new PlayerAttack(attackRight, new Vector2(position.X + sprite.Width/2, position.Y), new Vector2(0, 0)));
			}
			if (characterDirection == "L")
			{
				GameWorld.Instantiate(new PlayerAttack(attackLeft, new Vector2(position.X - sprite.Width/2, position.Y), new Vector2(0, 0)));
			}
			if (characterDirection == "U")
			{
				GameWorld.Instantiate(new PlayerAttack(attackUp, new Vector2(position.X, position.Y-(sprite.Height/2+sprite.Height/4)), new Vector2(0, 0)));
			}
			if (characterDirection == "D")
			{
				GameWorld.Instantiate(new PlayerAttack(attackDown, new Vector2(position.X, position.Y + (sprite.Height/2+sprite.Height/4)), new Vector2(0, 0)));
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

        public override Rectangle CollisionBox
        {
            get { return new Rectangle((int)position.X+(ScaledWidth/4), (int)position.Y, ScaledWidth/2, ScaledHeight); }
        }

	}
}
