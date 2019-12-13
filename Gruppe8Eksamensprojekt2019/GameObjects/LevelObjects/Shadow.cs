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
        private int shadowScaledWidth;
        private int shadowScaledHeight;

        public Shadow(Texture2D sprite, Vector2 position, GameObject parrent)
        {
            base.sprite = sprite;
            base.position = position;
            base.parrent = parrent;
            drawLayer = 0.4f;

            shadowScaledHeight = (int)(sprite.Height * GameWorld.Scale);
            shadowScaledWidth = (int)(sprite.Width * GameWorld.Scale);
        }

        public override void LoadContent(ContentManager content)
        {}

        public override void Update(GameTime gameTime)
        {
            //Keeps the shadows position relative to its parrent object (crates for now)
            position.X = parrent.Position.X;
            position.Y = parrent.Position.Y + (sprite.Height * GameWorld.Scale);

            //Checks if the shadows parrent is colliding with a sunray and removes it if not
            if (Parrent.GiveShadow == false)
            {
                GameWorld.Destroy(this);
            }
        }

        protected override void OnCollision(GameObject other)
        {
            Parrent.GiveShadow = false;
        }

        public override Rectangle CollisionBox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, shadowScaledWidth, shadowScaledHeight * 2); }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.Black, 0, new Vector2(0, 0), new Vector2(1*GameWorld.Scale,2*GameWorld.Scale), SpriteEffects.None, drawLayer);
        }
    }
}
