using FlatRedBullet.Entities;
using System;
using FlatRedBall.Math;
using FlatRedBall.Graphics;
using FlatRedBullet.Performance;

namespace FlatRedBullet.Factories
{
	public class EnemyFactory : IEntityFactory
	{
		public static Enemy CreateNew ()
		{
			return CreateNew(null);
		}
		public static Enemy CreateNew (Layer layer)
		{
			if (string.IsNullOrEmpty(mContentManagerName))
			{
				throw new System.Exception("You must first initialize the factory to use it.");
			}
			Enemy instance = null;
			instance = new Enemy(mContentManagerName, false);
			instance.AddToManagers(layer);
			if (mScreenListReference != null)
			{
				mScreenListReference.Add(instance);
			}
			if (EntitySpawned != null)
			{
				EntitySpawned(instance);
			}
			return instance;
		}
		
		public static void Initialize (PositionedObjectList<Enemy> listFromScreen, string contentManager)
		{
			mContentManagerName = contentManager;
			mScreenListReference = listFromScreen;
		}
		
		public static void Destroy ()
		{
			mContentManagerName = null;
			mScreenListReference = null;
			mPool.Clear();
			EntitySpawned = null;
		}
		
		private static void FactoryInitialize ()
		{
			const int numberToPreAllocate = 20;
			for (int i = 0; i < numberToPreAllocate; i++)
			{
				Enemy instance = new Enemy(mContentManagerName, false);
				mPool.AddToPool(instance);
			}
		}
		
		/// <summary>
		/// Makes the argument objectToMakeUnused marked as unused.  This method is generated to be used
		/// by generated code.  Use Destroy instead when writing custom code so that your code will behave
		/// the same whether your Entity is pooled or not.
		/// </summary>
		public static void MakeUnused (Enemy objectToMakeUnused)
		{
			MakeUnused(objectToMakeUnused, true);
		}
		
		/// <summary>
		/// Makes the argument objectToMakeUnused marked as unused.  This method is generated to be used
		/// by generated code.  Use Destroy instead when writing custom code so that your code will behave
		/// the same whether your Entity is pooled or not.
		/// </summary>
		public static void MakeUnused (Enemy objectToMakeUnused, bool callDestroy)
		{
			objectToMakeUnused.Destroy();
		}
		
		
			static string mContentManagerName;
			static PositionedObjectList<Enemy> mScreenListReference;
			static PoolList<Enemy> mPool = new PoolList<Enemy>();
			public static Action<Enemy> EntitySpawned;
			object IEntityFactory.CreateNew ()
			{
				return EnemyFactory.CreateNew();
			}
			object IEntityFactory.CreateNew (Layer layer)
			{
				return EnemyFactory.CreateNew(layer);
			}
			public static PositionedObjectList<Enemy> ScreenListReference
			{
				get
				{
					return mScreenListReference;
				}
				set
				{
					mScreenListReference = value;
				}
			}
			static EnemyFactory mSelf;
			public static EnemyFactory Self
			{
				get
				{
					if (mSelf == null)
					{
						mSelf = new EnemyFactory();
					}
					return mSelf;
				}
			}
	}
}
