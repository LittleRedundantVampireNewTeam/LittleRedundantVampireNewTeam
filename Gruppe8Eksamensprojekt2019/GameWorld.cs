using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace Gruppe8Eksamensprojekt2019
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        //Graphics
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Lists
        private List<GameObject> playerAbilities = new List<GameObject>();
        public static List<GameObject> shadowObjects = new List<GameObject>();
        public static List<GameObject> gameObjects = new List<GameObject>();
        public static List<GameObject> collisionObjects = new List<GameObject>();
        private static List<GameObject> newObjects = new List<GameObject>();
        public static List<GameObject> newCollisionObjects = new List<GameObject>();
        private static List<GameObject> deleteObjects = new List<GameObject>();
		private static List<Enemy> enemies = new List<Enemy>();
        public static  List<UiHeart> UiHeartList = new List<UiHeart>();


        //Sound & Music
        private Song currentMusic;
        private byte chooseLevel = 1;

        //Textures
        private static Texture2D collisionTexture;
        private static Texture2D wallSprite;
        private static Texture2D sunRaySprite;
        private static Texture2D crateSprite;
        private static Texture2D sunSprite;
        private static Texture2D vaseSprite;
        private static Texture2D enemySprite;
        private static Texture2D uiHealthSprite;

        //Display
        public static int ScreenWidth;
        public static int ScreenHeight;

        public static float Scale;

        public static Color bgColor = new Color(40,40,40,255);
        private Camera camera;

        //Game
        private Player player;
        Level CurrentLevel;

        //GameWorld
        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        //Sprite Properties
        public static Texture2D WallSprite
        {
            get { return wallSprite; }
        }

        public static Texture2D UiHealthSprite
        {
            get { return uiHealthSprite; }
        }

        public static Texture2D EnemySprite
        {
            get { return enemySprite; }
        }


        public static Texture2D SunSprite
        {
            get { return sunSprite; }
        }
        public static Texture2D VaseSprite
        {
            get { return vaseSprite; }
        }


        public static Texture2D CrateSprite
        {
            get { return crateSprite; }
        }

        public static Texture2D SunRaySprite
        {
            get { return sunRaySprite; }
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
            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;

            Scale = ((1f / 1920f) * GraphicsDevice.DisplayMode.Width);

            player = new Player(new Vector2(400, 200));

            collisionObjects.Add(player);

            switch (chooseLevel)
            {
                case (1):
                    {
                        CurrentLevel = new LevelOne();
                        break;
                    }

                case (2):
                    {
                        CurrentLevel = new LevelTwo();
                        break;
                    }

            }

            gameObjects.Add(player);
            camera = new Camera();

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

            collisionTexture     = Content.Load<Texture2D>("collisionTexture");
            crateSprite          = Content.Load<Texture2D>("Crate3");
            wallSprite           = Content.Load<Texture2D>("StonewallBroken2");
            sunRaySprite         = Content.Load<Texture2D>("Sunlight2");
            sunSprite            = Content.Load<Texture2D>("WindowDark2");
            vaseSprite           = Content.Load<Texture2D>("vaseTexture");
            enemySprite          = Content.Load<Texture2D>("enemyTexture");
            uiHealthSprite       = Content.Load<Texture2D>("healthUI");

            currentMusic         = Content.Load<Song>("backgroundMusic");

            MediaPlayer.Play(currentMusic);
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = true;




            foreach (GameObject gO in gameObjects)
            {
                gO.LoadContent(Content);
                gO.ScaledWidth = (int)(gO.sprite.Width * Scale);
                gO.ScaledHeight = (int)(gO.sprite.Height * Scale);

                if (gO is Enemy)
				{
					enemies.Add((Enemy)gO);
				}
            }

            foreach (UiHeart hE in UiHeartList)
            {
                hE.LoadContent(Content);
                hE.ScaledWidth = (int)(hE.sprite.Width * Scale);
                hE.ScaledHeight = (int)(hE.sprite.Height * Scale);
            }
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
			
            //Closes game when pressing esc.
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            ToggleFullscreen();

            //Update camera
            camera.FollowTarget(player);

            //Add new objects to main object list
            gameObjects.AddRange(newObjects);
            collisionObjects.AddRange(newCollisionObjects);

            //Clear new & deleted object lists
            newObjects.Clear();
            newCollisionObjects.Clear();
            deleteObjects.Clear();

            int i = 0;

            foreach (UiHeart hE in UiHeartList)
            {
                //hE.Position = new Vector2(UiHeartList[i].Position.X + hE.Sprite.Width, hE.Position.Y);
                hE.Update(gameTime);
                hE.Position = new Vector2(hE.Position.X + (hE.Sprite.Width*i*Scale), hE.Position.Y-hE.Sprite.Height);
                i++;
            }

			//foreach (Enemy enemy in gameObjects)
			//{
			//	enemy.Update(player);
			//}

			foreach (Enemy enemy in enemies)
			{
				enemy.UpdateDistance(player);
			}

            foreach (GameObject gO in gameObjects)
            {
                //Calls the update method in every gameobject on the list
                gO.Update(gameTime);

                //Calls the CheckCollision method in every game object in the list
                foreach (GameObject other in collisionObjects)
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
                    GameObject newShadow = new Shadow(gO.Sprite, new Vector2(gO.Position.X, gO.Position.Y + gO.Sprite.Height), gO);

                    collisionObjects.Add(newShadow);
                    newObjects.Add(newShadow);

                    //Marks the gameobject instance with a 'HasShadow' to be checked later
                    gO.HasShadow = true;
                }


                //Checks if the gameobject has a shadow and if it should not have one
                if (gO.HasShadow == true && gO.GiveShadow == false)
                {
                    gO.HasShadow = false;
                }

                //Checks collision on gameobjects
                //foreach (GameObject other in gameObjects)
                //{
                //    gO.CheckCollision(other);
                //}
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                RestartGame();
            }

            foreach (GameObject gO in deleteObjects)
            {
                gameObjects.Remove(gO);
                collisionObjects.Remove(gO);
            }
            if (player.Health <= 0)
            {
                RestartGame();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: camera.CameraTransform);

            foreach (GameObject gO in gameObjects)
            {
                gO.Draw(spriteBatch);

                DrawCollisionBox(gO);
            }

            foreach(UiHeart hE in UiHeartList)
            {
                if(UiHeart.DrawHealthUI == true)
                {
                    hE.Draw(spriteBatch);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawCollisionBox(GameObject gameObject)
        {
            // Draws the collisionboxes.
            Rectangle collisionBox = gameObject.CollisionBox;

            Rectangle topLine      = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width * (int)Scale, 1);
            Rectangle bottomLine   = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height * (int)Scale, collisionBox.Width * (int)Scale, 1);
            Rectangle rightLine    = new Rectangle(collisionBox.X + collisionBox.Width * (int)Scale, collisionBox.Y, 1, collisionBox.Height * (int)Scale);
            Rectangle leftLine     = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height * (int)Scale);

            // Makes sure the collisionbox adjusts to each sprite.
            spriteBatch.Draw(collisionTexture, topLine,     null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine,  null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rightLine,   null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine,    null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

        public static void Instantiate(GameObject gO)
        {
            newObjects.Add(gO);

            if (gO is PlayerAttack)
            {
                newCollisionObjects.Add(gO);
            }
        }

        public static void Destroy(GameObject gO)
        {
            deleteObjects.Add(gO);
        }

        private void ToggleFullscreen()
        {
            KeyboardState keystate = Keyboard.GetState();

            //toggles fullscreen
            if (keystate.IsKeyDown(Keys.F11) && graphics.IsFullScreen == false)
            {
                graphics.IsFullScreen = true;
                graphics.ApplyChanges();
            }
            //toggles not fullscreen
            else if (keystate.IsKeyDown(Keys.F11) && graphics.IsFullScreen == true)
            {
                graphics.IsFullScreen = false;
                graphics.ApplyChanges();
            }
        }
        private void RestartGame()
        {
            foreach(GameObject gO in gameObjects)
            {
                deleteObjects.Add(gO);
            }

            foreach (GameObject gO in deleteObjects)
            {
                gameObjects.Remove(gO);
                collisionObjects.Remove(gO);
            }

            //Clear new & deleted object lists
            newObjects.Clear();
            newCollisionObjects.Clear();
            deleteObjects.Clear();
            UiHeartList.Clear();

            Console.Clear();
            //chooseLevel = 2;
            Initialize();
            LoadContent();
        }
    }
}
