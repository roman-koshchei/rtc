using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rtc;

namespace cli
{
    internal class Top
    {
        private Dictionary<string, Action<List<string>>> commands;

        public Top()
        {
            commands = new()
            {
                { "run", Run }
            };
        }

        public void Execute(string command, List<string> args)
        {
            try
            {
                if (commands.ContainsKey(command))
                {
                    commands[command](args);
                }
                else
                {
                    Console.WriteLine("Command doesn't exist");
                }
            }
            catch
            {
            }
        }

        private void Run(List<string> args)
        {
            Rtc rtc = new();
        }

        /// <summary>
        /// Add new rtc to local 
        /// </summary>
        private void Add(List<string> args)
        {
        }
    }
}