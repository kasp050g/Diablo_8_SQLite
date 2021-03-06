﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFramework
{
    public class GameObject
    {
        public GameObject MyParent { get; set; }
        public bool IsActive { get; set; }
        public Scene MyScene { get; set; }
        public Transform Transform { get; private set; }

        private Dictionary<string, Component> components = new Dictionary<string, Component>();

        public string Tag { get; set; }
        public Dictionary<string, Component> Components { get => components; set => components = value; }

        public GameObject()
        {
            Transform = new Transform();
            IsActive = true;
        }

        public Component AddComponent(Component component)
        {
            AddComponentsToDictionary(component);

            return component;
        }

        public T AddComponent<T>(Component component) where T : Component
        {
            AddComponentsToDictionary(component);

            return component as T;
        }

        public T AddComponent<T>() where T : Component
        {
            var component = Activator.CreateInstance<T>();
            AddComponentsToDictionary(component);

            return component;
        }

        private void AddComponentsToDictionary(Component component)
        {
            if (!components.ContainsKey(component.ToString()))
            {
                components.Add(component.ToString(), component);
                component.GameObject = this;
            }
            else
            {
                Console.WriteLine("Error: GameObject Line 57 - Try to add same component twice");
            }
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component item in components.Values)
            {
                if (item is T)
                {
                    return item as T;
                }
            }

            return null;
        }

        public void Awake()
        {
            foreach (Component component in components.Values)
            {
                component.Awake();
            }
        }

        public void Start()
        {
            foreach (Component component in components.Values)
            {
                component.Start();
            }
        }

        public void Update()
        {
            if ((MyParent != null ? MyParent.IsActive == true : true))
                foreach (Component component in components.Values)
                {
                    if (component.IsEnabled)
                    {
                        component.Update();
                    }
                }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if ((MyParent != null ? MyParent.IsActive == true : true))
                foreach (Component component in components.Values)
                {
                    if (component.IsEnabled)
                    {
                        component.Draw(spriteBatch);
                    }
                }
        }

        public void Destroy()
        {
            foreach (Component component in components.Values)
            {
                component.Destroy();
            }

            // TODO: Destory gmaeobject in gamework list.
            //GameWorld.Instance.RemoveGameObject(this);
        }
    }
}
