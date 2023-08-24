using Game_Mod_Interface;

namespace StopGameMod
{
    public class Main : IMod
    {
        public string Name => "StopGameMod";

        public string Description => "Adds a command to stop the game";

        public string Version => "12.4.5";

        public string Author => "Steve F. Jobs";

        public void Init(IGame game)
        {
            game.RegisterCommand("stop", new StopCommand());
            Console.WriteLine($"{Name}:{Version} > INIT CALLED");
        }

        public void Load(IGame game)
        {
            Console.WriteLine($"{Name}:{Version} > LOAD CALLED");
        }

        public void Unload(IGame game)
        {
            game.UnregisterCommand("stop");
            Console.WriteLine($"{Name}:{Version} > UNLOAD CALLED");
        }
    }
}