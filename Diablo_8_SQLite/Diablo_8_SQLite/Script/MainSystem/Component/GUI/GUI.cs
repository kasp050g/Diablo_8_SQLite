using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFramework
{
    public class GUI : Component
    {
        #region Fields
        private bool blockGUI = false;
        private bool isWorldUI = false;
        private bool mouseIsHovering = false;
        private SpriteRenderer spriteRenderer;
        #endregion

        #region Properties
        public bool BlockGUI { get => blockGUI; set => blockGUI = value; }
        public bool IsWorldUI { get => isWorldUI; set => isWorldUI = value; }
        public bool MouseIsHovering { get => mouseIsHovering; set => mouseIsHovering = value; }
        public Vector2 SceneSize { get { return GraphicsSetting.Instance.ScreenSize; } }
        public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }

        public virtual Rectangle GUImouseBlockCollision
        {
            get
            {
                // returns a new rectangle based on the position, scale, sprite width and height.
                return new Rectangle(
                    (int)this.GameObject.Transform.Position.X - (int)(this.GameObject.Transform.Origin.X * this.GameObject.Transform.Scale.X),
                    (int)this.GameObject.Transform.Position.Y - (int)(this.GameObject.Transform.Origin.Y * this.GameObject.Transform.Scale.Y),
                    (int)(this.SpriteRenderer.Sprite.Width * this.GameObject.Transform.Scale.X),
                    (int)(this.SpriteRenderer.Sprite.Height * this.GameObject.Transform.Scale.Y)
                    );
            }
        }

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
            mouseIsHovering = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Destroy()
        {
            base.Destroy();
            if (GameObject.MyScene.UIColliders.Contains(this))
                GameObject.MyScene.UIColliders.Remove(this);
        }

        public void OnCollisionEnter(Rectangle other)
        {
            if (BlockGUI)
            {
                if (GUImouseBlockCollision.Intersects(other))
                {
                    GameObject.MyScene.IsMouseOverUI = true;
                    mouseIsHovering = true;
                }
            }
        }

        #endregion
    }
}
