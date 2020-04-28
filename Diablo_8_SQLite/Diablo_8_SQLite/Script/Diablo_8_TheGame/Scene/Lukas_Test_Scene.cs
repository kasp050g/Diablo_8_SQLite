using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using MonogameFramework;
using SQLiteFramework.Framework;
using Script.Generics;
using SQLiteFramework.ExtensionMethods;

namespace Diablo_8_SQLite
{
    public class Lukas_Test_Scene :Scene
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Initialize()
        {
            Singletons.TableContainerSingleton.UsersTable.RenameColumn("Salt", "JohnDoe");

            Singletons.TableContainerSingleton.UsersTable.Update("Name".Pair("John"));
            Singletons.TableContainerSingleton.UsersTable.Update(4, "Name".Pair("John"));
            Singletons.TableContainerSingleton.UsersTable.Update(new List<int>() { 1, 2, 3, 4 }, "Name".Pair("John"));

            (Singletons.TableContainerSingleton.UsersTable as Table).WriteToScreen();

            base.Initialize();
        }

        public override void OnSwitchAwayFromThisScene()
        {
            base.OnSwitchAwayFromThisScene();
        }

        public override void OnSwitchToThisScene()
        {
            base.OnSwitchToThisScene();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
