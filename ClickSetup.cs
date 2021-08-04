using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace afk_bot
{
    public class ClickSetup
    {
        public static Random random = new Random();
        public static ConsoleKey input;
        public static int x, y;
        public static CancellationToken ct = new CancellationToken();

        public static void randomMode()
        {
            Message.displayRandom();
            do
            {
                while (!Console.KeyAvailable)
                {
                    x = random.Next(0, 1920);
                    y = random.Next(0, 1080);
                    MouseOperations.SetCursorPosition(x, y);
                    System.Threading.Thread.Sleep(200); //TODO: set time from input
                }
            } while (!Console.ReadKey(true).Key.Equals(ConsoleKey.Escape)); //ESC is not pressed

            Message.displaySplashScreen();
        }

    }

}