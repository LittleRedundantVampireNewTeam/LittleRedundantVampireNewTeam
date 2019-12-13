using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
    public class Decoration
    {
        private Vector2 position;
        private Texture2D sprite;

        public Vector2 Position
        {
            get { return position; }
        }

        public Decoration(Texture2D sprite, Vector2 position)
        {
            this.position = position;
            this.sprite = sprite;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 1 * GameWorld.Scale, SpriteEffects.None, 0.1f);
        }
    }
}
