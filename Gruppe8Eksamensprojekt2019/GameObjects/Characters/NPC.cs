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
    class NPC : Character
    {
        private SpriteFont dialog;
        private bool interactingWithPlayer;

        public NPC(string name, Vector2 position)
        {

        }

        protected override void Update(GameTime gameTime)
        {
            Move(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {
           
        }

        private void GivePrompt()
        {

        }

        protected override void Speak()
        {

        }

        protected override void OnCollision(GameObject other)
        {

        }

        protected void Push()
        {

        }
    }
}
