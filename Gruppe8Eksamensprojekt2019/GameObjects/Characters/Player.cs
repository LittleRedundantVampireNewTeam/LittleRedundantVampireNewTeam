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
        
        public Player(Vector2 position)
        {
            name = "Ozzy Bloodbourne";
            health = 100;
            speed = 200;
            base.position = position;
        }


        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
            HandleInput();
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
            sprite = content.Load<Texture2D>("playerTexture");
            cooldownTimer = new TimeSpan(0, 0, 2);
        }

        private void HandleInput()
        {
           
            velocity = Vector2.Zero;
            keyState = Keyboard.GetState();

            /// Controls/moves the player sprite.
            if (keyState.IsKeyDown(Keys.Left))
            {
                velocity.X = -3f;
            }
            if (keyState.IsKeyDown(Keys.Right))
            {
                velocity.X = +3f;
            }
            if (keyState.IsKeyDown(Keys.Up))
            {
                velocity.Y = -3f;
            }
            if (keyState.IsKeyDown(Keys.Down))
            {
                velocity.Y = +3f;
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

        protected override void Attack()
        {

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
    }
}
