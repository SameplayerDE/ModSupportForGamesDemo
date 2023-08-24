using Game_Mod_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMod
{
    internal class ExampleCommand : ICommand
    {
        public bool Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("HEAL CALLED BUT NO VALUE PASSED");
                return true;
            }
            if (args.Length == 1)
            {
                if (int.TryParse(args[0], out var amount))
                {
                    Console.WriteLine($"HEALED BY {amount}");
                }
                else
                {
                    Console.WriteLine("NOT A NUMBER");
                }
                return true;
            }
            return false;
        }
    }
}
