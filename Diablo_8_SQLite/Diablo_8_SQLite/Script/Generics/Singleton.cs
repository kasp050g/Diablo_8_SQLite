using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script.Generics
{
    public class Singleton<T> where T : class, new()
    {
        private static T instance = null;

        private static readonly object threadLock = new object();

        public static T Instance
        {
            get
            {
                lock (threadLock)
                {
                    if (instance == null)
                        instance = new T();

                    return instance;
                }
            }
        }
    }
}
