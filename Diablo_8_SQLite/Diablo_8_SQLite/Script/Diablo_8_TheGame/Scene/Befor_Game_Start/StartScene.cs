using Diablo_8_SQLite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    public class StartScene : Scene
    {
        private LoginGameObject loginGame = new LoginGameObject();
        private MakeUserGameObject makeUser = new MakeUserGameObject();
        private HeroPick heroPick = new HeroPick();
        private MakeNewHero makeNewHero = new MakeNewHero();

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Initialize()
        {
            base.Initialize();
            MouseSettings.Instance.IsMouseVisible(true);

            loginGame.MakeUserGameObject = makeUser;
            loginGame.HeroPick = heroPick;
            makeUser.LoginGameObject = loginGame;
            makeNewHero.HeroPick = heroPick;
            heroPick.NewHero = makeNewHero;
            makeUser.MakeUI(this);
            loginGame.MakeUI(this);
            heroPick.MakeUI(this);
            makeNewHero.MakeUI(this);
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

        public void StartMenu()
        {

        }
    }
}
