using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
    class Boss : Character
    {
        public Boss(string name, int health, Vector2 position)
        {

        }

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {

        }

        //protected override void UpdateHealth(int health, int amount)
        //{

        //}

        protected override void Attack(GameTime gameTime)
        {

        }

        protected override void UseAbility(AbilityType ability)
        {

        }

        protected override void Speak()
        {

        }
    }
}
