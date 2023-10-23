using static RandomFunCrapGeneratorConsoleUI.ConsoleLogging;

namespace RandomFunCrapGeneratorConsoleUI
{
    internal static class UserInteractions
    {
        internal static ConsoleKey GetUserResponseKey()
        {
            var key = Console.ReadKey(true).Key;
            PassMessage(string.Empty);
            return key;
        }

        internal static void IntroText()
        {
            PassMessage("Welcome to the fun crap generator");
        }

        internal static void ExitText()
        {
            PassMessage("Goodbye...");
        }

        internal static ConsoleKey GenerateMenu()
        {
            PassMessage("1. Generate Restaurant to eat at\n2. Generate Activity to go do");
            return GetUserResponseKey();
        }

        internal static ConsoleKey MainMenu()
        {
            PassMessage("1. Generate Random Activity\n2. Review Activities\n3. Add new activity\n4. Exit Application");
            return GetUserResponseKey();
        }

        internal static void PrintAsciiTitle()
        {
            Console.WriteLine(" .----------------.  .----------------.  .----------------.  .----------------. " +
                "\r\n| .--------------. || .--------------. || .--------------. || .--------------. |" +
                "\r\n| |  _______     | || |  _________   | || |     ______   | || |    ______    | |" +
                "\r\n| | |_   __ \\    | || | |_   ___  |  | || |   .' ___  |  | || |  .' ___  |   | |" +
                "\r\n| |   | |__) |   | || |   | |_  \\_|  | || |  / .'   \\_|  | || | / .'   \\_|   | |" +
                "\r\n| |   |  __ /    | || |   |  _|      | || |  | |         | || | | |    ____  | |" +
                "\r\n| |  _| |  \\ \\_  | || |  _| |_       | || |  \\ `.___.'\\  | || | \\ `.___]  _| | |" +
                "\r\n| | |____| |___| | || | |_____|      | || |   `._____.'  | || |  `._____.'   | |" +
                "\r\n| |              | || |              | || |              | || |              | |" +
                "\r\n| '--------------' || '--------------' || '--------------' || '--------------' |" +
                "\r\n '----------------'  '----------------'  '----------------'  '----------------' ");
        }
    }
}
