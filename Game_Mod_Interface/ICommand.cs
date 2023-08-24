using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Mod_Interface
{
    public interface ICommand
    {
        public bool Execute(string[] args);
    }
}
