using Microsoft.Xna.Framework;
using MonogameFramework;
using Script.Generics;
using SQLiteFramework.Framework;
using SQLiteFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    public class MakeUserGameObject
    {
        GameObject mainGameObject = new GameObject();

        GameObject userInput = new GameObject();
        SpriteRenderer sr01;
        InputFieldGUI if01;

        GameObject emailInput = new GameObject();
        SpriteRenderer sr02;
        InputFieldGUI if02;

        GameObject passwordInput01 = new GameObject();
        SpriteRenderer sr03;
        InputFieldGUI if03;

        GameObject passwordInput02 = new GameObject();
        SpriteRenderer sr04;
        InputFieldGUI if04;

        GameObject makeUserButton = new GameObject();
        SpriteRenderer sr05;
        ButtonGUI buttonGUI05;

        GameObject errorMessage = new GameObject();
        TextGUI textGUI06;

        public void MakeUI(Scene scene)
        {
            MakeInput(ref userInput, ref sr01, ref if01, new Vector2(0, 100),"User Name");
            MakeInput(ref emailInput, ref sr02, ref if02, new Vector2(0, 250),"Email");
            MakeInput(ref passwordInput01, ref sr03,ref if03, new Vector2(0, 400),"Password");
            MakeInput(ref passwordInput02, ref sr04,ref if04, new Vector2(0, 550),"Password one more");

            // --- Make User Button
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
               new Vector2(0.5f, 0.5f),
               "Login"
               );
            // Add the Components
            makeUserButton.AddComponent<SpriteRenderer>(sr05);
            makeUserButton.AddComponent<ButtonGUI>(buttonGUI05);
            // Modify Components
            makeUserButton.MyParent = mainGameObject;
            sr05.OriginPositionEnum = OriginPositionEnum.Mid;
            sr05.LayerDepth = 0.1f;
            makeUserButton.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 670 * GraphicsSetting.Instance.ScreenScale.X);
            makeUserButton.Transform.Scale = new Vector2(200 * GraphicsSetting.Instance.ScreenScale.X, 50 * GraphicsSetting.Instance.ScreenScale.Y);
            buttonGUI05.OnClick += () => { MakeUser(); };

            // --- Error Message
            // Error Message
            textGUI06 = new TextGUI
               (
               SpriteContainer.Instance.normalFont,
               Color.Red,
               new Vector2(0.5f * GraphicsSetting.Instance.ScreenScale.X, 0.5f * GraphicsSetting.Instance.ScreenScale.Y),
               "User / Emial in use or password not the same"
               );
            // Add the Components
            errorMessage.AddComponent<TextGUI>(textGUI06);
            // Modify Components
            errorMessage.MyParent = mainGameObject;
            errorMessage.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 610 * GraphicsSetting.Instance.ScreenScale.X);
            textGUI06.OriginPositionEnum = OriginPositionEnum.TopMid;
            textGUI06.LayerDepth = 0.1f;
            errorMessage.IsActive = false;

            scene.Instantiate(mainGameObject);
            scene.Instantiate(userInput);
            scene.Instantiate(emailInput);
            scene.Instantiate(passwordInput01);
            scene.Instantiate(passwordInput02);
            scene.Instantiate(makeUserButton);
            scene.Instantiate(errorMessage);
        }

        void MakeInput(ref GameObject go,ref SpriteRenderer sr,ref InputFieldGUI input,Vector2 position,string placeholderText)
        {
            // --- Input
            // Make Components
            sr = new SpriteRenderer();
            input = new InputFieldGUI
               (
               sr,
               SpriteContainer.Instance.sprite["Pixel"],
               Color.White,
               SpriteContainer.Instance.normalFont,
               Color.Black,
               new Vector2(1, 1),
               placeholderText
               );
            // Add the Components
            go.AddComponent<SpriteRenderer>(sr);
            go.AddComponent<InputFieldGUI>(input);
            // Modify Components
            go.MyParent = mainGameObject;
            sr.OriginPositionEnum = OriginPositionEnum.Mid;
            sr.LayerDepth = 0.1f;
            go.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, position.Y * GraphicsSetting.Instance.ScreenScale.X);
            go.Transform.Scale = new Vector2(500 * GraphicsSetting.Instance.ScreenScale.X, 100 * GraphicsSetting.Instance.ScreenScale.Y);
        }

        void MakeUser()
        {
            if(if03.Text != if04.Text || if03.Text == string.Empty || if04.Text == string.Empty)
            {
                errorMessage.IsActive = true;
                textGUI06.Text = "Password not the same.";
            }
            else
            {
                errorMessage.IsActive = false;

                if(Singletons.TableContainerSingleton.UsersTable.FindRow("Email", if02.Text) == null)
                {

                    Singletons.TableContainerSingleton.UsersTable.InsertRow(if02.Text, if02.Text, "Salt", if02.Text, 10);


                    errorMessage.IsActive = true;
                        textGUI06.Text = "That Email is in use";
                    
                }
            }
        }
    }
}
