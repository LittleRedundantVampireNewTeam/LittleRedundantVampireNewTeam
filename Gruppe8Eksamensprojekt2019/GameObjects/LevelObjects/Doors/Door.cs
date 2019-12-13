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
        public Door(Vector2 position, GameObject parrent)
        {
            base.position = position;
            base.parrent = parrent;
            unlocked = false;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("doorTexture");
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        private void GivePrompt()
        {

        }
    }
}
