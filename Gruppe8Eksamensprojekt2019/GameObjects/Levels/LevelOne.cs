using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Gruppe8Eksamensprojekt2019
{
	class LevelOne : Level
	{
        // 0 = Null *
        // 1 = Wall *
        // 2 = Crate *
        // 3 = Sun *
        // 4 = Sunrays *
        // 5 = Door1v1 *
        // 6 = Key *
        // 7 = Chest *
        // 8 = Enemy *
        // 9 = Vase *
        // 10 = Player *
        // 11 = Door1v2 *

        public LevelOne()
        {

            GameObject newSunRay = new SunRay(new Vector2(19 * 96* GameWorld.Scale, 13 * 96* GameWorld.Scale));
            GameWorld.collisionObjects.Add(newSunRay);
            GameWorld.gameObjects.Add(newSunRay);

            GameObject newSunRay1 = new SunRay(new Vector2(31 * 96 * GameWorld.Scale, 12 * 96* GameWorld.Scale));
            GameWorld.collisionObjects.Add(newSunRay1);
            GameWorld.gameObjects.Add(newSunRay1);

            GameObject newSunRay2 = new SunRay(new Vector2(39 * 96* GameWorld.Scale, 14 * 96* GameWorld.Scale));
            GameWorld.collisionObjects.Add(newSunRay2);
            GameWorld.gameObjects.Add(newSunRay2);

            GameObject newSunRay3 = new SunRay(new Vector2(23 * 96* GameWorld.Scale, 14 * 96* GameWorld.Scale));
            GameWorld.collisionObjects.Add(newSunRay3);
            GameWorld.gameObjects.Add(newSunRay3);

            GameObject newSunRay4 = new SunRay(new Vector2(30 * 96* GameWorld.Scale, 17 * 96* GameWorld.Scale));
            GameWorld.collisionObjects.Add(newSunRay4);
            GameWorld.gameObjects.Add(newSunRay4);




            GenerateLevel(new int[,]
            {

                {0,0,0,0,1,1,3,3,1,1,3,3,1,1,3,3,1,1,3,3,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,0,4,4,0,0,4,4,0,0,4,4,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,0,0,0,1,0,4,4,0,0,4,4,0,0,4,4,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,0,0,0,11,0,1,1,0,0,4,4,0,0,4,4,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,0,0,0,1,0,0,0,0,0,4,4,0,0,4,4,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,0,0,0,0,0,4,4,0,0,4,4,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,1,0,0,0,0,0,4,4,0,0,1,1,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,1,0,0,0,0,0,4,4,0,0,0,0,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,1,0,0,0,0,0,4,4,0,0,0,0,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,1,0,0,0,0,0,1,1,0,0,0,0,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,0,1,3,3,1,1,3,3,1,1,3,3,1,1,3,3,1,1,3,3,1,1,1},
                {0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,4,4,0,0,4,4,0,0,4,4,0,0,4,4,1,0,4,4,9,9,4,4,0,6,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,4,4,0,2,4,4,2,0,4,4,0,0,4,2,1,9,1,1,0,0,4,4,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,4,2,0,0,4,4,0,0,4,4,0,0,4,4,0,0,0,0,0,0,4,4,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,2,4,4,0,0,4,2,0,0,4,4,0,0,4,4,0,0,0,0,0,0,4,8,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,2,4,4,0,0,4,4,0,0,4,4,0,0,4,4,1,0,0,0,0,0,4,4,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,4,4,0,0,4,4,0,0,4,4,0,0,4,4,1,0,9,9,0,0,4,4,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,4,4,0,0,4,4,0,0,4,4,0,0,2,4,1,0,9,9,0,0,1,1,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,4,4,0,0,4,4,0,0,4,4,0,0,4,4,1,0,0,0,0,0,0,0,8,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,4,4,0,0,4,4,0,0,4,4,0,0,4,4,1,0,0,0,0,0,9,9,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,6,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,9,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,7,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,10,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,9,0,0,0,9,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1},

            },96 * GameWorld.Scale);
        }

        public override void GenerateLevel(int[,] level, int size)
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
                                break;
                            }

                        case (6):
                            {
                                Key newKey = new Key(new Vector2(x * size, y * size));
                                GameWorld.collisionObjects.Add(newKey);
                                GameWorld.gameObjects.Add(newKey);

                                Door newDoor = new Door(new Vector2(x * size, y * size), newKey);
                                Player.lockedDoors.Add(newDoor);
                                GameWorld.collisionObjects.Add(newDoor);
                                GameWorld.gameObjects.Add(newDoor);
                                break;
                            }

                        case (7):
                            {
                                GameObject newChest = new Chest(new Vector2(x * size, y * size));
                                GameWorld.collisionObjects.Add(newChest);
                                GameWorld.gameObjects.Add(newChest);
                                break;
                            }

                        case (8):
                            {
                                GameWorld.gameObjects.Add(new Enemy(new Vector2(x * size, y * size)));
                                break;
                            }

                        case (9):
                            {
                                GameObject newVase = new Vase(new Vector2(x * size, y * size));
                                GameWorld.collisionObjects.Add(newVase);
                                GameWorld.gameObjects.Add(newVase);
                                break;
                            }

                        //case (10):
                        //    {
                        //        Key.KeyTwo = new Key(new Vector2(x * size, y * size));
                        //        GameWorld.collisionObjects.Add(Key.KeyTwo);
                        //        GameWorld.gameObjects.Add(Key.KeyTwo);
                        //        //GameObject newKeyTwo = new Key(keyTwoName = "", new Vector2(x * size, y * size), keyPickedUp = false);
                        //        //GameWorld.collisionObjects.Add(newKeyTwo);
                        //        //GameWorld.gameObjects.Add(newKeyTwo);
                        //        break;
                        //    }

                        //case (11):
                        //    {
                        //        Door.DoorTwo = new Door(key: Key.KeyTwo, new Vector2(x * size, y * size), Door.doorLocked = true);
                        //        Player.lockedDoors.Add(Door.DoorTwo);
                        //        GameWorld.collisionObjects.Add(Door.DoorTwo);
                        //        GameWorld.gameObjects.Add(Door.DoorTwo);
                        //        //GameObject newDoorTwo = new Door(doorTwoName = "1.2", new Vector2(x * size, y * size), doorTwoLocked = true);
                        //        //GameWorld.collisionObjects.Add(newDoorTwo);
                        //        //GameWorld.gameObjects.Add(newDoorTwo);
                        //        break;
                        //    }
                    }
                }
            }
        }

        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        protected override void ChangeLevel()
		{

		}

		protected override void LevelSetup()
		{

		}

	}
}
