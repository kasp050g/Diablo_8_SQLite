using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFramework
{
    public class InputFieldGUI : GUI
    {
        #region Fields
        Color color = Color.White;
        Color fontColor = Color.Black;
        Color placeholderFontColor = Color.Gray;
        Texture2D image;
        SpriteFont spriteFont;
        Vector2 fontScale = new Vector2(1, 1);
        string placeholderText = "";
        string text = string.Empty;
        bool currentSelected = false;
        float inputCooldown = 0.15f;
        float currentInputCooldown = 0;
        #endregion

        #region Properties
        public Color Color { get => color; set => color = value; }
        public Color FontColor { get => fontColor; set => fontColor = value; }
        public Texture2D Image { get => image; set => image = value; }
        public SpriteFont SpriteFont { get => spriteFont; set => spriteFont = value; }
        public Vector2 FontScale { get => fontScale; set => fontScale = value; }
        public string PlaceholderText { get => placeholderText; set => placeholderText = value; }
        public string Text { get => text; set => text = value; }
        #endregion

        #region Constructors
        public InputFieldGUI(SpriteRenderer spriteRenderer, Texture2D image, Color color, SpriteFont spriteFont, Color fontColor, Vector2 fontScale, string placeholderText)
        {
            this.SpriteRenderer = spriteRenderer;
            this.image = image;
            this.color = color;
            this.spriteFont = spriteFont;
            this.fontColor = fontColor;
            this.fontScale = fontScale;
            this.placeholderText = placeholderText;
            BlockGUI = true;
        }
        #endregion

        #region Methods 
        public override void Awake()
        {
            if (SpriteRenderer == null)
            {
                if (GameObject.GetComponent<SpriteRenderer>() != null)
                {
                    SpriteRenderer = GameObject.GetComponent<SpriteRenderer>();
                }
                else
                {
                    //GameObject.AddComponent<SpriteRenderer>(new SpriteRenderer(image));
                }
            }
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
            SelectedInputField();
            KeyBordInputText();

            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var x = (GUImouseBlockCollision.X + (GUImouseBlockCollision.Width / 2)) - (SpriteFont.MeasureString((text != string.Empty ? text : (currentSelected == true ? " " : placeholderText))).X / 2) * FontScale.X;
            var y = (GUImouseBlockCollision.Y + (GUImouseBlockCollision.Height / 2)) - (SpriteFont.MeasureString((text != string.Empty ? text : (currentSelected == true ? " " : placeholderText))).Y / 2) * FontScale.Y;

            spriteBatch.DrawString(
                // SpriteFont
                SpriteFont,
                // String text
                (text != string.Empty ? text : (currentSelected == true ? "" : placeholderText)) + (currentSelected == true ? "|" : ""),
                // Position
                new Vector2(x, y),
                // Color
                (text != string.Empty ? fontColor : placeholderFontColor),
                // Rotation
                MathHelper.ToRadians(this.GameObject.Transform.Rotation),
                // Origin
                Vector2.Zero,
                // Scale
                FontScale,
                // SpriteEffects
                SpriteRenderer.SpriteEffects,
                // LayerDepth
                SpriteRenderer.LayerDepth+0.00001f
            );
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        public void SelectedInputField()
        {
            if (MouseIsHovering && !Input.GetMouseButtonDown(MyMouseButtonsEnum.RightButton))
            {
                if (Input.GetMouseButtonDown(MyMouseButtonsEnum.LeftButton))
                {
                    currentSelected = true;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(MyMouseButtonsEnum.LeftButton) || Input.GetMouseButtonDown(MyMouseButtonsEnum.RightButton))
                {
                    currentSelected = false;
                }
            }
        }

        public void KeyBordInputText()
        {
            if(currentSelected == true && currentInputCooldown <= 0)
            {
                // Get current state of keyboard.
                KeyboardState keyboardState = Keyboard.GetState();
                // Check if any keys are Pressed's
                Keys[] getPressedKeys = keyboardState.GetPressedKeys();

                foreach (Keys key in getPressedKeys)
                {
                    if(key == Keys.Back && text.Length > 0)
                    {
                        text = text.Remove(text.Length - 1);
                        currentInputCooldown = inputCooldown;
                    }
                    else if (!(key == Keys.Back))
                    {
                        if(key != Keys.LeftShift && key != Keys.RightShift)
                        {
                            text += key.ToString();
                            currentInputCooldown = inputCooldown;
                        }
                    }                    
                }
                
            }
            else if(currentSelected == true)
            {
                if(currentInputCooldown > 0)
                {
                    currentInputCooldown -= Time.deltaTime;
                }
            }
        }
        #endregion
    }
}
