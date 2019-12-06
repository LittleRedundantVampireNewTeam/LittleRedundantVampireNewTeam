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


    class Shadow : GameObject
    {
        public Shadow(Texture2D sprite, Vector2 position, GameObject parrent)
        {
            base.sprite = sprite;
            base.position = position;
            base.parrent = parrent;
        }

        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {
            //Keeps the shadows position relative to its parrent object (crates for now)
            position.X = parrent.Position.X;
            position.Y = parrent.Position.Y + sprite.Height;

            //Checks if the shadows parrent is colliding with a sunray and removes it if not
            if (Parrent.GiveShadow == false)
            {
                GameWorld.Destroy(this);
            }
        }

        protected override void OnCollision(GameObject other)
        {
            //Gives the crate a shadow when colliding with a sunray
            if (other is SunRay)
            {
                Parrent.GiveShadow = true;
            }
            //Sets the crate to remove its shadow
            else
            {
                Parrent.GiveShadow = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.Black, 0, new Vector2(0, 0), new Vector2(1,2), SpriteEffects.None, 0.1f);
        }
    }
}
