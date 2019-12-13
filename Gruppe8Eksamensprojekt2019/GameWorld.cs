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
        //Graphics
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Lists
        private List<GameObject> playerAbilities = new List<GameObject>();
        public static List<GameObject> shadowObjects = new List<GameObject>();
        public static List<GameObject> gameObjects = new List<GameObject>();
        public static List<GameObject> collisionObjects = new List<GameObject>();
        private static List<GameObject> newObjects = new List<GameObject>();
        private static List<GameObject> deleteObjects = new List<GameObject>();

        //Sound & Music
        private Song currentMusic;
        private byte currentLevel;

        //Textures
        private static Texture2D collisionTexture;
        private static Texture2D wallSprite;
        private static Texture2D sunRaySprite;
        private static Texture2D crateSprite;
        private static Texture2D sunSprite;
        private static Texture2D vaseSprite;
        private static Texture2D enemySprite;

        //Display
        public static int screenWidth;
        public static int screenHeight;
        public static float scale;
        private Camera camera;
        
        //Game
        private Player player;
        Level levelOne;

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
            screenWidth = graphics.PreferredBackBufferWidth;
            screenHeight = graphics.PreferredBackBufferHeight;

            scale = ((1f / 1920f) * GraphicsDevice.DisplayMode.Width);

            player = new Player(new Vector2(1500, 1500));
            collisionObjects.Add(player);

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

            collisionTexture     = Content.Load<Texture2D>("collisionTexture");
            crateSprite          = Content.Load<Texture2D>("Crate3");
            wallSprite           = Content.Load<Texture2D>("StonewallBroken2");
            sunRaySprite         = Content.Load<Texture2D>("Sunlight2");
            sunSprite            = Content.Load<Texture2D>("WindowDark2");
            vaseSprite           = Content.Load<Texture2D>("vaseTexture");
            enemySprite          = Content.Load<Texture2D>("enemyTexture");

            gameObjects.Add(player);
            camera = new Camera();

            foreach (GameObject gO in gameObjects)
            {
                gO.LoadContent(Content);
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

            //Update camera
            camera.FollowTarget(player);

            //Add new objects to main object list
            gameObjects.AddRange(newObjects);

            //Clear new & deleted object lists
            newObjects.Clear();
            deleteObjects.Clear();


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

            foreach (GameObject gO in deleteObjects)
            {
                gameObjects.Remove(gO);
                collisionObjects.Remove(gO);
            }

            

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
            spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: camera.CameraTransform);

            foreach (GameObject gO in gameObjects)
            {
                gO.Draw(spriteBatch);

                DrawCollisionBox(gO);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawCollisionBox(GameObject gameObject)
        {
            // Draws the collisionboxes.
            Rectangle collisionBox = gameObject.CollisionBox;

            Rectangle topLine      = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine   = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine     = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

            // Makes sure the collisionbox adjusts to each sprite.
            spriteBatch.Draw(collisionTexture, topLine,     null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine,  null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rightLine,   null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine,    null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
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
