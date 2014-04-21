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
		public static Microsoft.Xna.Framework.Audio.SoundEffect PlayerDeath { get; set; }
		public static Microsoft.Xna.Framework.Audio.SoundEffect Shoot { get; set; }
		public static Microsoft.Xna.Framework.Audio.SoundEffect ZombieDeath { get; set; }
		public static Microsoft.Xna.Framework.Audio.SoundEffect PlayerHit { get; set; }
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "Crosshair":
					return Crosshair;
				case  "PlayerDeath":
					return PlayerDeath;
				case  "Shoot":
					return Shoot;
				case  "ZombieDeath":
					return ZombieDeath;
				case  "PlayerHit":
					return PlayerHit;
			}
			return null;
		}
		public static object GetFile (string memberName)
		{
			switch(memberName)
			{
				case  "Crosshair":
					return Crosshair;
				case  "PlayerDeath":
					return PlayerDeath;
				case  "Shoot":
					return Shoot;
				case  "ZombieDeath":
					return ZombieDeath;
				case  "PlayerHit":
					return PlayerHit;
			}
			return null;
		}
		public static bool IsInitialized { get; private set; }
		public static bool ShouldStopLoading { get; set; }
		static string ContentManagerName = "Global";
		public static void Initialize ()
		{
			
			Crosshair = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/globalcontent/textures/crosshair.png", ContentManagerName);
			PlayerDeath = FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/globalcontent/sounds/playerdeath", ContentManagerName);
			Shoot = FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/globalcontent/sounds/shoot", ContentManagerName);
			ZombieDeath = FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/globalcontent/sounds/zombiedeath", ContentManagerName);
			PlayerHit = FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/globalcontent/sounds/playerhit", ContentManagerName);
						IsInitialized = true;
		}
		public static void Reload (object whatToReload)
		{
		}
		
		
	}
}
