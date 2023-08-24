using Game;
using Game_Mod_Interface;
using System.Diagnostics.Tracing;

namespace Game
{

    public class GameImplementation : IGame
    {
        private Dictionary<string, ICommand> _commands = new();
        private bool _running = false;

        public bool IsRunning => _running;

        public bool RegisterCommand(string key, ICommand command)
        {
            if (_commands.ContainsKey(key))
            {
                return false;
            }
            _commands.Add(key, command);
            return true;
        }

        public void Stop()
        {
            _running = false;
        }

        internal void Run()
        {

            //DO GLOBAL STUFF

            var globalPath = CreateGlobalGameFolder(".ModSupportExample");
            var modFolder = CreateFolder(Path.Combine(globalPath, "Mods"));

            //DO GAME STUFF



            //DO MOD STUFF

            var mods = ModLoader.LoadAllMods(modFolder, this);
            ModLoader.LoadMods(mods);

            //START GAME

            _running = true;

            while (_running)
            {
                string input = Console.ReadLine().ToLower().Trim();
                input = System.Text.RegularExpressions.Regex.Replace(input, @"\s+", " "); // Diese Zeile ändert den String entsprechend deinen Wünschen
                string[] parts = input.Split(' ');
                string commandKey = parts[0];
                if (_commands.ContainsKey(commandKey))
                {
                    _commands[commandKey].Execute(parts[1..]);
                }
                else
                {
                    Console.WriteLine("UNKNOWN COMMAND");
                }
            }
        }


        private static string CreateGlobalGameFolder(string key)
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), key);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }

        private static string CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }
}