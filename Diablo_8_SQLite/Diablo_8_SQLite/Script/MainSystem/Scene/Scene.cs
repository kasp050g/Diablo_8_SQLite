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
    public class Scene
    {
        protected string name;
        protected bool updateEnabled;
        protected bool drawEnabled;
        protected bool pauseGame;
        protected bool isMouseOverUI = false;
        protected bool isInitialized;

        protected List<GameObject> gameObjects = new List<GameObject>();
        protected List<GameObject> guis = new List<GameObject>();

        public List<Collider> Colliders { get; set; } = new List<Collider>();

        protected List<GameObject> gameObjectsToBeCreated = new List<GameObject>();
        protected List<GameObject> gameObjectsToBeDestroyed = new List<GameObject>();

        public string Name { get { return name; } set { name = value; } }
        public bool UpdateEnabled { get { return updateEnabled; } set { updateEnabled = value; } }
        public bool DrawEnabled { get { return drawEnabled; } set { drawEnabled = value; } }
        public bool PauseGame { get => pauseGame; set => pauseGame = value; }
        public bool IsMouseOverUI { get => isMouseOverUI; set => isMouseOverUI = value; }


        public virtual void Initialize()
        {
            isInitialized = true;
        }

        public virtual void OnSwitchToThisScene()
        {
            if (isInitialized == false)
            {
                this.Initialize();
            }
        }

        public virtual void OnSwitchAwayFromThisScene()
        {

        }

        public virtual void Update()
        {
            CheckForGUI();
            if (!pauseGame)
            {
                foreach (GameObject gameObject in gameObjects)
                {
                    if (gameObject.IsActive)
                    {
                        gameObject.Update();
                    }
                }
            }

            if (Input.GetKeyDown(Keys.P))
            {
                pauseGame = !pauseGame;
            }

            foreach (GameObject gameObject in guis)
            {
                if (gameObject.IsActive)
                {
                    gameObject.Update();
                }
            }

            ColliderCheck();

            CallDestroyGameObject();
            CallInstantiate();
            SceneController.Instance.Camera.Update();
            IsMouseOverUI = false;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            // Draw all GameObjects
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, transformMatrix: SceneController.Instance.Camera.Transform);
            foreach (GameObject item in gameObjects)
            {
                item.Draw(spriteBatch);
            }
            spriteBatch.End();

            // Draw all GUIs
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            foreach (GameObject item in guis)
            {
                item.Draw(spriteBatch);
            }
            spriteBatch.End();
        }



        public void CheckForGUI()
        {
            MouseState currentMouse = Mouse.GetState();
            Rectangle mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            foreach (GameObject x in guis)
            {
                //if ((x is GUI) && mouseRectangle.Intersects((x as GUI).GUImouseBlockCollision) && x.IsActive == true)
                //{
                //    IsMouseOverUI = true;
                //}
            }
        }

        public void ColliderCheck()
        {
            Collider[] tmpColliders = Colliders.ToArray();

            for (int i = 0; i < tmpColliders.Length; i++)
            {
                for (int j = 0; j < tmpColliders.Length; j++)
                {
                    tmpColliders[i].OnCollisionEnter(tmpColliders[j]);
                }
            }
        }
        

        #region Instantiate And Destroy
        /// <summary>
        /// Will instantiate a new gameObject in to the game.
        /// </summary>
        /// <param name="gameObject">The GameObject to be add to game.</param>
        public void Instantiate(GameObject gameObject)
        {
            this.gameObjectsToBeCreated.Add(gameObject);
        }
        /// <summary>
        /// Will destroy this gameobject
        /// </summary>
        /// <param name="gameObject">destroy this gameobject</param>
        public void Destroy(GameObject gameObject)
        {
            this.gameObjectsToBeDestroyed.Add(gameObject);
        }
        /// <summary>
        /// Call this to Destroy all GameObjects
        /// </summary>
        public void DestroyAllGameObjects()
        {
            this.gameObjects.Clear();
            this.guis.Clear();
        }
        /// <summary>
        /// Add all GameObjects To Be Created to current GameObject List.
        /// </summary>
        private void CallInstantiate()
        {
            if (this.gameObjectsToBeCreated.Count > 0)
            {
                foreach (GameObject go in gameObjectsToBeCreated)
                {
                    go.Awake();
                    go.Start();
                    gameObjects.Add(go);

                    if(go.GetComponent<Collider>() != null)
                    {
                        Colliders.Add(go.GetComponent<Collider>());
                    }
                }

                gameObjectsToBeCreated.Clear();
            }
        }
        /// <summary>
        /// TODO
        /// Remove all GameObjects To Be Remove from current GameObject List.
        /// </summary>
        private void CallDestroyGameObject()
        {
            if (this.gameObjectsToBeDestroyed.Count > 0)
            {
                
            }
        }
        #endregion
    }
}
