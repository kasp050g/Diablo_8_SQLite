using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameFramework;

namespace Diablo_8_SQLite
{
    public class KasperPlayer_Test : Component
    {
        private float moveSpeed = 200;
        public override void Awake()
        {
            base.Awake();
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();
            Move();
        }

        public void Move()
        {
            Vector2 newMove = new Vector2(0, 0);

            if (Input.GetKey(Keys.W))
            {
                newMove += new Vector2(0, -1);
            }
            if (Input.GetKey(Keys.S))
            {
                newMove += new Vector2(0, 1);
            }
            if (Input.GetKey(Keys.A))
            {
                newMove += new Vector2(-1, 0);
            }
            if (Input.GetKey(Keys.D))
            {
                newMove += new Vector2(1, 0);
            }

            GameObject.Transform.Position += newMove * moveSpeed * Time.deltaTime;
        }
    }
}
