using Microsoft.Xna.Framework;
using MonogameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    public class ShowStatsUI
    {
        GameObject mainGameObject = new GameObject();
        Scene myScene;

        public void MakeUI(Scene myScene)
        {
            this.myScene = myScene;

            if (UserData.Instance.currentHero == null)
            {
                UserData.Instance.currentHero = new Heroe(1);
            }

            MakeBackGround();
            MakeStatsUI();
            SaveHeroButton();

        }

        public void MakeStatsUI()
        {
            ShowText(150, 0, "Name", UserData.Instance.currentHero.Name);
            ShowText(150, 1, "Class", UserData.Instance.currentHero.ClassName);
            ShowText(150, 2, "Level", UserData.Instance.currentHero.Level.ToString());
            ShowText(150, 3, "XP:", UserData.Instance.currentHero.Xp.ToString());

            MakeStatsButton(150, 5, "Strength", UserData.Instance.currentHero.TotalStrength).OnClick += () => { UserData.Instance.currentHero.Strength += 1; };
            MakeStatsButton(150, 6, "Dexterity", UserData.Instance.currentHero.TotalDexterity).OnClick += () => { UserData.Instance.currentHero.Dexterity += 1; };
            MakeStatsButton(150, 7, "Vitality", UserData.Instance.currentHero.TotalVitality).OnClick += () => { UserData.Instance.currentHero.Vitality += 1; };
            MakeStatsButton(150, 8, "Energy", UserData.Instance.currentHero.TotalEnergy).OnClick += () => { UserData.Instance.currentHero.Energy += 1; };
        }

        public void MakeBackGround()
        {
            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer();
            ImageGUI image = new ImageGUI();

            go.Transform.Scale = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, GraphicsSetting.Instance.ScreenSize.Y);
            go.Transform.Position = new Vector2(0, 0);
            sr.Color = Color.AntiqueWhite;

            go.AddComponent<SpriteRenderer>(sr);
            go.AddComponent<ImageGUI>(image);

            myScene.Instantiate(go);
        }

        public void ShowText(int Xpos, int Ypos, string name,string text)
        {
            MakeText(Xpos - 100, Ypos, name);
            MakeShowStats(Xpos, Ypos, text);
        }

        public ButtonGUI MakeStatsButton(int Xpos, int Ypos,string name, int statsNumber)
        {
            MakeText(Xpos - 100, Ypos, name);
            TextGUI text = MakeShowStats(Xpos, Ypos, statsNumber.ToString());

            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer("Pixel");
            ButtonGUI btn = new ButtonGUI(sr);

            go.Transform.Scale = new Vector2(30, 30);
            go.Transform.Position = new Vector2(Xpos + 120, Ypos * 50 + 20);
            sr.LayerDepth = 0.01f;
            btn.Color = Color.Red;
            btn.Text = "+";
            btn.OnClick = () => { text.Text = (statsNumber += 1).ToString(); };

            go.AddComponent<SpriteRenderer>(sr);
            go.AddComponent<ButtonGUI>(btn);

            myScene.Instantiate(go);
            return btn;
        }

        public TextGUI MakeShowStats(int Xpos, int Ypos, string text)
        {
            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer();
            ImageGUI image = new ImageGUI();
            TextGUI textGUI = new TextGUI(text);

            go.Transform.Scale = new Vector2(110, 30);
            go.Transform.Position = new Vector2(Xpos, Ypos * 50 + 20);
            sr.Color = Color.LightSlateGray;
            sr.LayerDepth = 0.01f;
            textGUI.OriginPositionEnum = OriginPositionEnum.Mid;
            textGUI.LayerDepth = 0.02f;

            go.AddComponent<SpriteRenderer>(sr);
            go.AddComponent<ImageGUI>(image);
            go.AddComponent<TextGUI>(textGUI);

            myScene.Instantiate(go);

            return textGUI;
        }

        public void MakeText(int Xpos, int Ypos, string text)
        {
            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer();

            TextGUI textGUI = new TextGUI(text);

            go.Transform.Scale = new Vector2(100, 30);
            go.Transform.Position = new Vector2(Xpos, Ypos * 50 + 20);
            sr.Color = new Color(0, 0, 0, 0);
            sr.LayerDepth = 0.01f;
            textGUI.OriginPositionEnum = OriginPositionEnum.Mid;
            textGUI.LayerDepth = 0.02f;

            go.AddComponent<SpriteRenderer>(sr);
            go.AddComponent<TextGUI>(textGUI);

            myScene.Instantiate(go);
        }

        public void SaveHeroButton()
        {
            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer("Pixel");
            ButtonGUI btn = new ButtonGUI(sr);

            go.Transform.Scale = new Vector2(240, 50);
            go.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 4,GraphicsSetting.Instance.ScreenSize.Y - 50);
            sr.LayerDepth = 0.05f;
            sr.OriginPositionEnum = OriginPositionEnum.Mid;
            btn.Color = Color.BlueViolet;
            btn.Text = "Save Hero";
            btn.OnClick = () => { UserData.Instance.currentHero.SaveHero(); };

            go.AddComponent<SpriteRenderer>(sr);
            go.AddComponent<ButtonGUI>(btn);

            myScene.Instantiate(go);
        }
    }
}
