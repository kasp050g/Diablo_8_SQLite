using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameFramework
{
    public class ImageGUI : GUI
    {
        #region Fields
        #endregion

        #region Methods 
        #endregion

        #region Constructors 
        public ImageGUI(Texture2D sprite, Vector2 position, float layerDepth, OriginPositionEnum originPosition)
        {
            this.Sprite = sprite;
            this.GameObject.Transform.Position = position;
            this.LayerDepth = layerDepth;
            this.OriginPositionEnum = originPosition;
        }
        public ImageGUI(Texture2D sprite, Vector2 position, float layerDepth, OriginPositionEnum originPosition, bool isWorldUI)
        {
            this.Sprite = sprite;
            this.GameObject.Transform.Position = position;
            this.LayerDepth = layerDepth;
            this.OriginPositionEnum = originPosition;
            this.IsWorldUI = isWorldUI;
        }
        public ImageGUI(Texture2D sprite, Vector2 position, float layerDepth, OriginPositionEnum originPosition, bool isWorldUI, Color color)
        {
            this.Sprite = sprite;
            this.GameObject.Transform.Position = position;
            this.LayerDepth = layerDepth;
            this.OriginPositionEnum = originPosition;
            this.IsWorldUI = isWorldUI;
            this.Color = color;
        }
        #endregion

        #region Methods 
        public override void Awake()
        {

        }

        public override void Start()
        {

        }

        public override void Update()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                // Texture2D
                this.Sprite,
                // Postion
                this.GameObject.Transform.Position + OffSet,
                // Source Rectangle
                null,
                // Color
                this.Color,
                // Rotation
                MathHelper.ToRadians(this.GameObject.Transform.Rotation),
                // Origin
                this.GameObject.Transform.Origin,
                // Scale
                this.GameObject.Transform.Scale,
                // SpriteEffects
                this.SpriteEffects,
                // LayerDepth
                this.LayerDepth
            );
        }

        public override void Destroy()
        {

        }
        #endregion
    }
}
