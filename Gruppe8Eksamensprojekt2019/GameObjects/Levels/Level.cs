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
        /// <param name="layer1"></param>
        /// <param name="size"></param>
        protected void GenerateLevel(int[,] layer1, float size)
        {
            for (int x = 0; x < layer1.GetLength(1); x++)
            {
                for (int y = 0; y < layer1.GetLength(0); y++)
                {
                    int coordinate = layer1[y, x];

                    switch (coordinate)
                    {
                        case (1):
                            {
                                GameObject newWall = new Wall(new Vector2(x * size, y * size));
                                GameWorld.collisionObjects.Add(newWall);
                                GameWorld.gameObjects.Add(newWall);
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
                                GameObject newSun = new Sun(new Vector2(x * size, y * size));
                                GameWorld.collisionObjects.Add(newSun);
                                GameWorld.gameObjects.Add(newSun);
                                break;
                            }

                        case (4):
                            {
                                GameObject newSunRay = new SunRay(new Vector2(x * size, y * size));
                                GameWorld.collisionObjects.Add(newSunRay);
                                GameWorld.gameObjects.Add(newSunRay);
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
                                GameObject newEnemy = new Enemy(new Vector2(x * size, y * size));
                                GameWorld.collisionObjects.Add(newEnemy);
                                GameWorld.gameObjects.Add(newEnemy);
                                break;
                            }

                        case (9):
                            {
                                GameObject newVase = new Vase(new Vector2(x * size, y * size));
                                GameWorld.collisionObjects.Add(newVase);
                                GameWorld.gameObjects.Add(newVase);
                                break;
                            }

                        case (10):
                            {
                                //GameWorld.gameObjects.Add(new);
                                break;
                            }

                        case (11):
                            {
                                GameWorld.gameObjects.Add(new Door("Door2", new Vector2(x * size, y * size), true));
                                break;
                            }
                    }
                }
            }

            //for (int x = 0; x < layer2.GetLength(1); x++)
            //{
            //    for (int y = 0; y < layer2.GetLength(0); y++)
            //    {
            //        int coordinate = layer2[y, x];

            //        switch (coordinate)
            //        {
            //            case (1):
            //                {
            //                    GameObject newWall = new Wall(new Vector2(x * size, y * size));
            //                    GameWorld.gameObjects.Add(newWall);
            //                    break;
            //                }

                        

            //            case (3):
            //                {
            //                    GameWorld.gameObjects.Add(new Sun(new Vector2(x * size, y * size)));
            //                    break;
            //                }

                       
            //        }
            //    }
            //}
        }
    }
}
