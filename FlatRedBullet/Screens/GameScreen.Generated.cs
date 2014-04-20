using BitmapFont = FlatRedBall.Graphics.BitmapFont;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if XNA4 || WINDOWS_8
using Color = Microsoft.Xna.Framework.Color;
#elif FRB_MDX
using Color = System.Drawing.Color;
#else
using Color = Microsoft.Xna.Framework.Graphics.Color;
#endif

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Microsoft.Xna.Framework.Media;
#endif

// Generated Usings
using FlatRedBullet.Entities;
using FlatRedBullet.Factories;
using FlatRedBall;
using FlatRedBall.Screens;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Math;

namespace FlatRedBullet.Screens
{
	public partial class GameScreen : Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		
		private FlatRedBullet.Entities.City CityInstance;
		private PositionedObjectList<FlatRedBullet.Entities.Enemy> EnemyList;
		private PositionedObjectList<FlatRedBullet.Entities.PlayerBullet> PlayerBulletList;
		private FlatRedBullet.Entities.Player PlayerInstance;
		private FlatRedBullet.Entities.Gun GunInstance;

		public GameScreen()
			: base("GameScreen")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			CityInstance = new FlatRedBullet.Entities.City(ContentManagerName, false);
			CityInstance.Name = "CityInstance";
			EnemyList = new PositionedObjectList<FlatRedBullet.Entities.Enemy>();
			EnemyList.Name = "EnemyList";
			PlayerBulletList = new PositionedObjectList<FlatRedBullet.Entities.PlayerBullet>();
			PlayerBulletList.Name = "PlayerBulletList";
			PlayerInstance = new FlatRedBullet.Entities.Player(ContentManagerName, false);
			PlayerInstance.Name = "PlayerInstance";
			GunInstance = new FlatRedBullet.Entities.Gun(ContentManagerName, false);
			GunInstance.Name = "GunInstance";
			
			
			PostInitialize();
			base.Initialize(addToManagers);
			if (addToManagers)
			{
				AddToManagers();
			}

        }
        
// Generated AddToManagers
		public override void AddToManagers ()
		{
			PlayerBulletFactory.Initialize(PlayerBulletList, ContentManagerName);
			CityInstance.AddToManagers(mLayer);
			PlayerInstance.AddToManagers(mLayer);
			GunInstance.AddToManagers(mLayer);
			base.AddToManagers();
			AddToManagersBottomUp();
			CustomInitialize();
		}


		public override void Activity(bool firstTimeCalled)
		{
			// Generated Activity
			if (!IsPaused)
			{
				
				CityInstance.Activity();
				for (int i = EnemyList.Count - 1; i > -1; i--)
				{
					if (i < EnemyList.Count)
					{
						// We do the extra if-check because activity could destroy any number of entities
						EnemyList[i].Activity();
					}
				}
				for (int i = PlayerBulletList.Count - 1; i > -1; i--)
				{
					if (i < PlayerBulletList.Count)
					{
						// We do the extra if-check because activity could destroy any number of entities
						PlayerBulletList[i].Activity();
					}
				}
				PlayerInstance.Activity();
				GunInstance.Activity();
			}
			else
			{
			}
			base.Activity(firstTimeCalled);
			if (!IsActivityFinished)
			{
				CustomActivity(firstTimeCalled);
			}


				// After Custom Activity
				
            
		}

		public override void Destroy()
		{
			// Generated Destroy
			PlayerBulletFactory.Destroy();
			
			EnemyList.MakeOneWay();
			PlayerBulletList.MakeOneWay();
			if (CityInstance != null)
			{
				CityInstance.Destroy();
				CityInstance.Detach();
			}
			for (int i = EnemyList.Count - 1; i > -1; i--)
			{
				EnemyList[i].Destroy();
			}
			for (int i = PlayerBulletList.Count - 1; i > -1; i--)
			{
				PlayerBulletList[i].Destroy();
			}
			if (PlayerInstance != null)
			{
				PlayerInstance.Destroy();
				PlayerInstance.Detach();
			}
			if (GunInstance != null)
			{
				GunInstance.Destroy();
				GunInstance.Detach();
			}
			EnemyList.MakeTwoWay();
			PlayerBulletList.MakeTwoWay();

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			CameraSetup.ResetCamera(SpriteManager.Camera);
			AssignCustomVariables(false);
		}
		public virtual void RemoveFromManagers ()
		{
			CityInstance.RemoveFromManagers();
			for (int i = EnemyList.Count - 1; i > -1; i--)
			{
				EnemyList[i].Destroy();
			}
			for (int i = PlayerBulletList.Count - 1; i > -1; i--)
			{
				PlayerBulletList[i].Destroy();
			}
			PlayerInstance.RemoveFromManagers();
			GunInstance.RemoveFromManagers();
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
				CityInstance.AssignCustomVariables(true);
				PlayerInstance.AssignCustomVariables(true);
				GunInstance.AssignCustomVariables(true);
			}
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			CityInstance.ConvertToManuallyUpdated();
			for (int i = 0; i < EnemyList.Count; i++)
			{
				EnemyList[i].ConvertToManuallyUpdated();
			}
			for (int i = 0; i < PlayerBulletList.Count; i++)
			{
				PlayerBulletList[i].ConvertToManuallyUpdated();
			}
			PlayerInstance.ConvertToManuallyUpdated();
			GunInstance.ConvertToManuallyUpdated();
		}
		public static void LoadStaticContent (string contentManagerName)
		{
			if (string.IsNullOrEmpty(contentManagerName))
			{
				throw new ArgumentException("contentManagerName cannot be empty or null");
			}
			#if DEBUG
			if (contentManagerName == FlatRedBallServices.GlobalContentManager)
			{
				HasBeenLoadedWithGlobalContentManager = true;
			}
			else if (HasBeenLoadedWithGlobalContentManager)
			{
				throw new Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
			}
			#endif
			FlatRedBullet.Entities.City.LoadStaticContent(contentManagerName);
			FlatRedBullet.Entities.Player.LoadStaticContent(contentManagerName);
			FlatRedBullet.Entities.Gun.LoadStaticContent(contentManagerName);
			CustomLoadStaticContent(contentManagerName);
		}
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			return null;
		}
		public static object GetFile (string memberName)
		{
			return null;
		}
		object GetMember (string memberName)
		{
			return null;
		}


	}
}
