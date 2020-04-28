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
    public class LoginGameObject
    {
        GameObject mainGameObject = new GameObject();


        GameObject emailInput = new GameObject();
        SpriteRenderer sr01;
        InputFieldGUI if01;

        GameObject passwordInput = new GameObject();
        SpriteRenderer sr02;
        InputFieldGUI if02;

        GameObject loginButton = new GameObject();
        SpriteRenderer sr03;
        ButtonGUI buttonGUI03;

        GameObject errorMessage = new GameObject();
        TextGUI textGUI04;

        GameObject goToMakeUser = new GameObject();
        SpriteRenderer sr05;
        ButtonGUI buttonGUI05;

        public void MakeGameObjects(Scene scene)
        {
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
            emailInput.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 200);
            emailInput.Transform.Scale = new Vector2(500, 100);


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
            passwordInput.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 350);
            passwordInput.Transform.Scale = new Vector2(500, 100);

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
            loginButton.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 500);
            loginButton.Transform.Scale = new Vector2(200, 50);
            buttonGUI03.OnClick = () => { ClickOnLogin(); };

            // --- Error Message
            // Error Message
            textGUI04 = new TextGUI
               (
               SpriteContainer.Instance.normalFont,
               Color.Red,
               new Vector2(0.5f, 0.5f),
               "Error: no user fount with that email / password"
               );
            // Add the Components
            errorMessage.AddComponent<TextGUI>(textGUI04);
            // Modify Components
            errorMessage.MyParent = mainGameObject;
            errorMessage.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2 - 220, 430);
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
            goToMakeUser.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 600);
            goToMakeUser.Transform.Scale = new Vector2(250, 30);
            // TODO : make it go to make user
            //buttonGUI05.OnClick = () => {  };

            scene.Instantiate(mainGameObject);
            scene.Instantiate(emailInput);
            scene.Instantiate(passwordInput);
            scene.Instantiate(loginButton);
            scene.Instantiate(errorMessage);
            scene.Instantiate(goToMakeUser);
        }

        public void ClickOnLogin()
        {
            // TODO: Get User info.
            string email = "123";
            string password = "123";

            if (if01.Text == email && if02.Text == password)
            {
                mainGameObject.IsActive = false;

                // TODO: Login successful
            }
            else
            {
                errorMessage.IsActive = true;
            }
        }
    }
}
