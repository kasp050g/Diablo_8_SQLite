using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFramework
{
    public class TextGUI : GUI
    {
        #region Fields
        Color fontColor = Color.Black;
        SpriteFont spriteFont;
        string text = string.Empty;
        Vector2 fontScale = new Vector2(1, 1);
        float layerDepth = 0;
        #endregion

        #region Properties
        public Color FontColor { get => fontColor; set => fontColor = value; }
        public SpriteFont SpriteFont { get => spriteFont; set => spriteFont = value; }
        public string Text { get => text; set => text = value; }
        public Vector2 FontScale { get => fontScale; set => fontScale = value; }
        public float LayerDepth { get => layerDepth; set => layerDepth = value; }
        #endregion

        #region Constructors
        public TextGUI(SpriteFont spriteFont, Color fontColor, Vector2 fontScale, string text)
        {
            this.spriteFont = spriteFont;
            this.spriteFont = spriteFont;
            this.fontColor = fontColor;
            this.fontScale = fontScale;
            this.text = text;
        }
        #endregion

        #region Methods 
        public override void Awake()
        {
            if (spriteFont == null)
            {
                this.spriteFont = SpriteContainer.Instance.normalFont;
            }
            base.Awake();
        }
        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                spriteBatch.DrawString(
                    // SpriteFont
                    SpriteFont,
                    // String text
                    Text,
                    // Position
                    GameObject.Transform.Position,
                    // Color
                    fontColor,
                    // Rotation
                    MathHelper.ToRadians(this.GameObject.Transform.Rotation),
                    // Origin
                    Vector2.Zero,
                    // Scale
                    FontScale,
                    // SpriteEffects
                    SpriteEffects.None,
                    // LayerDepth
                    LayerDepth
                );
            }
        }

        public override void Destroy()
        {
            base.Destroy();
        }
        #endregion
    }
}
