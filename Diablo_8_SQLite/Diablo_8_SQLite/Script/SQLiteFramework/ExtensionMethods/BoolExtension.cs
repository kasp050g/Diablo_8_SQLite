using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.ExtensionMethods
{
    static class BoolExtension
    {
        public static bool IntToBoolSQLite(this int x)
        {
            switch (x)
            {
                case 0:
                    return false;

                case 1:
                    return true;

                default:
                    throw new Exception($"Value is not a 1 or 0 - {nameof(x)} : {x}");
            }
        }

        public static int BoolToIntSQLite(this bool x)
        {
            switch (x)
            {
                case false:
                    return 0;

                case true:
                    return 1;

                default:
                    throw new Exception($"Input is not a boolean - {x.GetType()}");
            }
        }
    }
}
