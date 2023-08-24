using Game_Mod_Interface;

namespace Game.Commands
{
    internal class ModCommand : ICommand
    {
        public bool Execute(string[] args)
        {
            if (args.Length == 0)
            {
                var loadedMods = ModLoader.LoadedMods;
                if (loadedMods.Count > 0)
                {
                    Console.WriteLine("These Mods Are Currently Loaded:");
                    foreach ( var mod in loadedMods)
                    {
                        Console.WriteLine($" - {mod.Name}");
                        Console.WriteLine($"   - {mod.Author}");
                        Console.WriteLine($"   - {mod.Version}");
                        Console.WriteLine($"   - {mod.Description}");
                    }
                }
                return true;
            }
            if (args.Length == 1)
            {
                if (args[0].Equals("reload", StringComparison.OrdinalIgnoreCase))
                {
                    var game = GameImplementation.Instance;

                    //Unload first
                    var loadedMods = ModLoader.LoadedMods;
                    if (loadedMods.Count > 0)
                    {
                        foreach (var mod in loadedMods)
                        {
                            mod.Unload(game);
                        }
                    }

                    var mods = ModLoader.LoadAllMods(GameImplementation.ModPath, game);
                    ModLoader.LoadMods(mods, game);

                    return true;

                }
                
                return true;
            }
            return false;
        }
    }
}
