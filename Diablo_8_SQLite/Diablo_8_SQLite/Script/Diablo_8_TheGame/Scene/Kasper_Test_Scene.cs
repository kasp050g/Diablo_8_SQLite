using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using MonogameFramework;
using Script.Generics;
using SQLiteFramework.Framework;
using SQLiteFramework.Interfaces;

namespace Diablo_8_SQLite
{
    public class Kasper_Test_Scene : Scene
    {
        private ShowStatsUI showStatsUI = new ShowStatsUI();
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Initialize()
        {
            base.Initialize();
            MouseSettings.Instance.IsMouseVisible(true);
            showStatsUI.MakeUI(this);
        }

        public override void OnSwitchAwayFromThisScene()
        {
            base.OnSwitchAwayFromThisScene();
        }

        public override void OnSwitchToThisScene()
        {
            base.OnSwitchToThisScene();
        }

        public override void Update()
        {
            base.Update();

        }
    }
}
