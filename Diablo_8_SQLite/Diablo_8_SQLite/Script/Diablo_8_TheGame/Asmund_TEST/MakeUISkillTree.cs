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

        public void MakeSkillTree(Scene scene)
        {
            this.myScene = scene;
            GetHeroData();
        }

        private void GetHeroData()
        {
            skillTrees = UserData.Instance.currentHero.SkillTrees;
            foreach (SkillTreeSlot item in skillTrees[0].SkillTreeSlots)
            {
                //TODO
                //make skill tree button
                Vector2 pos = new Vector2(item.Position.X * 100 * GraphicsSetting.Instance.ScreenScale.X, item.Position.Y * 100 * GraphicsSetting.Instance.ScreenScale.Y);

                Skill skill = item.Skill;
                MakeSkill(item.Skill.Icon, item.Skill.Name, pos,  skill);
                
               
            }

            

            

        }
        private void MakeSkill(Texture2D sprite, string description, Vector2 pos,  Skill skill)
        {
            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer(sprite);
            
            ButtonGUI btn = new ButtonGUI(sr, sprite, sprite, Color.White, Color.Green);
            btn.OnClick = () => { skill.Level += 1; UserData.Instance.currentHero.SaveHero(); };

            go.AddComponent<SpriteRenderer>(sr);
            go.AddComponent<ButtonGUI>(btn);
            myScene.Instantiate(go);

        }

    }
}
