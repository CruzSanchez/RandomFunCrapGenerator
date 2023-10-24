using RandomFunCrapGeneratorLibrary;
using RandomFunCrapGeneratorLibrary.DataAccess;
using RandomFunCrapGeneratorLibrary.Models;
using System.Runtime.InteropServices;
using static RandomFunCrapGeneratorConsoleUI.ConsoleLogging;
using static RandomFunCrapGeneratorConsoleUI.Enums;
using static RandomFunCrapGeneratorConsoleUI.UserInteractions;

namespace RandomFunCrapGeneratorConsoleUI
{
    internal class Program
    {
        #region MaximizingConsoleWindowSetup
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;
        #endregion

        private static readonly ActivityMaster _activityMaster;
        private const int MILLISECONDS_CONVERSION = 1000;
        private static int asciiArtDelay = 3;
        private static bool keepGoing = false;

        static Program()
        {
            _activityMaster = new ActivityMaster(new DataAccess(), new Random());
        }

        static void Main(string[] args)
        {
            ShowWindow(ThisConsole, MAXIMIZE);

            PrintAsciiTitle();
            PauseConsoleForSeconds(asciiArtDelay);

            IntroText();

            do
            {
                ConsoleKey key = MainMenu();
                keepGoing = MainAction(key);

            } while (keepGoing);

            ClearConsoleWindow();
            ExitText();
            _activityMaster.SaveListsToFile();
        }

        private static bool MainAction(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ConsoleKey generatorKey = GenerateMenu();
                    Activity a = GenerateAction(generatorKey);
                    PassMessage(_activityMaster.GetActivityInfo(a), MessageStatusCode.Info);
                    PassMessage("Press enter to continue...");
                    PressEnter();
                    keepGoing = false;
                    return keepGoing;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    PassMessage("------- Restaurants ----------", MessageStatusCode.Info);
                    _activityMaster.Restaurants.ForEach(x => PassMessage(x.ToJson(), MessageStatusCode.Info));
                    PassMessage("------- Activities ----------", MessageStatusCode.Info);
                    _activityMaster.Adventures.ForEach(x => PassMessage(x.ToJson(), MessageStatusCode.Info));
                    keepGoing = true;
                    return keepGoing;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ConsoleKey addNewKey = AddNewMenu();
                    AddNewAction(addNewKey);
                    keepGoing = true;
                    return keepGoing;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    keepGoing = false;
                    return keepGoing;

                default:
                    PassMessage("Invalid Choice try again...", MessageStatusCode.Error);
                    keepGoing = true;
                    return keepGoing;

            }
        }

        private static Activity GenerateAction(ConsoleKey key)
        {
            Activity a;

            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    a = _activityMaster.GenerateRandomRestaurant();
                    return a;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    a = _activityMaster.GenerateRandomAdventure();
                    return a;
                default:
                    PassMessage("Incorrect choice, generating something to eat", MessageStatusCode.Info);
                    return _activityMaster.GenerateRandomRestaurant();
            }
        }

        private static void AddNewAction(ConsoleKey key)
        {
            Activity a;

            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    a = AddNewPrompt(typeof(Restaurant));
                    _activityMaster.AddNew(a as Restaurant, PassMessage);
                    return;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    a = AddNewPrompt(typeof(Adventure));
                    _activityMaster.AddNew(a as Adventure, PassMessage);
                    return;
                default:
                    PassMessage("Incorrect choice, generating something to eat", MessageStatusCode.Info);
                    _activityMaster.GenerateRandomRestaurant();
                    return;
            }
        }

        private static void PauseConsoleForSeconds(int seconds)
        {
            Thread.Sleep(seconds * MILLISECONDS_CONVERSION);
        }
    }
}