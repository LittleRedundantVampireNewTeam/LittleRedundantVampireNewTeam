﻿using Microsoft.Xna.Framework;
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
        private SoundEffect playerAttackSound;
        private TimeSpan cooldownTimer;// = new TimeSpan(0, 0, 2);
        private bool invincible = false;
        private bool inShadow = false;
        private bool inSun = false;
        private KeyboardState keyState; /// NEW
        private bool isColliding;
        private bool playerHasAttacked;

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


            //Do something when we collid with another object
            if (other is Wall || other is Vase || other is Sun || other is Chest || other is Crate || other is Door && doorLocked == true)
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
            cooldownTimer = new TimeSpan(0, 0, 2);
            sprite = content.Load<Texture2D>("Vampire ozzy2 '");
            spriteUp = content.Load<Texture2D>("VampireOzzyUp2");
            spriteDown = content.Load<Texture2D>("VampireOzzyDown");
            attackRight = content.Load<Texture2D>("SlashAttackRight");
            attackLeft = content.Load<Texture2D>("SlashAttackLeft");
            attackUp = content.Load<Texture2D>("SlashAttackUp");
            attackDown = content.Load<Texture2D>("SlashAttackDown");
            playerHasAttacked = false;
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
            }

            if (keyState.IsKeyDown(Keys.Right) && collidingRight == false)
            {
                collidingLeft = false;
                collidingTop = false;
                collidingBottom = false;

                velocity.X = +3f;
                playerDirection = "R";
            }

            if (keyState.IsKeyDown(Keys.Up) && collidingBottom == false)
            {
                collidingRight = false;
                collidingLeft = false;
                collidingTop = false;

                velocity.Y = -3f;
                playerDirection = "U";
            }

            if (keyState.IsKeyDown(Keys.Down) && collidingTop == false)
            {
                collidingRight = false;
                collidingBottom = false;
                collidingLeft = false;

                velocity.Y = +3f;
                playerDirection = "D";
            }

            if (keyState.IsKeyDown(Keys.A) && playerHasAttacked == false)
            {
                Attack(gameTime);
                timer = new TimeSpan(0, 0, 0, 0, 500);
            }

            if (playerHasAttacked == true)
            {
                timer -= gameTime.ElapsedGameTime;
                if (timer <= TimeSpan.Zero)
                {
                    playerHasAttacked = false;
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
                GameWorld.Instantiate(new PlayerAttack(attackRight, new Vector2(position.X + sprite.Width / 2, position.Y), new Vector2(0, 0)));
            }
            if (playerDirection == "L")
            {
                GameWorld.Instantiate(new PlayerAttack(attackLeft, new Vector2(position.X - sprite.Width / 2, position.Y), new Vector2(0, 0)));
            }
            if (playerDirection == "U")
            {
                GameWorld.Instantiate(new PlayerAttack(attackUp, new Vector2(position.X, position.Y - (sprite.Height / 2 + sprite.Height / 4)), new Vector2(0, 0)));
            }
            if (playerDirection == "D")
            {
                GameWorld.Instantiate(new PlayerAttack(attackDown, new Vector2(position.X, position.Y + (sprite.Height / 2 + sprite.Height / 4)), new Vector2(0, 0)));
            }
            playerHasAttacked = true;

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

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (playerDirection == "R")
            {
                spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, 0.6f);
            }

            if (playerDirection == "L")
            {
                spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.FlipHorizontally, 0.6f);
            }

            if (playerDirection == "U")
            {
                spriteBatch.Draw(spriteUp, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, 0.6f);
            }

            if (playerDirection == "D")
            {
                spriteBatch.Draw(spriteDown, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, 0.6f);
            }
        }
    }
}
