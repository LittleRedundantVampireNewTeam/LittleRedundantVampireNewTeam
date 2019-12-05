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
        private bool isOpen;


        public Door(Texture2D sprite, Vector2 position, bool hasShadow)
        {

        }

        public Door(Vector2 position)
        {
            base.position = position;
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
