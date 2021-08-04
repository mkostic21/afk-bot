using System;
using System.Threading;

namespace afk_bot
{
    public class ClickSetup
    {
        public static Random random = new Random();
        public static ConsoleKey input;
        public static int x, y, time = 200; //default 200ms
        public static bool valid = false;
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
                    System.Threading.Thread.Sleep(time);
                }
            } while (!Console.ReadKey(true).Key.Equals(ConsoleKey.Escape)); //ESC is not pressed

            Message.displaySplashScreen();
        }

        public static void setupMode()
        {
            Console.Clear();

            do
            {
                Message.displaySetup();
                try
                {
                    int temp = Convert.ToInt32(Console.ReadLine()); //TODO: ReadLine with ESC to EXIT support
                    if (temp >= 200 && temp <= 5000)
                    {
                        valid = true;
                        time = temp;
                    }
                    else { Message.displaySetupError(); }
                }
                catch (System.FormatException)
                {
                    Message.displaySetupError();
                }
            } while (!valid);

            Message.displaySplashScreen();
        }

    }

}