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
        LoginGameObject loginGame = new LoginGameObject();
        MakeUserGameObject makeUser = new MakeUserGameObject();
        HeroPick heroPick = new HeroPick();
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
            makeUser.MakeUI(this);
            loginGame.MakeUI(this);
            heroPick.MakeUI(this);
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
