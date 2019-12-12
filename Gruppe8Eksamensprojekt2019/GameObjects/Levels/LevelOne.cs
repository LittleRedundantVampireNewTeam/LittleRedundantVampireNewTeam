﻿using System;
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
        // 5 = Door 1 *
        // 6 = Key *
        // 7 = Chest *
        // 8 = Enemy *
        // 9 = Vase *
        // 10 = Player *
        // 11 = Door 2 *

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
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,9,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,7,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,9,0,0,0,9,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1},

            },96 * GameWorld.Scale);
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
