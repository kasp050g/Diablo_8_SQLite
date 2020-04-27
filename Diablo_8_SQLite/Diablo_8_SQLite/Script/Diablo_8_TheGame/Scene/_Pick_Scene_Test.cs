using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameFramework;

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
        }

        public void MakeUIPicker()
        {
            GameObject go = new GameObject();

            go.AddComponent<TextGUI>(new TextGUI(SpriteContainer.Instance.normalFont, Color.Black, new Vector2(2, 2), "Click Number to Pick Scene." +
                "\n 1: " + SceneController.Instance.SceneContainer.Scenes[1].Name + " " +
                "\n 2: " + SceneController.Instance.SceneContainer.Scenes[2].Name + " " +
                "\n 3: " + SceneController.Instance.SceneContainer.Scenes[3].Name + " " +
                "\n 4: " + SceneController.Instance.SceneContainer.Scenes[4].Name + " "));
            Instantiate(go);
        }
    }
}
