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

using FlatRedBall.Graphics.Model;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
using FlatRedBall.Localization;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
#endif
#endregion

namespace FlatRedBullet.Screens
{
	public partial class GameScreen
	{
        DrawableBatches.GuiDrawableBatch gui = new DrawableBatches.GuiDrawableBatch();

		void CustomInitialize()
		{
            SetUpCamera(false);
            FlatRedBallServices.Game.IsMouseVisible = false;

            SpriteManager.AddZBufferedDrawableBatch(gui);
            SpriteManager.AddPositionedObject(gui);

            SetUpGun();
		}

        void CustomActivity(bool firstTimeCalled)
        {
            if (FlatRedBallServices.Game.IsActive)
            {
                CameraActivity();

                FlatRedBall.Debugging.Debugger.Write("Gun Pos: " + GunInstance.RelativePosition + "\nGunRotationX: " + GunInstance.RelativeRotationX + "\nRY: " + GunInstance.RelativeRotationY + "\nRZ: " + GunInstance.RelativeRotationZ);
            }

            CollisionActivity();
        }

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void CollisionActivity()
        {
            foreach (AxisAlignedCube cube in CityInstance.collisionCubes)
            {
                PlayerInstance.collisionCube.CollideAgainstMove(cube, 0, 1);
            }
        }

        private void SetUpGun()
        {
            GunInstance.AttachTo(Camera.Main, true);

            GunInstance.RelativeRotationY = 1.6f;

            GunInstance.RelativePosition.Y = -2;
            GunInstance.RelativePosition.Z = -10.5f;
        }
	}
}
