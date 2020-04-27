﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFramework
{
    public class ButtonGUI : GUI
    {
        #region Fields
        Action onClick;

        Color color = Color.White;
        Color colorHovering = Color.White;
        Color fontColor = Color.Black;

        Texture2D image;
        Texture2D imageHovering;

        SpriteFont spriteFont;
        string text = string.Empty;
        Vector2 fontScale = new Vector2(1, 1);

        #endregion

        #region Properties
        public Action OnClick { get => onClick; set => onClick = value; }
        public Color Color { get => color; set => color = value; }
        public Color ColorHovering { get => colorHovering; set => colorHovering = value; }
        public Color FontColor { get => fontColor; set => fontColor = value; }
        public Texture2D Image { get => image; set => image = value; }
        public Texture2D ImageHovering { get => imageHovering; set => imageHovering = value; }
        public SpriteFont SpriteFont { get => spriteFont; set => spriteFont = value; }
        public string Text { get => text; set => text = value; }
        public Vector2 FontScale { get => fontScale; set => fontScale = value; }
        #endregion

        #region Constructors
        public ButtonGUI(SpriteRenderer spriteRenderer, Texture2D image, Texture2D imageHovering, Color color, Color colorHovering)
        {
            this.SpriteRenderer = spriteRenderer;
            this.image = image;
            this.imageHovering = imageHovering;
            this.color = color;
            this.colorHovering = colorHovering;
            BlockGUI = true;
        }
        public ButtonGUI(SpriteRenderer spriteRenderer, Texture2D image, Texture2D imageHovering, Color color, Color colorHovering, SpriteFont spriteFont, Color fontColor, Vector2 fontScale, string text)
        {
            this.SpriteRenderer = spriteRenderer;
            this.image = image;
            this.imageHovering = imageHovering;
            this.color = color;
            this.colorHovering = colorHovering;
            this.spriteFont = spriteFont;
            this.spriteFont = spriteFont;
            this.fontColor = fontColor;
            this.fontScale = fontScale;
            this.text = text;
            BlockGUI = true;
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
            if (MouseIsHovering)
            {
                if(SpriteRenderer.Sprite != image)
                {
                    SpriteRenderer.Sprite = image;
                    SpriteRenderer.Color = color;
                }
                if (Input.GetMouseButtonDown(MyMouseButtonsEnum.LeftButton))
                {
                    if (OnClick != null)
                    {
                        OnClick();
                    }
                }
            }
            else
            {
                if (SpriteRenderer.Sprite != imageHovering)
                {
                    SpriteRenderer.Sprite = imageHovering;
                    SpriteRenderer.Color = colorHovering;
                }
            }
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                var x = (GUImouseBlockCollision.X + (GUImouseBlockCollision.Width / 2)) - (SpriteFont.MeasureString(Text).X / 2) * FontScale.X;
                var y = (GUImouseBlockCollision.Y + (GUImouseBlockCollision.Height / 2)) - (SpriteFont.MeasureString(Text).Y / 2) * FontScale.Y;

                spriteBatch.DrawString(
                    // SpriteFont
                    SpriteFont,
                    // String text
                    Text,
                    // Position
                    new Vector2(x, y),
                    // Color
                    fontColor,
                    // Rotation
                    MathHelper.ToRadians(this.GameObject.Transform.Rotation),
                    // Origin
                    Vector2.Zero,
                    // Scale
                    FontScale,
                    // SpriteEffects
                    SpriteRenderer.SpriteEffects,
                    // LayerDepth
                    SpriteRenderer.LayerDepth + 0.00001f
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