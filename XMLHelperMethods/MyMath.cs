using System;
using System.Collections.Generic;
using System.Text;

namespace DkoLib
{
    public static class MyMath
    {
        #region Methods
        public static int Mod(int x, int m)
        {
            // Code copied from a post in Stack Overflow by a user named ShreevatsaR
            int r = x % m;

            return r < 0 ? r + m : r; 
        }
        #endregion

    }
}
