using System;

namespace afk_bot
{
    class Program
    {
        public static ConsoleKey input;
        static void Main(string[] args)
        {
            Message.displaySplashScreen();
            do
            {
                switch (input = Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        ClickSetup.randomMode();
                        break;
                    case ConsoleKey.D2:
                        ClickSetup.setupMode();
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Exiting...");
                        break;
                }
            } while (!input.Equals(ConsoleKey.Escape)); //loops until [ESC] is pressed
        }
    }
}
