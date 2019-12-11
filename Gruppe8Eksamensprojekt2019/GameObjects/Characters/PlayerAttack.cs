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
	class PlayerAttack : Attack
	{
        
        public override void LoadContent(ContentManager content)
		{
            
		}

		public override void Update(GameTime gameTime)
		{
			HandleAttack(gameTime);
		}

		public PlayerAttack(Texture2D playerAttackSprite, Vector2 position, Vector2 velocity)
		{
			base.sprite = playerAttackSprite;
			base.position = position;
			base.velocity = velocity;

            attackScaledHeight = (int)(sprite.Height * GameWorld.Scale);
            attackScaledWidth = (int)(sprite.Width * GameWorld.Scale);
        }

        
	}
}
