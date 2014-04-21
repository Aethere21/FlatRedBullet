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
using FlatRedBullet.DrawableBatches;
using Microsoft.Xna.Framework;
#endif
#endregion

namespace FlatRedBullet.Screens
{
	public partial class MenuScreen
	{
        DrawableBatchControl control = new DrawableBatchControl();
        ModelDrawableBatch startModel = new ModelDrawableBatch("Content/GlobalContent/Models/StartGameModel", true);
        ModelDrawableBatch exitModel = new ModelDrawableBatch("Content/GlobalContent/Models/ExitGameModel", true);
        ModelDrawableBatch arrowModel = new ModelDrawableBatch("Content/GlobalContent/Models/ArrowModel", true);

        private int selection = 0;

		void CustomInitialize()
		{
            control.LoadModel(startModel);
            control.LoadModel(exitModel);
            control.LoadModel(arrowModel);
            arrowModel.defaultLight = false;

            arrowModel.Position = new Vector3(-65, -36, -200);
            startModel.Position = new Vector3(-65, 0, -200);
            exitModel.Position = new Vector3(65, 5, -200);

            CameraSetup.ResetCamera(Camera.Main);
         
            Camera.Main.UpVector = new Vector3(0, 1, 0);
            Camera.Main.RotationX = 0;
            Camera.Main.RotationY = 0;
            Camera.Main.RotationZ = 0;
            Camera.Main.CameraCullMode = FlatRedBall.Graphics.CameraCullMode.None;
            Camera.Main.FarClipPlane = 5000.0f;
            Camera.Main.Position = new Vector3(8, 0, 40);
		}

		void CustomActivity(bool firstTimeCalled)
		{
            startModel.Update();
            exitModel.Update();
            arrowModel.Update();

            if(InputManager.Keyboard.KeyReleased(Keys.Left) || InputManager.Keyboard.KeyReleased(Keys.Down))
            {
                if(selection > 0)
                {
                    selection--;
                    GlobalContent.ChangeOption.Play();
                }
            }
            else if (InputManager.Keyboard.KeyReleased(Keys.Right) || InputManager.Keyboard.KeyReleased(Keys.Up))
            {
                if(selection < 1)
                {
                    selection++;
                    GlobalContent.ChangeOption.Play();
                }
            }

            if(selection == 0)
            {
                arrowModel.Position.X = -65;
                if (InputManager.Keyboard.KeyReleased(Keys.Enter) || InputManager.Keyboard.KeyReleased(Keys.Space))
                {
                    GlobalContent.Select.Play();
                    MoveToScreen(typeof(GameScreen));
                }
            }
            else if(selection == 1)
            {
                arrowModel.Position.X = 65;
                if (InputManager.Keyboard.KeyReleased(Keys.Enter) || InputManager.Keyboard.KeyReleased(Keys.Space))
                {
                    GlobalContent.Select.Play();
                    FlatRedBallServices.Game.Exit();
                }
            }

		}

		void CustomDestroy()
		{
            control.UnloadModel(startModel);
            control.UnloadModel(exitModel);
            control.UnloadModel(arrowModel);
		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

	}
}
