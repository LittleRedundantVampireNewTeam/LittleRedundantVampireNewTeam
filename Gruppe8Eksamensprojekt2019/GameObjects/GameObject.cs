using Microsoft.Xna.Framework;
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
        protected Texture2D sprite;
		protected Texture2D[] sprites;
		protected Texture2D spriteUp;
		protected Texture2D spriteDown;
        protected byte currentIndex;
        protected float fps;
        protected Vector2 position;
        protected Vector2 velocity;
        protected int speed;
        protected bool hasShadow;
        protected Rectangle intersect;
        protected bool doorLocked = true; //true skal defineres et andet sted!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        protected string name;
        protected bool giveShadow;
        protected float drawLayer = 0.01f;
        protected TimeSpan timer;
        protected float deltaTime;
        public GameObject parrent;
        public GameObject child;
        protected bool isMoving;
        private float timeElapsed;

        public GameObject Parrent
        {
            get { return parrent; }
        }

		public Texture2D Sprite

		{
			get { return sprite; }
			set { value = sprite; }
		}

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public bool HasShadow
        {
            get { return hasShadow;  }
            set { hasShadow = value; }
        }

        public bool GiveShadow
        {
            get { return giveShadow; }
            set { giveShadow = value; }
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
            spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1*GameWorld.Scale, SpriteEffects.None, 0.3f);
        }

        public abstract void Update(GameTime gameTime);

        public abstract void LoadContent(ContentManager content);

        public virtual void CheckCollision(GameObject other)
        {
            if (CollisionBox.Intersects(other.CollisionBox))
            {
                OnCollision(other);
            }
        }

        protected virtual void OnCollision(GameObject other)
        {

        }

        protected virtual void Move(GameTime gameTime)
        {
			deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += ((velocity * speed) * deltaTime);
        }

		protected void Animate(GameTime gameTime)
		{
			timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
			currentIndex = (byte)(timeElapsed * fps);

			if (currentIndex >= sprites.Length)
			{
				timeElapsed = 0;
				currentIndex = 0;
			}
		}
    }
}
