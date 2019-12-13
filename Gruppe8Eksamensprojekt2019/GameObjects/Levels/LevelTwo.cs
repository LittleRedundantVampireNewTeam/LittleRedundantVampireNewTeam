using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
    class LevelTwo : Level
    {

        public LevelTwo()
        {
            GenerateLevel(new int[,]
            {

                {0,0,0,0,1,1,3,3,1,1,3,3,1,1,3,3},
                {1,1,1,1,1,0,4,4,0,0,4,4,0,0,4,4},
                {1,0,0,0,1,0,4,4,0,0,4,4,0,0,4,4},
                {1,0,0,0,1,0,1,1,0,0,4,4,0,0,4,4},
                {1,0,0,0,1,0,1,0,0,0,4,4,0,0,4,4},
                {1,1,1,1,1,0,1,1,1,1,4,4,1,1,4,4},
                {0,0,0,0,1,0,1,0,0,0,4,4,0,0,1,1},
                {0,0,0,0,1,0,1,0,0,0,4,4,0,0,0,0},
           

            }, new int[,]
            {

                {0,0,0,0,1,1,3,3,1,1,3,3,1,1,3,3},
                {1,1,1,1,1,0,4,4,0,0,4,4,0,0,4,4},
                {1,0,0,0,1,0,4,4,0,0,4,4,0,0,4,4},
                {1,0,0,0,1,0,1,1,0,0,4,4,0,0,4,4},
                {1,0,0,0,1,0,1,0,0,0,4,4,0,0,4,4},
                {1,1,1,1,1,0,1,1,1,1,4,4,1,1,4,4},
                {0,0,0,0,1,0,1,0,0,0,4,4,0,0,1,1},
                {0,0,0,0,1,0,1,0,0,0,4,4,0,0,0,0},


            }, 96 * (int)GameWorld.Scale);
        }

    }
}
