using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
	class Enemy : Character
	{
		private SoundEffect enemyAttackSound;

		/// <summary>
		/// Constructor for the Enemy Class.
		/// </summary>
		/// <param name=""></param>
		/// <param name=""></param>
		/// <param name=""></param>
		/// <param name=""></param>
        

		public Enemy(string name, int health, Vector2 position, Ability ability)
		{

		}


        protected override void Update(GameTime gameTime)
        {
            Move(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {

        }

        protected override void UseAbility(AbilityType ability)
		{

		}

		protected override void UpdateHealth(int health, int amount)
		{

		}

		protected override void Attack()
		{

		}

		protected override void OnCollision(GameObject other)
		{

		}
	}
}
