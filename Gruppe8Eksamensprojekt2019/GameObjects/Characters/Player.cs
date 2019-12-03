using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
    class Player : Character
    {
        private int regeneration;
        private SoundEffect playerAttackSound;

        private Texture2D playerSprite; /// NEW

        private KeyboardState keyState; /// NEW

        public Player(string name, int health, Vector2 position)
        {

        }


        protected override void Update(GameTime gameTime)
        {
            Move(gameTime);
            HandleInput();
        }

        public override void LoadContent(ContentManager content)
        {
            playerSprite = content.Load<Texture2D>("playerTexture");
        }

        private void HandleInput()
        {
            velocity = Vector2.Zero;
            keyState = Keyboard.GetState();

            /// Controls/moves the player sprite.
            if (keyState.IsKeyDown(Keys.Right))
            {
                velocity.X = -3f;
            }
            if (keyState.IsKeyDown(Keys.Up))
            {
                velocity.X = +3f;
            }
            if (keyState.IsKeyDown(Keys.Left))
            {
                velocity.Y = -3f;
            }
            if (keyState.IsKeyDown(Keys.Down))
            {
                velocity.Y = +3f;
            }

            if (velocity != Vector2.Zero)
            {
                /// Ensures that the player sprite doesn't move faster if they hold down two move keys at the same time.
                velocity.Normalize();
            }
        }

        private void InvincibleTimer(GameTime gameTime)
        {

        }

        protected override void Attack()
        {

        }

        private void SuckAttack()
        {

        }

        protected override void UseAbility(AbilityType ability)
        {

        }

        private void UpdateInventory()
        {

        }

        protected override void OnCollision(GameObject other)
        {

        }
    }
}
