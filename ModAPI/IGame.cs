using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Mod_Interface
{
    public interface IGame
    {
        public bool RegisterCommand(string key, ICommand command);
        public bool IsRunning { get; }
        public void Stop();
    }
}
