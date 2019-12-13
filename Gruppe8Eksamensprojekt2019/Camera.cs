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
			private set { value = cameraTransform; }
		}

		public void FollowTarget(Character target)
		{
			cameraTransform = Matrix.CreateTranslation(-target.Position.X-(target.Sprite.Width*GameWorld.scale), -target.Position.Y-(target.Sprite.Height*GameWorld.scale),0)
				* Matrix.CreateTranslation(GameWorld.screenWidth/2*GameWorld.scale,GameWorld.screenHeight/2,0*GameWorld.scale);
		}
	}
}
