using RandomFunCrapGeneratorLibrary;
using RandomFunCrapGeneratorLibrary.Models;
using static RandomFunCrapGeneratorConsoleUI.ConsoleLogging;
using static RandomFunCrapGeneratorConsoleUI.Enums;

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

        internal static ConsoleKey AddNewMenu()
        {
            PassMessage("1. Add new restaurant\n2. Add new activity");
            return GetUserResponseKey();
        }

        internal static Activity AddNewPrompt(Type t)
        {
            Activity a = ActivityFactory.CreateNewActivity(t);

            PassMessage("What is the Name?");
            a.Name = GetUserResponseString();
            PassMessage("What is the Description?");
            a.Description = GetUserResponseString();
            PassMessage("What is the Address?");
            a.Address = GetUserResponseString();
            PassMessage("What is the best time to go eat? example: 09:30 OR 17:00");
            a.OptimalTime = GetUserResponseTime();
            PassMessage("What is the rating? example: 3.1 OR 5");
            a.StarRating = GetUserResponseFloat();

            return a;
        }

        private static float GetUserResponseFloat()
        {
            float stars;

            while (!float.TryParse(Console.ReadLine(), out stars))
            {
                PassMessage("Incorrect format, please try again", MessageStatusCode.Error);
            }

            return stars;
        }

        private static string GetUserResponseString()
        {
            return Console.ReadLine() ?? "";
        }

        private static TimeOnly GetUserResponseTime()
        {
            TimeOnly time;

            while (!TimeOnly.TryParse(Console.ReadLine(), out time))
            {
                PassMessage("Incorrect format, please try again", MessageStatusCode.Error);
            }

            return time;
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
