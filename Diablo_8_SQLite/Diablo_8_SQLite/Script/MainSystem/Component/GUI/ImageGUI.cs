﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFramework
{
    public class ImageGUI : GUI
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public ImageGUI()
        {

        }

        public ImageGUI(SpriteRenderer spriteRenderer,bool isWorldUI,bool blockUI)
        {
            this.SpriteRenderer = spriteRenderer;
            this.IsWorldUI = isWorldUI;
            this.BlockGUI = blockUI;
        }
        public ImageGUI(SpriteRenderer spriteRenderer, bool isWorldUI, bool blockUI,Color color,OriginPositionEnum originPositionEnum)
        {
            this.SpriteRenderer = spriteRenderer;
            this.IsWorldUI = isWorldUI;
            this.BlockGUI = blockUI;
            this.SpriteRenderer.Color = color;
            this.SpriteRenderer.OriginPositionEnum = originPositionEnum;
        }
        #endregion

        #region Methods 
        public override void Awake()
        {
            if(this.SpriteRenderer == null)
            {
                this.SpriteRenderer = GameObject.GetComponent<SpriteRenderer>();
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
            base.Draw(spriteBatch);
        }

        public override void Destroy()
        {
            base.Destroy();
        }
        #endregion
    }
}