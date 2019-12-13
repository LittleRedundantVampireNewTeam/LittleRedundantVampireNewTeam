using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppe8Eksamensprojekt2019
{
	class Camera
	{
		private Matrix cameraTransform;

		public Matrix CameraTransform
		{
			get { return cameraTransform; }
		}

		public void FollowTarget(Character target)
		{
			cameraTransform = Matrix.CreateTranslation(-target.Position.X-(target.Sprite.Width), -target.Position.Y-(target.Sprite.Height),0) * Matrix.CreateTranslation(GameWorld.ScreenWidth/2,GameWorld.ScreenHeight/2,0);
		}
	}
}
