﻿using System;
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
            ////go.AddComponent<SpriteRenderer>();
            //background.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X/2, 0
            //ImageGUI bob = go.AddComponent<ImageGUI>(new ImageGUI(sp, 3false, false));

            GameObject background = new GameObject();
            SpriteRenderer sp = new SpriteRenderer("TalentsBackground", OriginPositionEnum.MidLeft, 0, Color.White);
            background.AddComponent<SpriteRenderer>(sp);
            background.Transform.Position = new Vector2(0,0);
            //background.Transform.Scale = new Vector2(0.8f, 0.8f);
            background.Transform.Scale = new Vector2(
            (GraphicsSetting.Instance.ScreenSize.X / 2) / sp.Sprite.Width,
            (GraphicsSetting.Instance.ScreenSize.Y / 1) / sp.Sprite.Height);
            
            Instantiate(background);

            MakeSkill("Skill1", 
                "Mortal Strike\n\nStrikes the enemy for \nadditional damage.", 
                new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.77f, GraphicsSetting.Instance.ScreenSize.Y / 8.5f));
            MakeSkill("Skill2", 
                "Thunder Slam\n\nDamages all nearby \nenemies and slows them\ndown.", 
                new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.77f, GraphicsSetting.Instance.ScreenSize.Y / 2.5f));

            MakeSkill("Skill3", 
                "Whirlwind\n\nDeals weapon damage to\nall nearby enemies.", 
                new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.77f, GraphicsSetting.Instance.ScreenSize.Y / 1.5f));

            MakeSkill("Skill4", 
                "Shield Wall\n\nIncreases block value \nby 100%.", 
                new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.47f, GraphicsSetting.Instance.ScreenSize.Y / 4.1f));

            MakeSkill("Skill5", 
                "Trueshot\n\nIncrease accuracy \nby 15%.", 
                new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.24f, GraphicsSetting.Instance.ScreenSize.Y / 8.5f));

            MakeSkill("Skill6", 
                "Frost Arrow\n\nArrows you fire deal \nbonus damage and \nslows the target.", 
                new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.24f, GraphicsSetting.Instance.ScreenSize.Y / 3.5f));

            MakeSkill("Skill7", 
                "Piercing Strike\n\nArrows reduces the \ntargets armor.", 
                new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.08f, GraphicsSetting.Instance.ScreenSize.Y / 2.35f));

            MakeSkill("Skill8", 
                "Multi-shot\n\nFires multiple arrows \nin one attack.", 
                new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.24f, GraphicsSetting.Instance.ScreenSize.Y / 1.25f));

            MakeSkill("Skill9", 
                "Empower\n\nIncreases stats by 20%.", 
                new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.08f, GraphicsSetting.Instance.ScreenSize.Y / 1.65f));

            MakeSkill("Skill10", 
                "Tornado\n\nSummons a violent \ntornado that moves \non it's own, damaging \nand slowing down \nenemies that stand \nclose to it.", 
                new Vector2(GraphicsSetting.Instance.ScreenSize.X / 1.47f, GraphicsSetting.Instance.ScreenSize.Y / 1.25f));

            MouseSettings.Instance.IsMouseVisible(true);
            //go.AddComponent<SpriteRenderer>(new SpriteRenderer("Pixel", OriginPositionEnum.Mid, 1, Color.White));
            //SpriteRenderer lol = go.GetComponent<SpriteRenderer>();

        }
        List<GameObject> descriptionCollection = new List<GameObject>();
        private GameObject MakeSkill(string sprite, string description, Vector2 pos)
        {
            GameObject button10 = new GameObject();
            button10.AddComponent<SpriteRenderer>();
            ButtonGUI btn10 = button10.AddComponent<ButtonGUI>(new ButtonGUI(SpriteContainer.Instance.sprite[sprite], SpriteContainer.Instance.sprite[sprite], Color.White, Color.Green));
            btn10.OnClick = () => { button10.IsActive = !button10.IsActive; };
            button10.Transform.Scale = new Vector2(GraphicsSetting.Instance.ScreenScale.X, GraphicsSetting.Instance.ScreenScale.Y);
            button10.Transform.Position = pos;
            Instantiate(button10);

            GameObject mini = new GameObject();
            mini.AddComponent<SpriteRenderer>();
            mini.Transform.Scale = new Vector2(GraphicsSetting.Instance.ScreenScale.X * 20, GraphicsSetting.Instance.ScreenScale.Y * 20);
            mini.Transform.Position = pos;
            ImageGUI whatever = new ImageGUI(mini.GetComponent<SpriteRenderer>(), false, false);
            mini.AddComponent<ImageGUI>(whatever);
            whatever.SpriteRenderer.LayerDepth = 1;
            text.LayerDepth = 1;
            Instantiate(mini);

            GameObject descBox = new GameObject();
            descBox.Transform.Position = pos;
            descBox.MyParent = button10;

            GameObject overlay = new GameObject();
            overlay.AddComponent<SpriteRenderer>();
            ImageGUI image = new ImageGUI(overlay.GetComponent<SpriteRenderer>(), false, false);
            overlay.AddComponent<ImageGUI>(image);
            overlay.Transform.Scale = new Vector2(200, 200);
            overlay.Transform.Position = pos + new Vector2(80, 0);
            overlay.MyParent = descBox;
            Color color1 = new Color(Color.Gray, 0.5f);
            overlay.GetComponent<SpriteRenderer>().Color = color1;

            //GameObject aoverlay = new GameObject();
            //aoverlay.AddComponent<SpriteRenderer>();
            //ImageGUI aimage = new ImageGUI(aoverlay.GetComponent<SpriteRenderer>(), false, false);
            //aoverlay.AddComponent<ImageGUI>(aimage);
            //aoverlay.Transform.Scale = new Vector2(20, 20);
            //aoverlay.Transform.Position = pos + new Vector2(50, 50);
            //Color acolor1 = new Color(Color.White, 0.4f);
            //aoverlay.GetComponent<SpriteRenderer>().Color = acolor1;
            //aoverlay.IsActive = true;

            GameObject textBox = new GameObject();
            TextGUI text = new TextGUI(SpriteContainer.Instance.normalFont, Color.Black, new Vector2(0.4f,0.4f),description);
            text.LayerDepth = 1;
            textBox.Transform.Position = pos + new Vector2(80, 0);
            textBox.AddComponent<TextGUI>(text);
            textBox.MyParent = descBox;

            Instantiate(descBox);
            Instantiate(overlay);
            Instantiate(textBox);

            descriptionCollection.Add(descBox);


            //Instantiate(aoverlay);

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
