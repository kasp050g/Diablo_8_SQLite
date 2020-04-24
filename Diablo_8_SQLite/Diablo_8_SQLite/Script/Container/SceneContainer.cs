using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diablo_8_SQLite;

namespace MonogameFramework
{
    public class SceneContainer
    {
        private List<Scene> scenes = new List<Scene>();
        public List<Scene> Scenes { get => scenes; set => scenes = value; }

        public void Initialize()
        {
            MakeScenes();
        }

        public void MakeScenes()
        {
            _Pick_Scene_Test pick_Scene_Test = new _Pick_Scene_Test()
            {
                Name = "pick_Scene_Test"
            };
            Scenes.Add(pick_Scene_Test);

            MainScene mainScene = new MainScene()
            {
                Name = "mainScene"
            };
            Scenes.Add(mainScene);

            Kasper_Test_Scene kasper_Test_Scene = new Kasper_Test_Scene()
            {
                Name = "kasper_Test_Scene"
            };
            Scenes.Add(kasper_Test_Scene);

            Asmund_Test_Scene asmund_Test_Scene = new Asmund_Test_Scene()
            {
                Name = "asmund_Test_Scene"
            };
            Scenes.Add(asmund_Test_Scene);

            Lukas_Test_Scene lukas_Test_Scene = new Lukas_Test_Scene()
            {
                Name = "lukas_Test_Scene"
            };
            Scenes.Add(lukas_Test_Scene);
        }
    }
}
