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
    class Player : Character
    {
        private int regeneration;
        private SoundEffect playerAttackSound;

        private TimeSpan cooldownTimer;// = new TimeSpan(0, 0, 2);
        private bool invincible = false;
        private static bool inShadow = false;
        private static bool inSun = false;
        private KeyboardState keyState; /// NEW


        private bool isColliding;

		    private Texture2D attackRight;

    		private Texture2D attackLeft;

    		private Texture2D attackUp;

    		private Texture2D attackDown;

    		private KeyboardState keyState; /// NEW

        public Player(Vector2 position)
        {
            name = "Ozzy Bloodbourne";
            health = 100;
            speed = 200;
            base.position = position;
			playerDirection = "R";
        }


        public override void Update(GameTime gameTime)
        {
            Move(gameTime);

            HandleInput(gameTime);
            InvincibleTimer(gameTime);

            //Checks if the player should be taking damage from standing in the sun
            if (inSun == true && invincible == false)
            {
                invincible = true;
                if (health > 0)
                {
                    //HEALTHSYSTEM HERE*************
                    health--;
                }
            }

        }

        public override void LoadContent(ContentManager content)
        {

            cooldownTimer = new TimeSpan(0, 0, 2);
            sprite = content.Load<Texture2D>("Vampire ozzy2 '");
      			spriteUp = content.Load<Texture2D>("VampireOzzyUp2");
      			spriteDown = content.Load<Texture2D>("VampireOzzyDown");
      			attackRight = content.Load<Texture2D>("SlashAttackRight");
      			attackLeft = content.Load<Texture2D>("SlashAttackLeft");
      			attackUp = content.Load<Texture2D>("SlashAttackUp");
      			attackDown = content.Load<Texture2D>("SlashAttackDown");
      			hasAttacked = false;

        }

        private void HandleInput(GameTime gameTime)
        {

            velocity = Vector2.Zero;
            keyState = Keyboard.GetState();

            /// Controls/moves the player sprite.
            if (keyState.IsKeyDown(Keys.Left))
            {
                velocity.X = -3f;
				playerDirection = "L";
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                velocity.X = +3f;
				playerDirection = "R";
			}
            if (keyState.IsKeyDown(Keys.Up))
            {
                velocity.Y = -3f;
				playerDirection = "U";
			}
            if (keyState.IsKeyDown(Keys.Down))
            {
                velocity.Y = +3f;
				playerDirection = "D";
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

            //Checks if the player is colliding with a sunray and marks them as 'in the sun'
            if (other is SunRay && inShadow == false)
            {
                inSun = true;
            }

        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			if (playerDirection == "R")
			{
				spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, 0.1f);
			}

			if (playerDirection == "L")
			{
				spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.FlipHorizontally, 0.1f);
			}

			if (playerDirection == "U")
			{
				spriteBatch.Draw(spriteUp, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, 0.1f);
			}

			if (playerDirection == "D")
			{
				spriteBatch.Draw(spriteDown, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, 0.1f);
			}
		}

	}
}
