using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    public class UserData
    {
        #region Singleton
        private static UserData instance;
        public static UserData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserData();
                }
                return instance;
            }
        }
        #endregion

        public Account Account { get; set; }
        public Heroe currentHero { get; set; }
    }
}
