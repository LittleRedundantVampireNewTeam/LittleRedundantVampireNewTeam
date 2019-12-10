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
    public class UiHeart : GameObject

    {

        private static bool drawHealthUI;

        public static bool DrawHealthUI
        {
            get { return drawHealthUI; }
            set { drawHealthUI = value; }
        }

        public UiHeart(GameObject parrent)
        {
            base.parrent = parrent;
            drawLayer = 0.6f;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = GameWorld.UiHealthSprite;
        }

        public override void Update(GameTime gameTime)
        {
            position.X = parrent.Position.X;
            position.Y = parrent.Position.Y-sprite.Height*1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), GameWorld.Scale, SpriteEffects.None, drawLayer);
        }
    }
}
