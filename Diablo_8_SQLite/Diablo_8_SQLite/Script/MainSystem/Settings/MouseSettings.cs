using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diablo_8_SQLite;

namespace MonogameFramework
{
    public class MouseSettings
    {
        #region Singleton
        private static MouseSettings instance;
        public static MouseSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MouseSettings();
                }
                return instance;
            }
        }
        #endregion

        public GameWorld gameWorld;
        public bool isMouseVisible;

        public void IsMouseVisible(bool showMouse)
        {
            gameWorld.IsMouseVisible = showMouse;
            isMouseVisible = showMouse;
        }
    }
}
