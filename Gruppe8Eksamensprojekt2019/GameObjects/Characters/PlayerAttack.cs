using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Gruppe8Eksamensprojekt2019
{
	class PlayerAttack : GameObject
	{
        private int attackScaledWidth;
        private int attackScaledHeight;

        public override void LoadContent(ContentManager content)
		{}

		public override void Update(GameTime gameTime)
		{
            HandleAttack(gameTime);
        }

		public PlayerAttack(Texture2D playerAttackSprite, Vector2 position, Vector2 velocity)
		{
			base.sprite = playerAttackSprite;
			base.position = position;
			base.velocity = velocity;
            drawLayer = 0.7f;

            attackScaledHeight = (int)(sprite.Height * GameWorld.Scale);
            attackScaledWidth = (int)(sprite.Width * GameWorld.Scale);
        }

        public override Rectangle CollisionBox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, attackScaledWidth, attackScaledHeight); }
        }

        private void HandleAttack(GameTime gameTime)
		{
			//Counts down the timer for the duration of the attack
			timer += gameTime.ElapsedGameTime;

			//Deletes the instance of the attack when the timer is zero or below zero.
			if (timer >= new TimeSpan(0, 0, 0, 0, 100))
			{
				GameWorld.Destroy(this);
			}
		}
	}
}
