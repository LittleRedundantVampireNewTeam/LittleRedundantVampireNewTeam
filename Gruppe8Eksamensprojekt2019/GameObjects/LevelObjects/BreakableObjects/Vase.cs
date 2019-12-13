using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Gruppe8Eksamensprojekt2019
{
    class Vase : BreakableObject
    {
        private SoundEffect vaseBreakSound;
        public Vase(Vector2 position)
        {
            base.position = position;
        }

        public override void Update(GameTime gameTime)
        {}

        protected override void OnCollision(GameObject other)
        {
			if (other is Crate || other is PlayerAttack)
            {
                Break();
            }
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = GameWorld.VaseSprite;
            vaseBreakSound = content.Load<SoundEffect>("vaseSound");
        }

        protected override void Break()
        {
            vaseBreakSound.Play();
            GameWorld.Destroy(this);
        }
    }
}
