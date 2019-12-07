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
    class Item : GameObject
    {
        public Item (Texture2D sprite, string name, Vector2 position)
        {
            base.sprite = sprite;
            base.name = name;
            base.position = position;
        }

        public override void LoadContent(ContentManager content)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
           
        }

        private void GivePrompt()
        {

        }
    }
}
