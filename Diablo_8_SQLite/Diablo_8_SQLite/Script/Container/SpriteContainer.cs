using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFramework
{
    public class SpriteContainer
    {
        #region Singleton
        private static SpriteContainer instance;
        public static SpriteContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SpriteContainer();
                }
                return instance;
            }
        }
        #endregion

        public Dictionary<string, Texture2D> sprite = new Dictionary<string, Texture2D>();
        public Dictionary<string, List<Texture2D>> spriteList = new Dictionary<string, List<Texture2D>>();
        public SpriteFont normalFont;

        public SpriteContainer()
        {

        }

        public void LoadContent(ContentManager content)
        {
            // Normal Font
            normalFont = content.Load<SpriteFont>("Font/NormalFont");

            // The Pixel
            AddSprite(content.Load<Texture2D>("Texture/MainSystem/Pixel"), "Pixel");
            AddSprite(content.Load<Texture2D>("TalentImages/RedPandaMini"), "Panda");

            AddSprite(content.Load<Texture2D>("Texture/D2/Heros/Barbarian"), "barbarian");
            AddSprite(content.Load<Texture2D>("Texture/D2/Heros/necrom"), "necrom");
            AddSprite(content.Load<Texture2D>("Texture/D2/Heros/Sorceress"), "sorceress");

        }

        private void AddSprite(Texture2D texture2D, string name)
        {
            sprite.Add(name, texture2D);
        }

        private void AddSpriteList(List<Texture2D> texture2Ds, string name)
        {
            spriteList.Add(name, texture2Ds);
        }
    }
}
