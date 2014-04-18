using System;
using System.Collections.Generic;
using System.Text;

namespace FlatRedBullet.Performance
{

    public interface IPoolable
    {
        int Index
        {
            get;
            set;
        }



        bool Used
        {
            get;
            set;
        }
    }
}
