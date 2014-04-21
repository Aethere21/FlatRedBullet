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
	public partial class Enemy
	{
        DrawableBatchControl control = new DrawableBatchControl();
        ModelDrawableBatch model = new ModelDrawableBatch("Content/GlobalContent/Models/ZombieModel", true);
        public AxisAlignedCube cube = new AxisAlignedCube();

        public int health;

		private void CustomInitialize()
		{
            health = 100;
            control.LoadModel(model);
            model.AttachTo(cube, false);

            cube.AttachTo(this, false);
            cube.Visible = true;
            cube.Color = Color.Green;
            cube.ScaleX = 5;
            cube.ScaleY = 8;
            cube.ScaleZ = 4;
		}

		private void CustomActivity()
		{
            this.YVelocity = -20;
            if(this.health <= 0)
            {
                this.Destroy();
            }

            Vector3 directionToCenter = GlobalData.PlayerData.playerPosition - this.Position;
            directionToCenter.Normalize();
            this.RotationY = (float)Math.Atan2(directionToCenter.X, directionToCenter.Z) +(float)(Math.PI * 0.5f);
            this.Velocity.X = 20 * directionToCenter.X;
            this.Velocity.Z = 20 * directionToCenter.Z;

            model.Update();
		}

		private void CustomDestroy()
		{
            control.UnloadModel(model);
            cube.RemoveSelfFromListsBelongingTo();
		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}
