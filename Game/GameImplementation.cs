using Game;
using Game.Commands;
using Game_Mod_Interface;
using System.Diagnostics.Tracing;

namespace Game
{

    public class GameImplementation : IGame
    {
        private Dictionary<string, ICommand> _commands = new();
        private bool _running = false;

        public static string GlobalPath;
        public static string ModPath;
        public static GameImplementation Instance;

        public bool IsRunning => _running;

        public GameImplementation()
        {
            Instance = this;
            GameManager.SetGameInstance(Instance);
        }

        public bool RegisterCommand(string key, ICommand command)
        {
            if (_commands.ContainsKey(key))
            {
                return false;
            }
            _commands.Add(key, command);
            return true;
        }


        public bool UnregisterCommand(string key)
        {
            if (_commands.ContainsKey(key))
            {
                _commands.Remove(key);
                return true;
            }
            return false;
        }

        public void Stop()
        {
            _running = false;
        }

        internal void Run()
        {

            //DO GLOBAL STUFF

            GlobalPath = CreateGlobalGameFolder(".ModSupportExample");
            ModPath = CreateFolder(Path.Combine(GlobalPath, "Mods"));

            //DO GAME STUFF

            RegisterCommand("mod", new ModCommand());

            //DO MOD STUFF

            var mods = ModLoader.LoadAllMods(ModPath, this);
            ModLoader.LoadMods(mods, this);

            //START GAME

            _running = true;

            while (_running)
            {
                Console.Write("> ");
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