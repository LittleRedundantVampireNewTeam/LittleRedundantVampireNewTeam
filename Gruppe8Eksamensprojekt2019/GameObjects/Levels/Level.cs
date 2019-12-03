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

        protected void GenerateLevel(int[,] level, int size)
        {
            for (int x = 0; x < level.GetLength(1); x++)
            {
                for (int y = 0; y < level.GetLength(0); y++)
                {
                    int coordinate = level[y, x];

                    if (coordinate == 1)
                    {
                        GameWorld.gameObjects.Add(new Wall(new Vector2(x * size, y * size)));
                    }

                }
            }
        }
    }
}
