using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFramework
{
    public class Singleton
    {
        #region Singleton
        private static Singleton instance;
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        #endregion

        public SpriteContainer singletonEksempel01 = new SpriteContainer();
        public SpriteContainer singletonEksempel02 = new SpriteContainer();
        public SpriteContainer singletonEksempel03 = new SpriteContainer();
        public SpriteContainer singletonEksempel04 = new SpriteContainer();
        public SpriteContainer singletonEksempel05 = new SpriteContainer();


        
    }
}
