using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
	abstract class Attack : GameObject
	{
		protected int attackScaledWidth;
		protected int attackScaledHeight;

		public override Rectangle CollisionBox
		{
			get { return new Rectangle((int)position.X, (int)position.Y, attackScaledWidth, attackScaledHeight); }
		}
		protected void HandleAttack(GameTime gameTime)
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
