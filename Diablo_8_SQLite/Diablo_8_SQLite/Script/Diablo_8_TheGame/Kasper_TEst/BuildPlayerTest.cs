using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonogameFramework;

namespace Diablo_8_SQLite
{
    public class BuildPlayerTest
    {
        #region Singleton
        private static BuildPlayerTest instance;
        public static BuildPlayerTest Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BuildPlayerTest();
                }
                return instance;
            }
        }
        #endregion

        public GameObject buildplayer()
        {
            GameObject go = new GameObject();

            go.AddComponent<KasperPlayer_Test>();
            SpriteRenderer sp = new SpriteRenderer("Pixel");
            go.AddComponent<SpriteRenderer>(sp);
            go.AddComponent<Collider>();
            go.Transform.Scale = new Microsoft.Xna.Framework.Vector2(50, 50);

            return go;
        }
    }
}
