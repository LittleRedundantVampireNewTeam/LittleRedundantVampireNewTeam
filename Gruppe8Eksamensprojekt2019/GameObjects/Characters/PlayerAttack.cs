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

       
        public override void LoadContent(ContentManager content)
		{
            
		}

		public override void Update(GameTime gameTime)
		{
			HandleAttack(gameTime);
		}

		public PlayerAttack()
		{
			// sets the attacktimer to zero.
			timer = new TimeSpan(0, 0, 0, 0, 0);
		}

		public PlayerAttack(Texture2D playerAttackSprite, Vector2 position, Vector2 velocity)
		{
			base.sprite = playerAttackSprite;
			base.position = position;
			base.velocity = velocity;
		}

		protected override void OnCollision(GameObject other)
		{
            if (other is Vase)
            {
                GameWorld.Destroy(other);
            }
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
