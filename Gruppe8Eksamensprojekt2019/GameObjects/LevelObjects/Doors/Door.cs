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
    class Door : GameObject
    {
        private Texture2D sprite2;
        public Door(Vector2 position, GameObject parrent)
        {
            base.position = position;
            base.parrent = parrent;
            unlocked = false;
            drawLayer = 0.4f;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("doorTexture");
            //sprite2 = content.Load<Texture2D>("OPEN SALAMI PLSSS"); ////////////////// Indsæt sprite når det er
        }

        public override void Update(GameTime gameTime)
        {
            if (unlocked == true)
            {
                
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (unlocked == true)
            {
                spriteBatch.Draw(sprite, position, null, Color.Blue, 0, new Vector2(0, 0), 1, SpriteEffects.None, drawLayer);
            }
            else
            {
                spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, drawLayer);
            }
        }

        private void GivePrompt()
        {

        }
    }
}
