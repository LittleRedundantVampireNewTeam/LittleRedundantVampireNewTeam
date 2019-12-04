﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
    public abstract class GameObject
    {
        private Rectangle collisionBox;
        protected Texture2D sprite;
        protected byte currentIndex;
        protected float fps;
        protected Vector2 position;
        protected Vector2 velocity;
        protected int speed;
        protected bool hasShadow;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public bool HasShadow
        {
            get { return hasShadow;  }
        }

        public virtual Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
        }

        public abstract void Update(GameTime gameTime);

        public abstract void LoadContent(ContentManager content);

        protected virtual void CheckCollision(GameObject gameObject)
        {

        }

        protected virtual void OnCollision(GameObject other)
        {

        }

        protected virtual void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((velocity * speed) * deltaTime);
        }
    }
}
