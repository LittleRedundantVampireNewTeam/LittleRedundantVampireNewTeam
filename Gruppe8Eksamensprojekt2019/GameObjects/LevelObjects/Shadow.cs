using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gruppe8Eksamensprojekt2019
{
    class Shadow : GameObject
    {
        public Shadow(Texture2D sprite, Vector2 position)
        {
            base.sprite = sprite;
            base.position = position;
        }


        public override void LoadContent(ContentManager content)
        {
           
        }

        public override void Update(GameTime gameTime)
        {
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.Black, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
        }
    }
}
