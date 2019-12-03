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
        // 5 = Door *
        // 6 = Key *
        // 7 = Chest *
        // 8 = Enemy *
        // 9 = Vase * 
        // 10 = PLayer * 
   
       
        
        public LevelOne()
        {
            GenerateLevel(new int[,]
            {

                {0,0,0,0,1,1,3,3,1,1,3,3,1,1,3,3,1,1,3,3,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,0,4,4,0,0,4,4,0,0,4,4,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,0,0,0,1,0,4,4,0,0,4,4,0,0,4,4,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,0,0,0,5,0,1,1,0,0,4,4,0,0,4,4,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,0,0,0,1,10,0,0,0,0,4,4,0,0,4,4,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,0,0,0,0,0,4,4,0,0,4,4,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,1,0,0,0,0,0,4,4,0,0,1,1,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,1,0,0,0,0,0,4,4,0,0,0,0,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,1,0,0,0,0,0,4,4,0,0,0,0,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,1,0,0,0,0,0,1,1,0,0,0,0,0,0,4,4,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,0,1,3,3,1,1,3,3,1,1,3,3,1,1,3,3,1,1,3,3,1,1,1},
                {0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,4,4,0,0,4,4,0,0,4,4,0,0,4,4,1,0,4,4,9,9,4,4,0,6,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,4,4,0,2,4,4,2,0,4,4,0,0,4,2,1,0,1,1,0,0,4,4,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,4,2,0,0,4,4,0,0,4,4,0,0,4,4,0,0,0,0,0,0,4,4,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,2,4,4,0,0,4,4,0,0,4,4,0,0,4,4,0,0,0,0,0,0,4,8,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,2,4,4,0,0,4,4,0,0,4,4,0,0,4,4,1,0,0,0,0,0,4,4,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,4,4,0,0,4,4,0,0,4,4,0,0,4,4,1,0,9,9,0,0,4,4,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,4,4,0,0,4,4,0,0,4,4,0,0,4,4,1,0,9,9,0,0,1,1,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,4,4,0,0,4,4,0,0,4,4,0,0,4,4,1,0,0,0,0,0,0,0,8,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,4,4,0,0,4,4,0,0,4,4,0,0,4,4,1,0,0,0,0,0,9,9,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,9,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,7,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,9,0,0,0,9,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1},
 

            }, 32);
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
