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
    class Chest : GameObject
    {
        public Chest(Vector2 position)
        {
            base.position = position;
        }

        public override void Update(GameTime gameTime)
        {
            
        }
        
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("treasureTexture");
        }

        private void OpenChest()
        {
            GameWorld.gameObjects.Add(new Key("Key2", new Vector2(10, 10)));
        }

        private void GivePrompt()
        {

        }
    }
}
