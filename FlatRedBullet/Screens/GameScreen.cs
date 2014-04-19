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

		void CustomInitialize()
		{
            SetUpCamera(false);
            FlatRedBallServices.Game.IsMouseVisible = false;
		}

        void CustomActivity(bool firstTimeCalled)
        {
            if (FlatRedBallServices.Game.IsActive)
            {
                CameraActivity();

                FlatRedBall.Debugging.Debugger.Write("Camera Position: " + Camera.Main.Position + "PlayerCube Position: " + PlayerInstance.collisionCube.Position);

            }
            foreach (AxisAlignedCube cube in CityInstance.collisionCubes)
            {
                PlayerInstance.collisionCube.CollideAgainstMove(cube, 0, 1);
            }
        }

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

	}
}
