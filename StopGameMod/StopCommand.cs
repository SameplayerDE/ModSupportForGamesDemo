using Game_Mod_Interface;

namespace StopGameMod
{
    internal class StopCommand : ICommand
    {
        public bool Execute(string[] args)
        {
            if (args.Length == 0)
            {
                GameManager.GameInstance.Stop();
                return true;
            }
            return false;
        }
    }
}