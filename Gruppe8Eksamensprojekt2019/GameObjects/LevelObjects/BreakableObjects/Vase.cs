using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Gruppe8Eksamensprojekt2019
{
    class Vase : BreakableObject
    {

        public Vase(Vector2 position)
        {
            base.position = position;
			hasShadow = true;
        }



        public override void Update(GameTime gameTime)
        {

        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("vaseTexture");
        }


        protected override void Break()
        {
			
        }
    }
}
