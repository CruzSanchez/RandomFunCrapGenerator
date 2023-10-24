using static RandomFunCrapGeneratorConsoleUI.Enums;

namespace RandomFunCrapGeneratorConsoleUI
{
    internal static class ConsoleLogging
    {
        internal static void PassMessage(string message, MessageStatusCode messageStatusCode)
        {
            switch (messageStatusCode)
            {
                case MessageStatusCode.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case MessageStatusCode.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case MessageStatusCode.Info:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                default:
                    Console.WriteLine(message);
                    break;

            }
        }

        internal static void PassMessage(string message)
        {
            Console.WriteLine(message);
        }

        internal static void ClearConsoleWindow()
        {
            Console.Clear();
        }
    }
}
