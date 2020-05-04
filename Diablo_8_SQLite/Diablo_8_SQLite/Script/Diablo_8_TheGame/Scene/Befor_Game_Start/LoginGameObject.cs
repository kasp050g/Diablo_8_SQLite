using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameFramework;
using Script.Generics;
using SQLiteFramework.Framework;
using SQLiteFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    public class LoginGameObject
    {
        private MakeUserGameObject makeUserGameObject;
        private HeroPick heroPick;

        private GameObject mainGameObject = new GameObject();
        private Scene myScene;

        private GameObject emailInput = new GameObject();
        private SpriteRenderer sr01;
        private InputFieldGUI if01;

        private GameObject passwordInput = new GameObject();
        private SpriteRenderer sr02;
        private InputFieldGUI if02;

        private GameObject loginButton = new GameObject();
        private SpriteRenderer sr03;
        private ButtonGUI buttonGUI03;

        private GameObject errorMessage = new GameObject();
        private TextGUI textGUI04;

        private GameObject goToMakeUser = new GameObject();
        private SpriteRenderer sr05;
        private ButtonGUI buttonGUI05;

        public MakeUserGameObject MakeUserGameObject { get => makeUserGameObject; set => makeUserGameObject = value; }
        public GameObject MainGameObject { get => mainGameObject; set => mainGameObject = value; }
        public HeroPick HeroPick { get => heroPick; set => heroPick = value; }

        public LoginGameObject()
        {

        }
        public void MakeUI(Scene scene)
        {
            myScene = scene;
            // --- Main GameObject



            // --- Email Input
            // Make Components
            sr01 = new SpriteRenderer();
            if01 = new InputFieldGUI
                (
                sr01,
                SpriteContainer.Instance.sprite["Pixel"],
                Color.White,
                SpriteContainer.Instance.normalFont,
                Color.Black,
                new Vector2(1, 1),
                "Email"
                );
            // Add the Components
            emailInput.AddComponent<SpriteRenderer>(sr01);
            emailInput.AddComponent<InputFieldGUI>(if01);
            // Modify Components
            emailInput.MyParent = mainGameObject;
            sr01.OriginPositionEnum = OriginPositionEnum.Mid;
            sr01.LayerDepth = 0.1f;
            emailInput.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 200 * GraphicsSetting.Instance.ScreenScale.X);
            emailInput.Transform.Scale = new Vector2(500 * GraphicsSetting.Instance.ScreenScale.X, 100 * GraphicsSetting.Instance.ScreenScale.Y);


            // --- Email Input
            // Make Components
            sr02 = new SpriteRenderer();
            if02 = new InputFieldGUI
               (
               sr02,
               SpriteContainer.Instance.sprite["Pixel"],
               Color.White,
               SpriteContainer.Instance.normalFont,
               Color.Black,
               new Vector2(1, 1),
               "Password"
               );
            // Add the Components
            passwordInput.AddComponent<SpriteRenderer>(sr02);
            passwordInput.AddComponent<InputFieldGUI>(if02);
            // Modify Components
            passwordInput.MyParent = mainGameObject;
            sr02.OriginPositionEnum = OriginPositionEnum.Mid;
            sr02.LayerDepth = 0.1f;
            passwordInput.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 350 * GraphicsSetting.Instance.ScreenScale.X);
            passwordInput.Transform.Scale = new Vector2(500 * GraphicsSetting.Instance.ScreenScale.X, 100 * GraphicsSetting.Instance.ScreenScale.Y);

            // --- Login Button
            // Make Components
            sr03 = new SpriteRenderer();
            buttonGUI03 = new ButtonGUI
               (
               sr03,
               SpriteContainer.Instance.sprite["Pixel"],
               SpriteContainer.Instance.sprite["Pixel"],
               Color.White,
               Color.Gray,
               SpriteContainer.Instance.normalFont,
               Color.Black,
               new Vector2(0.5f, 0.5f),
               "Login"
               );
            // Add the Components
            loginButton.AddComponent<SpriteRenderer>(sr03);
            loginButton.AddComponent<ButtonGUI>(buttonGUI03);
            // Modify Components
            loginButton.MyParent = mainGameObject;
            sr03.OriginPositionEnum = OriginPositionEnum.Mid;
            sr03.LayerDepth = 0.1f;
            loginButton.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 500 * GraphicsSetting.Instance.ScreenScale.X);
            loginButton.Transform.Scale = new Vector2(200 * GraphicsSetting.Instance.ScreenScale.X, 50 * GraphicsSetting.Instance.ScreenScale.Y);
            buttonGUI03.OnClick += () => { ClickOnLogin(); };

            // --- Error Message
            // Error Message
            textGUI04 = new TextGUI
               (
               SpriteContainer.Instance.normalFont,
               Color.Red,
               new Vector2(0.5f * GraphicsSetting.Instance.ScreenScale.X, 0.5f * GraphicsSetting.Instance.ScreenScale.Y),
               "Error: no user fount with that email / password"
               );
            // Add the Components
            errorMessage.AddComponent<TextGUI>(textGUI04);
            // Modify Components
            errorMessage.MyParent = mainGameObject;
            errorMessage.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 430 * GraphicsSetting.Instance.ScreenScale.X);
            textGUI04.OriginPositionEnum = OriginPositionEnum.TopMid;
            textGUI04.LayerDepth = 0.1f;
            errorMessage.IsActive = false;

            // --- Go to user Button
            // Make Components
            sr05 = new SpriteRenderer();
            buttonGUI05 = new ButtonGUI
               (
               sr05,
               SpriteContainer.Instance.sprite["Pixel"],
               SpriteContainer.Instance.sprite["Pixel"],
               Color.White,
               Color.Gray,
               SpriteContainer.Instance.normalFont,
               Color.Black,
               new Vector2(0.4f, 0.4f),
               "Make new user"
               );
            // Add the Components
            goToMakeUser.AddComponent<SpriteRenderer>(sr05);
            goToMakeUser.AddComponent<ButtonGUI>(buttonGUI05);
            // Modify Components
            goToMakeUser.MyParent = mainGameObject;
            sr05.OriginPositionEnum = OriginPositionEnum.Mid;
            sr05.LayerDepth = 0.1f;
            goToMakeUser.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 600 * GraphicsSetting.Instance.ScreenScale.X);
            goToMakeUser.Transform.Scale = new Vector2(250 * GraphicsSetting.Instance.ScreenScale.X, 30 * GraphicsSetting.Instance.ScreenScale.Y);
            // TODO : make it go to make user
            buttonGUI05.OnClick = () => { GoToMakeUser(); };

            scene.Instantiate(mainGameObject);
            scene.Instantiate(emailInput);
            scene.Instantiate(passwordInput);
            scene.Instantiate(loginButton);
            scene.Instantiate(errorMessage);
            scene.Instantiate(goToMakeUser);
        }

        public void ClickOnLogin()
        {
            errorMessage.IsActive = false;
            textGUI04.FontColor = Color.Red;
            textGUI04.Text = "Error: no user fount with that email / password";

            IRowElement user = Singletons.TableContainerSingleton.UsersTable.FindRow("Email", if01.Text);

            if (user != null)
            {
                if (user.RowElementVariables["Password"] == if02.Text)
                {
                    errorMessage.IsActive = false;
                    Account acc = new Account();
                    acc.Id = user.Id;
                    acc.Name = user.RowElementVariables["Name"];
                    acc.Email = user.RowElementVariables["Email"];

                    UserData.Instance.Account = acc;
                    // TODO: Pick Hero UI
                    heroPick.MainGameObject.IsActive = true;
                    heroPick.MakeAllHeros();
                    mainGameObject.IsActive = false;
                }
                else
                {
                    errorMessage.IsActive = true;
                }
            }
            else
            {
                errorMessage.IsActive = true;
            }

        }

        void GoToMakeUser()
        {
            mainGameObject.IsActive = false;
            makeUserGameObject.MainGameObject.IsActive = true;
        }

        public void UserWasMade()
        {
            textGUI04.FontColor = Color.GreenYellow;
            textGUI04.Text = "Your ACC was made now login";
            errorMessage.IsActive = true;
        }
    }
}
