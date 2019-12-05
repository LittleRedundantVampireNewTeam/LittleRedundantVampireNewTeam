using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace Gruppe8Eksamensprojekt2019
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<GameObject> playerAbilities = new List<GameObject>();
        public static List<GameObject> shadowObjects = new List<GameObject>();
        public static List<GameObject> gameObjects = new List<GameObject>();
        private static List<GameObject> newObjects = new List<GameObject>();
        private static List<GameObject> deleteObjects = new List<GameObject>();

        private Song currentMusic;
        private byte currentLevel;
        protected Texture2D collisionTexture;
		public static int ScreenWidth;
		public static int ScreenHeight;
		private Camera camera;
		private Player player;

		public static byte Scale;


		Level levelOne;

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.ApplyChanges();
			// TODO: Add your initialization logic here

			ScreenWidth = graphics.PreferredBackBufferWidth;
			ScreenHeight = graphics.PreferredBackBufferHeight;

			Scale = 1;

			player = new Player(new Vector2(200, 200));

            levelOne = new LevelOne();

            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
			gameObjects.Add(player);
			foreach (GameObject gO in gameObjects)
            {
                gO.LoadContent(Content);
            }

			camera = new Camera();

            collisionTexture = Content.Load<Texture2D>("collisionTexture");

            // TODO: use this.Content to load your game content here
        }


		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

      			gameObjects.AddRange(newObjects);

      			newObjects.Clear();
      			deleteObjects.Clear();

      			// TODO: Add your update logic here
      			foreach (GameObject gO in gameObjects)
            {
                //Calls the update method in every gameobject on the list
                gO.Update(gameTime);

                //Calls the CheckCollision method in every game object in the list
                foreach (GameObject other in gameObjects)
                {
                    gO.CheckCollision(other);
                }

                //Checks if the gameobject does not have a shadow and if it should have a shadow
                if (gO.HasShadow == false && gO.GiveShadow == true)
                {
                    /// <summary>
                    /// Adds a new shadow instance to the list newObjects so it can be added while the game is running.
                    /// The new shadow instance is created with the same sprite of the gameobject and assigns the gameobject as the parrent.
                    /// Also gives the shadow the position of the gameobject and offsets it to be placed under the gameobject.
                    /// </summary>
                    newObjects.Add(new Shadow(gO.Sprite, new Vector2(gO.Position.X, gO.Position.Y + gO.Sprite.Height), gO));

                    //Marks the gameobject instance with a 'HasShadow' to be checked later
                    gO.HasShadow = true;
                }
                //Checks if the gameobject has a shadow and if it should not have one
                if (gO.HasShadow == true && gO.GiveShadow == false)
                {
                    gO.HasShadow = false;
                }
				foreach (GameObject other in gameObjects)
				{
					gO.CheckCollision(other);
				}
			}

			foreach (GameObject gO in deleteObjects)
			{
				gameObjects.Remove(gO);
			}

            gameObjects.AddRange(newObjects);

            newObjects.Clear();

            camera.FollowTarget(player);

            foreach (GameObject gO in deleteObjects)
            {
                gameObjects.Remove(gO);
            }

            deleteObjects.Clear();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack,transformMatrix:camera.CameraTransform);

            foreach (GameObject gO in gameObjects)
            {
                gO.Draw(spriteBatch);

				//DrawCollisionBox(gO);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawCollisionBox(GameObject gameObject)
        {
            /// Draws the collisionboxes.
            Rectangle collisionBox = gameObject.CollisionBox;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width*Scale, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height*Scale, collisionBox.Width*Scale, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width*Scale, collisionBox.Y, 1, collisionBox.Height*Scale);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height*Scale);

            /// Makes sure the collisionbox adjusts to each sprite.
            spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

        public static void Instantiate(GameObject gO)
        {
            newObjects.Add(gO);
        }

        public static void Destroy(GameObject gO)
        {
            deleteObjects.Add(gO);
        }
    }
}
