using SQLiteFramework.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script.Generics
{
    /// <summary>
    /// Contains all Singletons.
    /// </summary>
    public static class Singletons
    {
        public static TableContainer TableContainerSingleton = Singleton<TableContainer>.Instance;
    }
}
