﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFramework
{
    public class Global
    {
        public void LoadContent(ContentManager content)
        {
            SpriteContainer.Instance.LoadContent(content);
            AudioContainer.Instance.LoadContent(content);
        }

        public void Initialize()
        {
            SceneController.Instance.Initialize();
        }

        public void Update(GameTime gameTime)
        {
            Time.Update(gameTime);
            SceneController.Instance.UpdateScenes();
            Input.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SceneController.Instance.DrawScenes(spriteBatch);
        }
    }
}
