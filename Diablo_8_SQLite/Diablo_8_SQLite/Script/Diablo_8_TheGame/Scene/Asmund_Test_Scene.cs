using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameFramework;

namespace Diablo_8_SQLite
{
    //Asmund was here.
    public class Asmund_Test_Scene : Scene
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Initialize()
        {
            base.Initialize();
            AsmundTest();
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
        private void AsmundTest()
        {
            GameObject go = new GameObject();
            //go.AddComponent<SpriteRenderer>();

            SpriteRenderer sp = new SpriteRenderer("Pixel", OriginPositionEnum.TopMid, 1, Color.White);
            go.AddComponent<SpriteRenderer>(sp);

            go.Transform.Scale = new Vector2(100, GraphicsSetting.Instance.ScreenSize.Y);
            go.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X/2, 0);

            ImageGUI bob = go.AddComponent<ImageGUI>(new ImageGUI(sp, false, false));
            
            Instantiate(go);

            GameObject button = new GameObject();
            button.AddComponent<SpriteRenderer>();
            ButtonGUI btn1 = button.AddComponent<ButtonGUI>(new ButtonGUI(SpriteContainer.Instance.sprite["Pixel"], SpriteContainer.Instance.sprite["Pixel"], Color.White, Color.Green));
            btn1.OnClick = () => { go.IsActive = !go.IsActive; };
            button.Transform.Scale = new Vector2(300, 300);

            Instantiate(button);

            MouseSettings.Instance.IsMouseVisible(true);
            //go.AddComponent<SpriteRenderer>(new SpriteRenderer("Pixel", OriginPositionEnum.Mid, 1, Color.White));


            //SpriteRenderer lol = go.GetComponent<SpriteRenderer>();

        }
    }
}
