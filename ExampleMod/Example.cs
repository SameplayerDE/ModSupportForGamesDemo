using Game_Mod_Interface;

namespace ExampleMod
{
    public class Example : IMod
    {
        public string Name => "Example";

        public string Description => "Does nothing";

        public string Version => "1.0.0a";

        public string Author => "Me";

        public void Init(IGame game)
        {
            game.RegisterCommand("heal", new ExampleCommand());
        }

        public void Load()
        {
            Console.WriteLine($"{Name}:{Version} > LOAD CALLED");
        }
    }
}