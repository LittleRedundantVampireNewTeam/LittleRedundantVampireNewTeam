﻿using System;
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
            drawLayer = 0.4f;
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
            Parrent.GiveShadow = false;
        }

        public override Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height*2);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.Black, 0, new Vector2(0, 0), new Vector2(1,2), SpriteEffects.None, drawLayer);
        }
    }
}
