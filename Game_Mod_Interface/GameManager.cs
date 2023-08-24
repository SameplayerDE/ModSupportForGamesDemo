using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Mod_Interface
{
    public class GameManager
    {
        private static IGame _gameInstance;

        public static IGame GameInstance
        {
            get
            {
                return _gameInstance;
            }
        }

        public static void SetGameInstance(IGame game)
        {
            _gameInstance = game;
        }
    }
}
