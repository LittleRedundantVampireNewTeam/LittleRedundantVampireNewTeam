using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
    class Key : GameObject
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public Key(Vector2 position, int ID)
        {
            base.position = position;
            iD = ID;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("keyTexture");
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}

