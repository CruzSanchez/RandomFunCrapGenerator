using static RandomFunCrapGeneratorConsoleUI.Enums;

namespace RandomFunCrapGeneratorConsoleUI
{
    internal static class ConsoleLogging
    {
        internal static void PassMessage(string message, MessageStatusCode messageStatusCode = MessageStatusCode.NoCode)
        {
            switch (messageStatusCode)
            {
                case MessageStatusCode.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                    Console.ForegroundColor = default;
                    break;
                case MessageStatusCode.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message);
                    Console.ForegroundColor = default;
                    break;
                case MessageStatusCode.Info:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(message);
                    Console.ForegroundColor = default;
                    break;
                default:
                    Console.WriteLine(message);
                    break;

            }
        }
    }
}
