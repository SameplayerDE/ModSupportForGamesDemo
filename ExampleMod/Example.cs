﻿using Game_Mod_Interface;

namespace ExampleMod
{
    public class Example : IMod
    {
        public string Name => "Example";

        public string Description => "Does nothing";

        public string Version => "1.0.1a";

        public string Author => "Me";

        public void Init(IGame game)
        {
            game.RegisterCommand("heal", new ExampleCommand());
            Console.WriteLine($"{Name}:{Version} > INIT CALLED");
        }

        public void Load(IGame game)
        {
            Console.WriteLine($"{Name}:{Version} > LOAD CALLED");
        }

        public void Unload(IGame game)
        {
            game.UnregisterCommand("heal");
            Console.WriteLine($"{Name}:{Version} > UNLOAD CALLED");
        }
    }
}