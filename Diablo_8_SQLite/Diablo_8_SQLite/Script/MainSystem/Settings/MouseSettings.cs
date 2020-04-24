using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public MonogameSystem monogameSystem;
        public bool isMouseVisible;

        public void IsMouseVisible(bool showMouse)
        {
            monogameSystem.IsMouseVisible = showMouse;
            isMouseVisible = showMouse;
        }
    }
}
