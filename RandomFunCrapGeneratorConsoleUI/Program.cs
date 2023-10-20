using RandomFunCrapGeneratorLibrary;
using RandomFunCrapGeneratorLibrary.DataAccess;
using static RandomFunCrapGeneratorConsoleUI.ConsoleLogging;

namespace RandomFunCrapGeneratorConsoleUI
{
    internal class Program
    {
        private readonly ActivityMaster _activityMaster;
        public Program()
        {
            _activityMaster = new ActivityMaster(new DataAccess(), new Random());
        }

        static void Main(string[] args)
        {
            PassMessage("Welcome to the fun crap generator");
            PassMessage("1. Generate Random Activity\n2. Review Activities\n3. Add new activity\n4. Exit Application");

            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Environment.Exit(0);
                    return;

            }
        }
    }
}