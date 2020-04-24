using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFramework
{
    public abstract class Component
    {
        #region Fields
        #endregion

        #region Methods 
        public bool IsEnabled { get; set; } = true;
        public GameObject GameObject { get; set; }
        #endregion

        #region Constructors 
        #endregion

        #region Methods 
        public virtual void Awake()
        {

        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        public virtual void Destroy()
        {

        }
        #endregion
    }
}
