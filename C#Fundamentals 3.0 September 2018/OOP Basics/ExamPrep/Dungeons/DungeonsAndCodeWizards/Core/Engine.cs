using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster master;

        public Engine()
        {
            this.master = new DungeonMaster();
        }

        public void Run()
        {
            string command = Console.ReadLine();
            
            while (!master.IsGameOver() && !string.IsNullOrWhiteSpace(command))
            {
                string[] args = command.Split();
                string type = args[0];
                string[] arr = args.Skip(1).ToArray();

                switch (type)
                {
                    case "JoinParty":
                        Console.WriteLine(master.JoinParty(arr));
                        break;
                }
            }
        }
    }
}
