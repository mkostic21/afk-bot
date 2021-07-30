using System;

namespace afk_bot
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey input;
            Message.displaySplashScreen();

            do
            {
                switch (input = Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        ClickSetup.randomMode();
                        break;
                    case ConsoleKey.D2:
                        ClickSetup.manualMode();
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        //help message here?
                        break;
                }
            } while (!input.Equals(ConsoleKey.Escape));
        }
    }
}
