using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{

    class SunRay : GameObject
    {
        public SunRay(Vector2 position)
        {
            base.position = position;
            drawLayer = 0.2f;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = GameWorld.SunRaySprite;
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
