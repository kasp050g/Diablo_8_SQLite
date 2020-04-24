using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameFramework
{
    public interface IGameListner
    {
        void Notify(GameEvent gameEvent, Component other);
    }
}
