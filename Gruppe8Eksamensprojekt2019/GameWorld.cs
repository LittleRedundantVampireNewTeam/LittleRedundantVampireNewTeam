﻿using Microsoft.Xna.Framework;
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
        private List<GameObject> newObjects = new List<GameObject>();
        private List<GameObject> deleteObjects = new List<GameObject>();

        private Song currentMusic;
        private byte currentLevel;
        protected Texture2D collisionTexture;

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

            gameObjects.Add(new Player(new Vector2(0, 0)));
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

            foreach (GameObject gO in gameObjects)
            {
                gO.LoadContent(Content);
            }

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

            // TODO: Add your update logic here
            foreach (GameObject gO in gameObjects)
            {
                gO.Update(gameTime);

                if (gO.HasShadow == false && gO.GiveShadow == true)
                {
                    newObjects.Add(new Shadow(gO.Sprite, new Vector2(gO.Position.X, gO.Position.Y+32)));
                    gO.HasShadow = true;
                }
                else
                {
                    
                }
            }


            gameObjects.AddRange(newObjects);

            newObjects.Clear();

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
            spriteBatch.Begin(SpriteSortMode.BackToFront);

            foreach (GameObject gO in gameObjects)
            {
                gO.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawCollisionBox(GameObject gameObject)
        {

        }
    }
}
