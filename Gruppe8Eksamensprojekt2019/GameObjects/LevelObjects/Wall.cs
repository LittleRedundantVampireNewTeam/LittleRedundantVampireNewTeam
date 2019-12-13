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
    class Wall : GameObject
    {
        public Wall(Vector2 position)
        {
            base.position = position;
            drawLayer = 0.5f;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = GameWorld.EmptySprite;
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
