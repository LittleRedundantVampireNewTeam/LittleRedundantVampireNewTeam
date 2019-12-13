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
    abstract class Level 
    {
        protected Song levelMusic;
        protected bool wtf = false;
        protected List<GameObject> levelList;
        protected Texture2D background;
        private List<Key> KeyList = new List<Key>();

        /// <summary>
        /// Adds objects to the world from the 2d level array
        /// </summary>
        /// <param name="layer1"></param>
        /// <param name="size"></param>
        protected void GenerateLevel(int[,] layer1, int[,] layer2, float size)
        {
            if (wtf == false)
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
                                    AddObj(newWall);
                                    break;
                                }

                            case (2):
                                {
                                    GameObject newCrate = new Crate(new Vector2(x * size, y * size));
                                    AddObj(newCrate);
                                    break;
                                }

                            case (3):
                                {
                                    GameObject newSun = new Sun(new Vector2(x * size, y * size));
                                    AddObj(newSun);
                                    break;
                                }

                            case (4):
                                {
                                    GameObject newSunRay = new SunRay(new Vector2(x * size, y * size));
                                    AddObj(newSunRay);
                                    break;
                                }

                            //case (5):
                            //    {
                            //        GameWorld.gameObjects.Add(new Door("Door1", new Vector2(x * size, y * size), true));
                            //        break;
                            //    }

                            //case (6):
                            //    {
                            //        GameWorld.gameObjects.Add(new Key("Key1", new Vector2(x * size, y * size)));
                            //        break;
                            //    }

                            case (7):
                                {
                                    GameObject newChest = new Chest(new Vector2(x * size, y * size));
                                    AddObj(newChest);
                                    break;
                                }

                            case (8):
                                {
                                    GameObject newEnemy = new Enemy(new Vector2(x * size, y * size));
                                    AddObj(newEnemy);
                                    break;
                                }

                            case (9):
                                {
                                    GameObject newVase = new Vase(new Vector2(x * size, y * size));
                                    AddObj(newVase);
                                    break;
                                }

                            case (10):
                                {
                                    Key newKeyA = new Key(new Vector2(x * size, y * size), 1);
                                    KeyList.Add(newKeyA);
                                    AddObj(newKeyA);
                                    break;
                                }

                            case (11):
                                {
                                    Key newKeyB = new Key(new Vector2(x * size, y * size), 2);
                                    KeyList.Add(newKeyB);
                                    AddObj(newKeyB);
                                    break;
                                }

                            case (12):
                                {
                                    Key newKeyC = new Key(new Vector2(x * size, y * size), 3);
                                    KeyList.Add(newKeyC);
                                    AddObj(newKeyC);
                                    break;
                                }
                            case (13):
                                {
                                    foreach (Key key in KeyList)
                                    {
                                        if (key.ID == 1)
                                        {
                                            Door newDoorA = new Door(new Vector2(x * size, y * size), key);
                                            AddObj(newDoorA);
                                        }
                                    }
                                    break;
                                }
                            case (14):
                                {
                                    foreach (Key key in KeyList)
                                    {
                                        if (key.ID == 2)
                                        {
                                            Door newDoorB = new Door(new Vector2(x * size, y * size), key);
                                            AddObj(newDoorB);
                                        }
                                    }
                                    break;
                                }
                            case (15):
                                {
                                    foreach (Key key in KeyList)
                                    {
                                        if (key.ID == 3)
                                        {
                                            Door newDoorC = new Door(new Vector2(x * size, y * size), key);
                                            AddObj(newDoorC);
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }


                for (int x = 0; x < layer2.GetLength(1); x++)
                {
                    for (int y = 0; y < layer2.GetLength(0); y++)
                    {
                        int coordinate = layer2[y, x];

                        switch (coordinate)
                        {
                            
                            case (1):
                                {

                                    GameWorld.decorationsObjects.Add(new Decoration(GameWorld.WallSprite, new Vector2(x * size, y * size)));
                                    break;
                                }

                            case (2):
                                {

                                    GameWorld.decorationsObjects.Add(new Decoration(GameWorld.BookshelfSprite, new Vector2(x * size, y * size)));
                                    break;
                                }

                            case (3):
                                {

                                    GameWorld.decorationsObjects.Add(new Decoration(GameWorld.SunSprite, new Vector2(x * size, y * size)));
                                    break;
                                }

                            case (4):
                                {

                                    GameWorld.decorationsObjects.Add(new Decoration(GameWorld.CarpetTexture, new Vector2(x * size, y * size)));
                                    break;
                                }

                            case (5):
                                {

                                    GameWorld.decorationsObjects.Add(new Decoration(GameWorld.CarpetSunTexture, new Vector2(x * size, y * size)));
                                    break;
                                }

                            case (6):
                                {

                                    GameWorld.decorationsObjects.Add(new Decoration(GameWorld.FloorboardTexture, new Vector2(x * size, y * size)));
                                    break;
                                }

                        }
                    }
                }
                wtf = true;
            }
        }
        private void AddObj(GameObject newObj)
        {
            GameWorld.collisionObjects.Add(newObj);
            GameWorld.gameObjects.Add(newObj);
        }
    }
}
