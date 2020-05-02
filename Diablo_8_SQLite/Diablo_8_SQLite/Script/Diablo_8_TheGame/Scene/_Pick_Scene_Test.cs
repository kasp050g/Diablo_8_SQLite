using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameFramework;
using Script.Generics;
using SQLiteFramework.Framework;
using SQLiteFramework.Interfaces;

namespace Diablo_8_SQLite
{
    public class _Pick_Scene_Test : Scene
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Initialize()
        {
            base.Initialize();
            List<IRowElement> HeroesTable = Singletons.TableContainerSingleton.UsersTable.GetAllRows();
            MakeUIPicker();
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

            if (Input.GetKeyDown(Keys.D1))
            {
                SceneController.Instance.CurrentScene = SceneController.Instance.SceneContainer.Scenes[1];
            }
            if (Input.GetKeyDown(Keys.D2))
            {
                SceneController.Instance.CurrentScene = SceneController.Instance.SceneContainer.Scenes[2];
            }
            if (Input.GetKeyDown(Keys.D3))
            {
                SceneController.Instance.CurrentScene = SceneController.Instance.SceneContainer.Scenes[3];
            }
            if (Input.GetKeyDown(Keys.D4))
            {
                SceneController.Instance.CurrentScene = SceneController.Instance.SceneContainer.Scenes[4];
            }
            if (Input.GetKeyDown(Keys.D5))
            {
                SceneController.Instance.CurrentScene = SceneController.Instance.SceneContainer.Scenes[5];
            }
        }

        public void MakeUIPicker()
        {
            GameObject go = new GameObject();

            string ScneNames = "";
            for (int i = 1; i < SceneController.Instance.SceneContainer.Scenes.Count; i++)
            {
                ScneNames += "\n " + i +": " + SceneController.Instance.SceneContainer.Scenes[i].Name + " ";
            }

            go.AddComponent<TextGUI>(new TextGUI(SpriteContainer.Instance.normalFont, Color.Black, new Vector2(2, 2), "Click Number to Pick Scene." +
                ScneNames));
            Instantiate(go);
        }
    }
}
