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
            UpdateDescription();
            base.Update();
        }
        private void AsmundTest()
        {
            float RefScreenSizeX = 800;
            float RefScreenSizeY = 600;
            ////go.AddComponent<SpriteRenderer>();

            GameObject background = new GameObject();
            SpriteRenderer sp = new SpriteRenderer("TalentsBackground", OriginPositionEnum.MidLeft, 0, Color.White);
            background.AddComponent<SpriteRenderer>(sp);
            background.Transform.Position = new Vector2(0,0);
            //background.Transform.Scale = new Vector2(0.8f, 0.8f);
            background.Transform.Scale = new Vector2(
            (GraphicsSetting.Instance.ScreenSize.X / 2) / sp.Sprite.Width,
            (GraphicsSetting.Instance.ScreenSize.Y / 1) / sp.Sprite.Height);
            

            //background.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X/2, 0);

            //ImageGUI bob = go.AddComponent<ImageGUI>(new ImageGUI(sp, 3false, false));

            Instantiate(background);

            MakeSkill("Skill1", new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.77f, GraphicsSetting.Instance.ScreenSize.Y / 8.5f));
            MakeSkill("Skill2", new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.77f, GraphicsSetting.Instance.ScreenSize.Y / 2.5f));
            MakeSkill("Skill3", new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.77f, GraphicsSetting.Instance.ScreenSize.Y / 1.5f));
            //MakeSkill("Skill5", new Vector2(1050, 50));
            //MakeSkill("Skill4", new Vector2(900, 160));
            //MakeSkill("Skill6", new Vector2(1050, 200));
            //MakeSkill("Skill7", new Vector2(1050, 600));
            MouseSettings.Instance.IsMouseVisible(true);
            //go.AddComponent<SpriteRenderer>(new SpriteRenderer("Pixel", OriginPositionEnum.Mid, 1, Color.White));
            //SpriteRenderer lol = go.GetComponent<SpriteRenderer>();

        }
        List<GameObject> descriptionCollection = new List<GameObject>();
        private GameObject MakeSkill(string sprite, Vector2 pos)
        {
            GameObject button10 = new GameObject();
            button10.AddComponent<SpriteRenderer>();
            ButtonGUI btn10 = button10.AddComponent<ButtonGUI>(new ButtonGUI(SpriteContainer.Instance.sprite[sprite], SpriteContainer.Instance.sprite[sprite], Color.White, Color.Green));
            btn10.OnClick = () => { button10.IsActive = !button10.IsActive; };
            button10.Transform.Scale = new Vector2(0.9f, 0.9f);
            button10.Transform.Position = pos;
            Instantiate(button10);

            GameObject descBox = new GameObject();
            descBox.Transform.Position = pos;
            descBox.MyParent = button10;
            GameObject overlay = new GameObject();
            overlay.AddComponent<SpriteRenderer>();
            ImageGUI image = new ImageGUI(overlay.GetComponent<SpriteRenderer>(), false, false);
            overlay.AddComponent<ImageGUI>(image);
            overlay.Transform.Scale = new Vector2(200, 200);
            overlay.Transform.Position = pos;
            overlay.MyParent = descBox;
            //Color color = new Color(1, 1, 1, 05f);
            Color color1 = new Color(Color.Gray, 0.5f);
            //Color color1 = new Color(200, 200, 200, 254);
            overlay.GetComponent<SpriteRenderer>().Color = color1;
            GameObject textBox = new GameObject();
            TextGUI text = new TextGUI(SpriteContainer.Instance.normalFont, Color.Black, new Vector2(1,1),"SuperAttack");
            textBox.Transform.Position = pos;
            textBox.AddComponent<TextGUI>(text);
            textBox.MyParent = descBox;

            Instantiate(descBox);
            Instantiate(overlay);
            Instantiate(textBox);


            descriptionCollection.Add(descBox);


            return button10;
        }

        private void UpdateDescription()
        {
            foreach (GameObject item in descriptionCollection)
            {
                item.IsActive = item.MyParent.GetComponent<ButtonGUI>().MouseIsHovering;
            }
        }
    }
}
