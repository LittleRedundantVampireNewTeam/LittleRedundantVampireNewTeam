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
            hasShadow = false;
            giveShadow = false;
            speed = 2;
        }

        public override void Update(GameTime gameTime)
        {
           velocity.X = +10f;
           Move(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {

            sprite = content.Load<Texture2D>("Crate3");
            ///////////////////////////////////////TEXTURE UPDATE

            sprite = GameWorld.CrateSprite;

        }

        protected override void Push()
        {

        }

        protected override void OnCollision(GameObject other)
        {
            //Marks the crate to recieve a shadow
            if (other is SunRay && giveShadow == false)
            {
                giveShadow = true;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, 0.5f);
        }
    }
}
