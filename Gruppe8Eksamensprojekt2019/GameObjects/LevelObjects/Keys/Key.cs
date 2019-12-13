using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
    class Key : GameObject
    {
        public Key(Vector2 position)
        {
            base.position = position;
            //child = parrentDoor;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("keyTexture");
            position.Y = position.Y - 150;
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}

