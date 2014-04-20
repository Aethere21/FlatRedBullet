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
	public partial class PlayerBullet
	{

        DrawableBatchControl control = new DrawableBatchControl();
        ModelDrawableBatch model = new ModelDrawableBatch("Content/GlobalContent/Models/BulletModel", true);
        AxisAlignedCube collisionCube = new AxisAlignedCube();
		private void CustomInitialize()
		{
            control.LoadModel(model);

            model.CopyAbsoluteToRelative();
            model.AttachTo(collisionCube, false);

            collisionCube.ScaleX = 0.1f;
            collisionCube.ScaleY = 0.1f;
            collisionCube.ScaleZ = 0.1f;
            collisionCube.AttachTo(this, false);
		}

		private void CustomActivity()
		{
            model.Update();

            this.Velocity += this.RotationMatrix.Forward * 200;
		}

		private void CustomDestroy()
		{
            control.UnloadModel(model);
		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}
