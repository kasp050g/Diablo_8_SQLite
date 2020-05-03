using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo_8_SQLite
{
    class MakeUISkillTree
    {
        Scene myScene;
        List<SkillTree> skillTrees = new List<SkillTree>();
        GameObject mainGameObject = new GameObject();
        //Vector2 pos = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 0);

            private void CreateTalentBackground()
        {
            GameObject background = new GameObject();
            SpriteRenderer sr = new SpriteRenderer("TalentsBackground", OriginPositionEnum.TopLeft, 0.01f);
            
            ImageGUI image = new ImageGUI(sr, false, false);
            background.AddComponent<SpriteRenderer>(sr);
            background.AddComponent<ImageGUI>(image);

            //background.Transform.Scale = new Vector2((GraphicsSetting.Instance.ScreenSize.X / sr.Sprite.Width) / 2, 1);

            background.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 0);


            myScene.Instantiate(background);

        }

        public void MakeSkillTree(Scene scene)
        {
            this.myScene = scene;
            GetHeroData();
            CreateTalentBackground();
        }

        private void GetHeroData()
        {
            
            //mainGameObject.Transform.Position = new Vector2(GraphicsSetting.Instance.ScreenSize.X / 2, 0);
            //mainGameObject.Transform.Position = pos;
            skillTrees = UserData.Instance.currentHero.SkillTrees;
            foreach (SkillTreeSlot item in skillTrees[0].SkillTreeSlots)
            {
                // pos.Y += GraphicsSetting.Instance.ScreenSize.Y / 4;
                //GraphicsSetting.Instance.ScreenSize.X / 2, 0
                Vector2 pos = new Vector2((GraphicsSetting.Instance.ScreenSize.X / 2) + (item.Position.X * 100 * GraphicsSetting.Instance.ScreenScale.X), item.Position.Y * 200 * GraphicsSetting.Instance.ScreenScale.Y) + mainGameObject.Transform.Position;


                Skill skill = item.Skill;
                MakeSkill(item.Skill.Icon, item.Skill.Name, pos,  skill);

            }

        }

        private TextGUI SkillRank(Vector2 pos, Skill skill)
        {
            //Creating objects
            GameObject go = new GameObject();
            TextGUI text = new TextGUI(SpriteContainer.Instance.normalFont, Color.Black, new Vector2(0.5f,0.5f), skill.Level.ToString());
            SpriteRenderer sr = new SpriteRenderer();
            ImageGUI image = new ImageGUI(sr, false, false);
            //Modifying obects
            sr.LayerDepth = 0.1f;
            text.LayerDepth = 0.2f;
            go.Transform.Scale = new Vector2((text.SpriteFont.MeasureString(text.Text).X * text.FontScale.X), (text.SpriteFont.MeasureString(text.Text).Y * text.FontScale.Y));
            go.Transform.Position = pos;

            //Connecting components
            go.AddComponent<ImageGUI>(image);
            go.AddComponent<TextGUI>(text);
            go.AddComponent<SpriteRenderer>(sr);
           
            //Instantiate
            myScene.Instantiate(go);

            return text;
        }


        private void MakeSkill(Texture2D sprite, string description, Vector2 pos,  Skill skill)
        {
            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer(sprite);
            sr.LayerDepth = 0.05f;
            ButtonGUI btn = new ButtonGUI(sr, sprite, sprite, Color.White, Color.Green);

            go.AddComponent<SpriteRenderer>(sr);
            go.AddComponent<ButtonGUI>(btn);
            go.Transform.Position = pos;
            myScene.Instantiate(go);

            TextGUI text = SkillRank(pos + new Vector2(0, 50), skill);
            
            btn.OnClick = () => { skill.Level += 1; UserData.Instance.currentHero.SaveHero(); text.Text = skill.Level.ToString(); };
        }

     


    }
}
