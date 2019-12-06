using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
    // Enums for setting objects in levels.
    // S = Sun
    // R = Ray(sunray)
    // W = Wall
    // D = Door
    // P = Player
    // C = Crate
    // V = Vase
    // K = Key
    // E = Enemy
    // T = Treasure



    abstract class Level : GameObject
    {
        protected Song levelMusic;
        protected List<GameObject> levelList;
        protected Texture2D background;


        protected abstract void ChangeLevel();

        protected abstract void LevelSetup();

        /// <summary>
        /// Adds objects to the world from the 2d level array
        /// </summary>
        /// <param name="level"></param>
        /// <param name="size"></param>
        protected void GenerateLevel(int[,] level, int size)
        {
            for (int x = 0; x < level.GetLength(1); x++)
            {
                for (int y = 0; y < level.GetLength(0); y++)
                {
                    int coordinate = level[y, x];

                    switch (coordinate)
                    {
                        case (1):
                            {
                                GameWorld.gameObjects.Add(new Wall(new Vector2(x * size, y * size)));
                                break;
                            }

                        case (2):
                            {
                                GameObject newCrate = new Crate(new Vector2(x * size, y * size));
                                GameWorld.collisionObjects.Add(newCrate);
                                GameWorld.gameObjects.Add(newCrate);
                                break;
                            }

                        case (3):
                            {
                                GameWorld.gameObjects.Add(new Sun(new Vector2(x * size, y * size)));
                                break;
                            }

                        case (4):
                            {
                                GameWorld.gameObjects.Add(new SunRay(new Vector2(x * size, y * size)));
                                break;
                            }

                        case (5):
                            {
                                GameWorld.gameObjects.Add(new Door("Door1", new Vector2(x * size, y * size), true));
                                break;
                            }

                        case (6):
                            {
                                GameWorld.gameObjects.Add(new Key("Key1", new Vector2(x * size, y * size)));
                                break;
                            }

                        case (7):
                            {
                                GameWorld.gameObjects.Add(new Chest(new Vector2(x * size, y * size)));
                                break;
                            }

                        case (8):
                            {
                                GameWorld.gameObjects.Add(new Enemy(new Vector2(x * size, y * size)));
                                break;
                            }

                        case (9):
                            {
                                GameWorld.gameObjects.Add(new Vase(new Vector2(x * size, y * size)));
                                break;
                            }

						//case (10):
						//	{
						//		GameWorld.gameObjects.Add(new);
						//		break;
						//	}

                        case (11):
                            {
                                GameWorld.gameObjects.Add(new Door("Door2", new Vector2(x * size, y * size), true));
                                break;
                            }
                    }
                }
            }
        }
    }
}
