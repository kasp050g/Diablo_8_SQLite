using Microsoft.Xna.Framework;
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
    public class MakeNewHero
    {
        private GameObject mainGameObject = new GameObject();
        private HeroPick heroPick;
        private Scene myScene;

        private GameObject nameGameObject = new GameObject();
        private SpriteRenderer sr01;
        private InputFieldGUI inputName;

        private GameObject backButton = new GameObject();
        private SpriteRenderer sr07;
        private ButtonGUI buttonGUI07;

        public GameObject MainGameObject { get => mainGameObject; set => mainGameObject = value; }
        public HeroPick HeroPick { get => heroPick; set => heroPick = value; }

        public void MakeUI(Scene myScene)
        {
            mainGameObject.IsActive = false;
            this.myScene = myScene;
            MakeAllHeros();
        }

        void MakeAllHeros()
        {

            List<IRowElement> classTable = Singletons.TableContainerSingleton.ClassTable.GetAllRows();

            for (int i = 0; i < classTable.Count; i++)
            {
                GameObject newHeroButton = new GameObject();
                SpriteRenderer sp = new SpriteRenderer(classTable[i].RowElementVariables["Name"]);
                ButtonGUI buttonGUI = new ButtonGUI();
                TextGUI textGUI = new TextGUI(SpriteContainer.Instance.normalFont, Color.Black, new Vector2(1, 1), classTable[i].RowElementVariables["Name"]);

                MakeHeroButton(ref newHeroButton, ref sp, ref buttonGUI, i);
                textGUI.LayerDepth = 1;
                textGUI.OriginPositionEnum = OriginPositionEnum.BottomLeft;
                int idForHero = classTable[i].Id;
                buttonGUI.OnClick = () => { MakeNowHero(idForHero); };

                newHeroButton.AddComponent<TextGUI>(textGUI);
                newHeroButton.MyParent = mainGameObject;
                myScene.Instantiate(newHeroButton);
            }

            MakeInput(ref nameGameObject, ref sr01, ref inputName, new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, GraphicsSetting.Instance.ScreenSize.Y - 25), "Name your hero");
            
            myScene.Instantiate(nameGameObject);

            MakeButton(
                ref backButton,
                ref sr07,
                ref buttonGUI07,
                new Vector2(GraphicsSetting.Instance.ScreenSize.X, GraphicsSetting.Instance.ScreenSize.Y),
                new Vector2(180, 40),
                "Back",
                OriginPositionEnum.BottomRight
            );
            buttonGUI07.OnClick += () => { GoBack(); };
            myScene.Instantiate(backButton);
        }

        void MakeNowHero(int classID)
        {
            if(inputName.Text != "" && inputName.Text != string.Empty)
            {
                IRowElement heroTest01 = Singletons.TableContainerSingleton.HeroesTable.InsertRow(false, UserData.Instance.Account.Id, classID, inputName.Text);
                IRowElement herosaveTest01 = Singletons.TableContainerSingleton.HeroesSaveTable.InsertRow(false, heroTest01.Id, 1, 1, 1, 0, 0);
                IRowElement savestats01 = Singletons.TableContainerSingleton.StatsSaveTable.InsertRow(false, herosaveTest01.Id, 0, 0, 0, 0);                

                mainGameObject.IsActive = false;
                HeroPick.MainGameObject.IsActive = true;
                HeroPick.MakeAllHeros();
            }
        }

        void GoBack()
        {
            mainGameObject.IsActive = false;
            HeroPick.MainGameObject.IsActive = true;

        }

        void MakeHeroButton(ref GameObject go, ref SpriteRenderer sr, ref ButtonGUI button, int nrX)
        {
            MakeButton(
                // Gameobject
                ref go,
                // SpriteRenderer
                ref sr,
                // ButtonGUI
                ref button,
                // Position
                new Vector2(100 + 400 * nrX, 50),
                // Scale
                new Vector2(1, 1),
                // Text
                "",
                OriginPositionEnum.TopLeft
            );
        }

        void MakeButton(ref GameObject go, ref SpriteRenderer sr, ref ButtonGUI button, Vector2 position, Vector2 scale, string text, OriginPositionEnum originPosition)
        {
            // Make Components
            if(sr == null)
            sr = new SpriteRenderer();
            button = new ButtonGUI
               (
               sr,
               sr.Sprite,
               sr.Sprite,
               Color.White,
               Color.Gray,
               SpriteContainer.Instance.normalFont,
               Color.Black,
               new Vector2(0.5f, 0.5f),
               text
               );
            // Add the Components
            go.AddComponent<SpriteRenderer>(sr);
            go.AddComponent<ButtonGUI>(button);
            // Modify Components
            go.MyParent = mainGameObject;
            sr.LayerDepth = 0.1f;
            sr.OriginPositionEnum = originPosition;
            go.Transform.Position = new Vector2(position.X, position.Y);
            go.Transform.Scale = new Vector2(scale.X, scale.Y);
        }

        void MakeInput(ref GameObject go, ref SpriteRenderer sr, ref InputFieldGUI input, Vector2 position, string placeholderText)
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
            sr.OriginPositionEnum = OriginPositionEnum.BottomMid;
            sr.LayerDepth = 0.1f;
            go.Transform.Position = new Vector2(position.X, position.Y);
            go.Transform.Scale = new Vector2(500 * GraphicsSetting.Instance.ScreenScale.X, 100 * GraphicsSetting.Instance.ScreenScale.Y);
        }
    }
}
