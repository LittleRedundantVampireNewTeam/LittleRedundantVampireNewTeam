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
        //Fields
        public GameObject parrent;
        public GameObject child;

        protected Texture2D[] sprites;
        protected Texture2D spriteUp;
        protected Texture2D spriteDown;
        public    Texture2D sprite;

        protected Vector2 position;
        protected Vector2 velocity;
        protected Rectangle intersect;

        protected string name;
        protected TimeSpan timer;

        protected bool doorLocked = true; //true skal defineres et andet sted!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        protected bool pushing = false;
        protected bool hasShadow;

        protected bool giveShadow;
        protected bool isMoving;
		protected bool healthIsShown;
        protected bool unlocked;
        protected bool invincible;
        private bool hitByAttack;

        protected byte currentIndex;

        protected int scaledWidth;
        protected int scaledHeight;
        protected int speed;

        protected float drawLayer = 0.01f;
        protected float deltaTime;
        protected float fps;
        private float timeElapsed;


        public bool Unlocked
        {
            get { return unlocked; }
            set { unlocked = value; }
        }


		

        //Properties
        public bool Unlocked
        {
            get { return unlocked; }
            set { unlocked = value; }
        }

        public bool HitByAttack
        {
            get { return hitByAttack; }
            set { hitByAttack = value; }
        }

        public bool Invincible
        {
            get { return invincible; }
        }

        public GameObject Parrent
        {
            get { return parrent; }
            set { parrent = value; }
        }

		public Texture2D Sprite
		{
			get { return sprite; }
			set { sprite = value; }
		}

        public virtual Rectangle CollisionBox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, scaledWidth, scaledHeight); }
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

        public int ScaledWidth
        {
            get { return scaledWidth; }
            set { scaledWidth = value; }
        }

        public int ScaledHeight
        {
            get { return scaledHeight; }
            set { scaledHeight = value; }
        }

        //Methods
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1*GameWorld.Scale, SpriteEffects.None, drawLayer);
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
