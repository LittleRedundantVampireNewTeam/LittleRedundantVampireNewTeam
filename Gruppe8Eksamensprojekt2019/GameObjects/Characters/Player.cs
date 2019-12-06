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

        private KeyboardState keyState; // NEW


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
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("playerTexture");
        }

        private void HandleInput()
        {
           
            velocity = Vector2.Zero;
            keyState = Keyboard.GetState();

            /// Controls/moves the player sprite.
            if (keyState.IsKeyDown(Keys.Left))
            {
                //Console.WriteLine(position.X);
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
            //Do something when we collid with another object
            if (other is Wall || other is Vase || other is Sun || other is Chest || other is Crate || other is Door && doorLocked == true)
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

            if (other is Key)
            {
                //if (keyState.IsKeyDown(Keys.V))
                //{
                //    GameWorld.Destroy(other);
                    
                //}
            }
        }
    }
}

