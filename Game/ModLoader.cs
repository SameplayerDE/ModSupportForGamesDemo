using Game_Mod_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class ModLoader
    {
        public static List<IMod> LoadAllMods(string path, IGame game)
        {
            var mods = new List<IMod>();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("DIRECTORY DOES NOT EXIST!");
                return mods;
            }

            foreach (var file in Directory.GetFiles(path, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFile(file);
                    foreach (var type in assembly.GetTypes())
                    {
                        if (typeof(IMod).IsAssignableFrom(type) && !type.IsInterface)
                        {
                            var modInstance = (IMod)Activator.CreateInstance(type);
                            modInstance.Init(game); // Initialisiere den Mod mit dem Game API
                            mods.Add(modInstance);
                        }
                    }
                }
                catch (Exception e)
                {
                    // Logge den Fehler oder zeige eine Fehlermeldung an
                    Console.WriteLine($"ERROR WHILE LOADING MOD FILE {file}: {e.Message}");
                }
            }

            return mods;
        }

        public static void LoadMods(List<IMod> mods)
        {
            foreach (var mod in mods)
            {
                mod.Load();
            }
        }
    }
}
