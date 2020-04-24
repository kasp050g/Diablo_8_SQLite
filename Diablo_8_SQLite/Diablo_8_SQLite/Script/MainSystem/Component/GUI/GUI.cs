using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameFramework
{
    public abstract class GUI : Component
    {
        #region Fields
        private Texture2D sprite;
        private Color color = Color.White;
        private SpriteEffects spriteEffects = SpriteEffects.None;
        private float layerDepth = 0;
        private OriginPositionEnum originPositionEnum = OriginPositionEnum.TopLeft;
        private Vector2 offSet = new Vector2(0, 0);
        private bool blockGUI = false;
        private bool isWorldUI = false;
        #endregion

        #region Properties
        public Texture2D Sprite { get => sprite; set => sprite = value; }
        public Color Color { get => color; set => color = value; }
        public SpriteEffects SpriteEffects { get => spriteEffects; set => spriteEffects = value; }
        public float LayerDepth { get => layerDepth; set => layerDepth = value; }
        public OriginPositionEnum OriginPositionEnum { get => originPositionEnum; set => originPositionEnum = value; }
        public Vector2 OffSet { get => offSet; set => offSet = value; }
        public bool BlockGUI { get => blockGUI; set => blockGUI = value; }
        public bool IsWorldUI { get => isWorldUI; set => isWorldUI = value; }
        #endregion

        #region Constructors
        public GUI()
        {

        }
        #endregion

        #region Methods 
        public override void Awake()
        {
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
            base.Draw(spriteBatch);
        }

        public override void Destroy()
        {
            base.Destroy();
        }
        #endregion
    }
}
