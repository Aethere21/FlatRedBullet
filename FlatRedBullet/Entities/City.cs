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
using FlatRedBullet.DrawableBatches;
using Microsoft.Xna.Framework;

#endif
#endregion

namespace FlatRedBullet.Entities
{
	public partial class City
	{
        DrawableBatchControl control = new DrawableBatchControl();
        ModelDrawableBatch model = new ModelDrawableBatch("Content/GlobalContent/Models/CityModel", true);
        public List<AxisAlignedCube> collisionCubes = new List<AxisAlignedCube>();
		
        private void CustomInitialize()
		{
            control.LoadModel(model);
            collisionCubes = control.CreateCube(model, true, Color.Green);
		}

		private void CustomActivity()
		{
            LightControl();
            model.Update();
		}

		private void CustomDestroy()
		{
            control.UnloadModel(model);

		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void LightControl()
        {

        }
	}
}
