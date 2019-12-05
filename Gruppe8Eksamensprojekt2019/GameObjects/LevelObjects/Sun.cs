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
    class Sun : GameObject
    {
        public Sun(Vector2 position)
        {
            base.position = position;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("WindowDark2");
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
