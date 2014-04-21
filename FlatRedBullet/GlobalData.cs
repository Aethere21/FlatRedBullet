using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatRedBullet
{
    public class GlobalData
    {
        static PlayerData mPlayerData = new PlayerData();
        public static PlayerData PlayerData
        {
            get{return mPlayerData;}
        }
    }
}
