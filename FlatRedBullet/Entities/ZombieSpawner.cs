#region Usings

using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Microsoft.Xna.Framework;

#endif
#endregion

namespace FlatRedBullet.Entities
{
	public partial class ZombieSpawner
	{
        //AxisAlignedCube debugCube = new AxisAlignedCube();
		private void CustomInitialize()
		{
            //debugCube.ScaleX = 10;
            //debugCube.ScaleY = 10;
            //debugCube.ScaleZ = 10;
            //debugCube.Visible = true;
            //debugCube.Color = Color.Green;
		}

		private void CustomActivity()
		{
          //debugCube.Position = this.Position;



		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}
