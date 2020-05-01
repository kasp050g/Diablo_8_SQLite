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
    public class HeroPick
    {
        GameObject mainGameObject = new GameObject();
        List<GameObject> heroList = new List<GameObject>();

        Scene myScene;
        //GameObject barbarianButton = new GameObject();
        //SpriteRenderer sr01;
        //ButtonGUI buttonGUI01;

        //GameObject necromButton = new GameObject();
        //SpriteRenderer sr02;
        //ButtonGUI buttonGUI02;

        //GameObject sorceressButton = new GameObject();
        //SpriteRenderer sr03;
        //ButtonGUI buttonGUI03;


        public GameObject MainGameObject { get => mainGameObject; set => mainGameObject = value; }

        public void MakeUI(Scene myScene)
        {
            this.myScene = myScene;


            myScene.Instantiate(mainGameObject);
            //MakeAllHeros();
            //buttonGUI01.OnClick += () => {  };
        }

        public void MakeAllHeros()
        {
            for (int i = 0; i < heroList.Count; i++)
            {
                heroList[i].Destroy();
            }

            List<IRowElement> heros = Singletons.TableContainerSingleton.HeroesTable.FindRows("UserID", UserData.Instance.Account.Id);

            for (int i = 0; i < heros.Count; i++)
            {
                IRowElement className = Singletons.TableContainerSingleton.ClassTable.FindRow((int)heros[i].RowElementVariables["ClassID"]);
                GameObject newHeroButton = new GameObject();
                SpriteRenderer sp = new SpriteRenderer(className.RowElementVariables["Name"]);
                ButtonGUI buttonGUI = new ButtonGUI();
                TextGUI textGUI = new TextGUI(SpriteContainer.Instance.normalFont, Color.Black, new Vector2(1, 1), heros[i].RowElementVariables["Name"]);

                MakeHeroButton(ref newHeroButton, ref sp, ref buttonGUI, i);
                textGUI.LayerDepth = 1;
                textGUI.OriginPositionEnum = OriginPositionEnum.BottomLeft;
                int idForHero = heros[i].Id;
                buttonGUI.OnClick = () => { OnHeroPickButton(idForHero); };

                newHeroButton.AddComponent<TextGUI>(textGUI);
                newHeroButton.MyParent = mainGameObject;
                myScene.Instantiate(newHeroButton);
                heroList.Add(newHeroButton);
            }
        }

        void OnHeroPickButton(int id)
        {
            mainGameObject.IsActive = false;
            UserData.Instance.currentHero = new Heroe(id);

            Console.WriteLine(UserData.Instance.currentHero.ClassName);
            Console.WriteLine(UserData.Instance.currentHero.Name);
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
            //sr = new SpriteRenderer();
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
    }
}
