using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.Generics
{
    public class Singleton<T>
    {
        private static T instance;
        private static readonly object threadLock = new object();

        public static T Instance
        {
            get
            {
                lock (threadLock)
                {
                    if (instance == null)
                        instance = (T)Activator.CreateInstance(typeof(T));

                    return instance;
                }
            }
        }
    }
}
