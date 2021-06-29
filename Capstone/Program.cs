using System;
using Capstone.classes;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleService vendingMachine = new ConsoleService();
            vendingMachine.Run();
        }
    }
}
