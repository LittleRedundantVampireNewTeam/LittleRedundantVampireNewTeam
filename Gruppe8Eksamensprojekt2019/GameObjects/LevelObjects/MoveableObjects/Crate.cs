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

        public Crate(Texture2D sprite, Vector2 position, bool hasShadow)
        {
            
        }

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
          // Move(gameTime);
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

            // Makes sure crates can't be pushed through windows, walls, doors or other crates.
            // Player is added here. When the player is moving, the crate's position changes,
            // and is thereby pushed in whatever direction the player is moving.
            if (other is Wall || other is Sun || other is Crate || other is Door || other is Player)
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, drawLayer);
        }
    }
}
