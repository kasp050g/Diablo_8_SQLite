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
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Initialize()
        {
            base.Initialize();
            MouseSettings.Instance.IsMouseVisible(true);
            //StartMenu();
            loginGame.MakeGameObjects(this);
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
            // Start Menu GameObject.
            GameObject startMenu = new GameObject();
            Instantiate(startMenu);

            // Start Game Button.
            GameObject startGame = new GameObject();
            SpriteRenderer srStart = startGame.AddComponent<SpriteRenderer>();
            srStart.OriginPositionEnum = OriginPositionEnum.Mid;
            ButtonGUI startButton = startGame.AddComponent<ButtonGUI>(new ButtonGUI
                (
                SpriteContainer.Instance.sprite["Pixel"],
                Color.White,
                Color.Red,
                new Vector2(1, 1),
                "Play Game"
                )
            {
                OnClick = () => { startMenu.IsActive = false; }
            });
            startGame.Transform.Scale = new Vector2(600, 100);
            startGame.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 150);
            startGame.MyParent = startMenu;

            Instantiate(startGame);

            GameObject go_login = new GameObject();
            SpriteRenderer sr_login = go_login.AddComponent<SpriteRenderer>();
            sr_login.OriginPositionEnum = OriginPositionEnum.Mid;
            InputFieldGUI inputFieldGUI = new InputFieldGUI
                (
                sr_login,
                SpriteContainer.Instance.sprite["Pixel"],
                Color.NavajoWhite,
                SpriteContainer.Instance.normalFont,
                Color.Black,
                new Vector2(1,1),
                "Name Here"
                );
            go_login.AddComponent<InputFieldGUI>(inputFieldGUI);
            go_login.Transform.Scale = new Vector2(600, 100);
            go_login.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 350);
            Instantiate(go_login);
        }
    }
}
