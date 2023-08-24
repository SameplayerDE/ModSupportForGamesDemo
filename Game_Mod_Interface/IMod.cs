using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Mod_Interface
{
    public interface IMod
    {
        public string Name { get; }
        public string Description { get; }
        public string Version { get; }
        public string Author { get; }

        public void Init(IGame game);
        public void Load();
    }
}
