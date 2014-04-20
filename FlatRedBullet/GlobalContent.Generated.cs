using System.Collections.Generic;
using System.Threading;
using FlatRedBall;
using FlatRedBall.Math.Geometry;
using FlatRedBall.ManagedSpriteGroups;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Utilities;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using FlatRedBall.Localization;

namespace FlatRedBullet
{
	public static partial class GlobalContent
	{
		
		public static Microsoft.Xna.Framework.Graphics.Texture2D Crosshair { get; set; }
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "Crosshair":
					return Crosshair;
			}
			return null;
		}
		public static object GetFile (string memberName)
		{
			switch(memberName)
			{
				case  "Crosshair":
					return Crosshair;
			}
			return null;
		}
		public static bool IsInitialized { get; private set; }
		public static bool ShouldStopLoading { get; set; }
		static string ContentManagerName = "Global";
		public static void Initialize ()
		{
			
			Crosshair = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/globalcontent/textures/crosshair.png", ContentManagerName);
						IsInitialized = true;
		}
		public static void Reload (object whatToReload)
		{
		}
		
		
	}
}
