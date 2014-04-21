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
using Microsoft.Xna.Framework;
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
            ZombieSpawnActivity();

		}


        void CustomActivity(bool firstTimeCalled)
        {
            if (FlatRedBallServices.Game.IsActive)
            {
                CameraActivity();

                FlatRedBall.Debugging.Debugger.Write("SX: " + EnemyList[0].cube.ScaleX + "\nSY: " + EnemyList[0].cube.ScaleY + "\nSZ: " + EnemyList[0].cube.ScaleZ + "\nBulletAmmount: " + PlayerBulletList.Count + "\nZombie 1 Position: " + EnemyList[0].Position);
            }

            CollisionActivity();
            BulletActivity();
        }

		void CustomDestroy()
		{
            SpriteManager.RemoveDrawableBatch(gui);
            SpriteManager.RemovePositionedObject(gui);
		}

        static void CustomLoadStaticContent(string contentManagerName)
        {
        }

        private void CollisionActivity()
        {
            foreach (AxisAlignedCube cube in CityInstance.collisionCubes)
            {
                PlayerInstance.collisionCube.CollideAgainstMove(cube, 0, 1);
                for (int i = PlayerBulletList.Count - 1; i >= 0; i--)
                {
                    if(PlayerBulletList[i].collisionCube.CollideAgainst(cube))
                    {
                        PlayerBulletList[i].Destroy();
                    }
                }

                for (int i = EnemyList.Count - 1; i >= 0; i--)
                {
                    EnemyList[i].cube.CollideAgainstMove(cube, 0, 1);
                }
            }
        }

        private void SetUpGun()
        {
            GunInstance.AttachTo(Camera.Main, true);
            GunInstance.RelativeRotationY = 1.55f;
            GunInstance.RelativePosition.Y = -2;
            GunInstance.RelativePosition.Z = -10.5f;

            BulletSpawnerInstance.AttachTo(Camera.Main, true);
            BulletSpawnerInstance.RelativePosition.Y = -3.5f;
            BulletSpawnerInstance.RelativePosition.Z = -20f;
            BulletSpawnerInstance.RelativePosition.X = 2.5f;
        }

        private void BulletActivity()
        {
            BulletSpawnerInstance.RotationY = PlayerInstance.RotationY;
        }

        private void ZombieSpawnActivity()
        {

        }
	}
}