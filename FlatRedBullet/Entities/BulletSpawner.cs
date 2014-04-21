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
using FlatRedBullet.DrawableBatches;

#endif
#endregion

namespace FlatRedBullet.Entities
{
	public partial class BulletSpawner
	{
        DrawableBatchControl control = new DrawableBatchControl();
        ModelDrawableBatch model = new ModelDrawableBatch("Content/GlobalContent/Models/BulletModel", false);

        AxisAlignedCube spawnCube = new AxisAlignedCube();
		private void CustomInitialize()
		{
            control.LoadModel(model);

            model.CopyAbsoluteToRelative();
            model.AttachTo(spawnCube, false);
            spawnCube.ScaleX = 0.5f;
            spawnCube.ScaleY = 0.5f;
            spawnCube.ScaleZ = 0.5f;
            spawnCube.CopyAbsoluteToRelative();
            spawnCube.AttachTo(this, false);
		}

        private void CustomActivity()
        {
            if (InputManager.Mouse.ButtonReleased(Mouse.MouseButtons.LeftButton))
            {
                Entities.PlayerBullet bullet = new Entities.PlayerBullet();
                bullet.RotationMatrix = Matrix.CreateFromAxisAngle(new Vector3(0, 1, 0), this.RotationY);
                bullet.Position.Y = this.Position.Y + 1f;
                bullet.Position.X = this.Position.X;
                bullet.Position.Z = this.Position.Z;
                Factories.PlayerBulletFactory.ScreenListReference.Add(bullet);
                GlobalContent.Shoot.Play(0.65f, 0, 0);
            }
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
