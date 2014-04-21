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

        double mLastSpawnTime;
        bool IsTimeToSpawn
        {
            get
            {
                float spawnFreguency = 1 / ZombieSpawnTime;
                return PauseAdjustedSecondsSince(mLastSpawnTime) > spawnFreguency;
            }
        }

        void CustomInitialize()
		{
            SetUpCamera(false);
            FlatRedBallServices.Game.IsMouseVisible = false;

            SpriteManager.AddZBufferedDrawableBatch(gui);
            SpriteManager.AddPositionedObject(gui);
            SetUpGun();
            SetUpSpawners();
		}

        void CustomActivity(bool firstTimeCalled)
        {
            if (FlatRedBallServices.Game.IsActive)
            {
                if (!gui.GameOver)
                {
                    CameraActivity();
                }
                if(IsTimeToSpawn)
                {
                    SpawnActivity();
                }
                this.ZombieSpawnTime += TimeManager.SecondDifference * this.SpawnRateIncrease;

                GlobalData.PlayerData.playerPosition = PlayerInstance.Position;
            }

            if (GlobalData.PlayerData.Health <= 0)
            {
                GlobalData.PlayerData.Health = 0;
                gui.GameOver = true;

                PlayerInstance.Position = new Vector3(10000, 1000, 1000);

                if(InputManager.Keyboard.KeyReleased(Keys.Enter))
                {
                    MoveToScreen(typeof(MenuScreen));
                }
                
            }

            CollisionActivity();
            //BulletActivity();
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

            for (int i = EnemyList.Count - 1; i >= 0; i--)
            {
                for (int x = PlayerBulletList.Count - 1; x >= 0; x--)
                {
                    if(PlayerBulletList[x].collisionCube.CollideAgainst(EnemyList[i].cube))
                    {
                        EnemyList[i].health -= 15;
                        PlayerBulletList[x].Destroy();
                    }
                }

                if(PlayerInstance.collisionCube.CollideAgainstMove(EnemyList[i].cube, 0, 1))
                {
                    if (!gui.GameOver)
                    {
                        GlobalData.PlayerData.Health -= 1;
                        GlobalContent.PlayerHit.Play(0.55f, 0, 0);
                    }
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

        //private void BulletActivity()
        //{
        //    BulletSpawnerInstance.RotationY = PlayerInstance.RotationY;
        //}

        private void SpawnActivity()
        {
            int randSpawner = FlatRedBallServices.Random.Next(0, ZombieSpawnerList.Count);
            Entities.Enemy zombie = new Entities.Enemy();
            zombie.Position = ZombieSpawnerList[randSpawner].Position;
            EnemyList.Add(zombie);
            mLastSpawnTime = PauseAdjustedCurrentTime;
        }
	}
}