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
        public virtual void GenerateLevel(int[,] level, int size)
        {
           
        }
    }
}
