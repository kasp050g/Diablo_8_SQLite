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
        MakeNewHero newHero;
        List<GameObject> heroList = new List<GameObject>();

        Scene myScene;

        GameObject makeHeroButton = new GameObject();
        SpriteRenderer sr07;
        ButtonGUI buttonGUI07;


        public GameObject MainGameObject { get => mainGameObject; set => mainGameObject = value; }
        public MakeNewHero NewHero { get => newHero; set => newHero = value; }

        public void MakeUI(Scene myScene)
        {
            mainGameObject.IsActive = false;
            this.myScene = myScene;


            myScene.Instantiate(mainGameObject);
            //MakeAllHeros();
            //buttonGUI01.OnClick += () => {  };

            MakeButton(
                ref makeHeroButton,
                ref sr07,
                ref buttonGUI07,
                new Vector2(GraphicsSetting.Instance.ScreenSize.X, GraphicsSetting.Instance.ScreenSize.Y),
                new Vector2(250, 50),
                "Make new hero",
                OriginPositionEnum.BottomRight
            );
            buttonGUI07.OnClick += () => { GoToMakeNewHero(); };
            myScene.Instantiate(makeHeroButton);
        }

        void GoToMakeNewHero()
        {
            mainGameObject.IsActive = false;
            newHero.MainGameObject.IsActive = true;
        }

        public void MakeAllHeros()
        {
            for (int i = 0; i < heroList.Count; i++)
            {
                myScene.Destroy(heroList[i]);
            }

            List<IRowElement> heros = Singletons.TableContainerSingleton.HeroesTable.FindRows("UserID", UserData.Instance.Account.Id);

            for (int i = 0; i < heros.Count; i++)
            {
                IRowElement className = Singletons.TableContainerSingleton.ClassTable.FindRow((int)heros[i].RowElementVariables["ClassID"]);
                GameObject newHeroButton = new GameObject();
                SpriteRenderer sp = new SpriteRenderer(className.RowElementVariables["Name"]);
                ButtonGUI buttonGUI = new ButtonGUI();
                MakeHeroButton(ref newHeroButton, ref sp, ref buttonGUI, i);
                int idForHero = heros[i].Id;
                buttonGUI.OnClick = () => { OnHeroPickButton(idForHero); };
                // Delete Button
                GameObject deleteButton = new GameObject();
                SpriteRenderer sp02 = new SpriteRenderer();
                ButtonGUI buttonGUI02 = new ButtonGUI();
                MakeButton(ref deleteButton, ref sp02, ref buttonGUI02,
                    new Vector2(
                        newHeroButton.Transform.Position.X,
                        newHeroButton.Transform.Position.Y - 10
                    ),new Vector2(50,50),"X",OriginPositionEnum.BottomLeft
                    );
                buttonGUI02.OnClick = () => { DeleteHero(idForHero, deleteButton); };

                // Text Name
                TextGUI textGUI = new TextGUI(SpriteContainer.Instance.normalFont, Color.Black, new Vector2(1, 1), heros[i].RowElementVariables["Name"]);
                textGUI.LayerDepth = 1;
                textGUI.OriginPositionEnum = OriginPositionEnum.BottomLeft;


                newHeroButton.AddComponent<TextGUI>(textGUI);
                newHeroButton.MyParent = mainGameObject;
                myScene.Instantiate(newHeroButton);
                myScene.Instantiate(deleteButton);
                heroList.Add(newHeroButton);
            }
        }

        void OnHeroPickButton(int id)
        {
            mainGameObject.IsActive = false;
            UserData.Instance.currentHero = new Heroe(id);

            Console.WriteLine(UserData.Instance.currentHero.ClassName);
            Console.WriteLine(UserData.Instance.currentHero.Name);
            SceneController.Instance.CurrentScene = SceneController.Instance.SceneContainer.Scenes[0];
        }

        void DeleteHero(int id,GameObject myGameobject)
        {
            IRowElement heroTest01 = Singletons.TableContainerSingleton.HeroesTable.FindRow(id);
            IRowElement herosaveTest01 = Singletons.TableContainerSingleton.HeroesSaveTable.FindRow("HeroID", heroTest01.Id);
            IRowElement savestats01 = Singletons.TableContainerSingleton.StatsSaveTable.FindRow("HeroesSaveID", herosaveTest01.Id);
            List<IRowElement> saveskills = Singletons.TableContainerSingleton.SkillsSaveTable.FindRows("HeroesSaveID", herosaveTest01.Id);

            for (int i = 0; i < saveskills.Count; i++)
            {
                Singletons.TableContainerSingleton.SkillsSaveTable.DeleteRow(saveskills[i].Id);
            }

            Singletons.TableContainerSingleton.StatsSaveTable.DeleteRow(savestats01.Id);
            Singletons.TableContainerSingleton.HeroesSaveTable.DeleteRow(herosaveTest01.Id);
            Singletons.TableContainerSingleton.HeroesTable.DeleteRow(savestats01.Id);

            for (int i = 0; i < heroList.Count; i++)
            {
                if(heroList[i].GetComponent<TextGUI>().Text == heroTest01.RowElementVariables["Name"])
                {
                    myScene.Destroy(heroList[i]);
                }                
            }
            myScene.Destroy(myGameobject);
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
    }
}
