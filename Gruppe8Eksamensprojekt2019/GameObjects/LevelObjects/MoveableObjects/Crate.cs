using Microsoft.Xna.Framework;
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
    class Crate : MoveableObject
    {
        protected Rectangle intersection;
        private int distance;
        private bool pushUp = true;
        private bool pushDown = true;
        private bool pushRight = true;
        private bool pushLeft = true;

        public bool PushUp { get => pushUp; set => pushUp = value; }
        public bool PushDown { get => pushDown; set => pushDown = value; }
        public bool PushRight { get => pushRight; set => pushRight = value; }
        public bool PushLeft { get => pushLeft; set => pushLeft = value; }

        public Crate(Vector2 position)  
        {
            base.position = position;
            hasShadow = false;
            giveShadow = false;
            speed = 200;
            drawLayer = 0.5f;
        }

        public override void Update(GameTime gameTime)
        {
            // These bools are sat as true here, to make sure they become true again after being set as false in collision.
            // This ensures that if a crate is moved to the left and hits a wall (or another solid object),
            // and the player moves it away from the object, the object can again be pushed to the left.
            // Without this, the bool would be stuck on false and the crate would no longer be able to be pushed in that direction.
            pushUp = true;
            pushDown = true;
            pushLeft = true;
            pushRight = true;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = GameWorld.CrateSprite;
        }

        protected override void Push()
        {

        }

        protected override void OnCollision(GameObject other)
        {
            //Marks the crate to recieve a shadow
            if (other is SunRay && giveShadow == false)
            {
                giveShadow = true;
            }

            //Makes sure crates can't be pushed through windows, walls, doors or other crates.
            if (other is Wall || other is Sun || other is Crate || other is Door)
            {
                intersection = Rectangle.Intersect(other.CollisionBox, CollisionBox);

                //The bools "pushDown", up, etc, makes sure that once the crate hits a side, the player can't walk through the crate.
                //The code making sure of this is in the class Player.
                if (intersection.Width > intersection.Height) // Top and bottom.
                {
                    if (other.Position.Y > position.Y) //Bottom of crate
                    {
                        pushDown = false;
                        distance = CollisionBox.Bottom - other.CollisionBox.Top;
                        position.Y -= distance;
                    }
                    if (other.Position.Y < position.Y) //Top of crate
                    {
                        pushUp = false;
                        distance = other.CollisionBox.Bottom - CollisionBox.Top;
                        position.Y += distance;
                    }
                }
                else if (intersection.Width < intersection.Height)  //Right and left.
                {
                    if (other.Position.X > position.X) //Right of crate
                    {
                        pushLeft = false;
                        distance = CollisionBox.Right - other.CollisionBox.Left;
                        position.X -= distance;
                    }
                    if (other.Position.X < position.X) //Left of crate
                    {
                        pushRight = false;
                        distance = other.CollisionBox.Right - CollisionBox.Left;
                        position.X += distance;
                    }
                }
            }

            // Enables the player to move the crates.
            if (other is Player)
            {
                intersection = Rectangle.Intersect(other.CollisionBox, CollisionBox);

                if (intersection.Width > intersection.Height) //Top and bottom.
                {
                    if (other.Position.Y > position.Y) //Bottom of crate. It's being pushed upwards.
                    {
                        distance = CollisionBox.Bottom - other.CollisionBox.Top;
                        position.Y -= distance;
                    }
                    if (other.Position.Y < position.Y) //Top of crate. It's being pushed downwards.
                    {
                        distance = other.CollisionBox.Bottom - CollisionBox.Top;
                        position.Y += distance;
                    }
                }
                else //Left and Right.
                {
                    if (other.Position.X < position.X) //Left of crate. It's being pushed to the right.
                    {
                        distance = other.CollisionBox.Right - CollisionBox.Left;
                        position.X += distance;
                    }
                    if (other.Position.X > position.X) //Right of crate. It's being pushed to the left.
                    {
                        distance = CollisionBox.Right - other.CollisionBox.Left;
                        position.X -= distance;
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, drawLayer);
        }
    }
}

