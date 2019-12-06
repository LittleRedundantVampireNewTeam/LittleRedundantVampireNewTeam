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
        public Door(string name, Vector2 position, bool doorLocked)
        {
            base.position = position;
            base.doorLocked = doorLocked;

        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("doorTexture");
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        private void OpenDoor()
        {

        }

        private void GivePrompt()
        {

        }
    }
}
