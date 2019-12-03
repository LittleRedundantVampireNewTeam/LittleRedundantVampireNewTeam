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
    class Crate : MoveableObject
    {
        public Crate(Texture2D sprite, Vector2 position, bool hasShadow)
        {

        }

        public Crate(Vector2 position)
        {
            base.position = position;
        }

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("crateTexture");
        }

        protected override void Push()
        {
           
        }

        protected override void OnCollision(GameObject other)
        {

        }
    }
}
