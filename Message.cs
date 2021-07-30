using System;

namespace afk_bot
{
    public class Message
    {
        public static void displaySplashScreen()
        {
            Console.WriteLine("\t\t\t*** AFK BOT MENU ***");
            Console.WriteLine("\nPress [1] for random clicks\nPress [2] for manual click setup\nPress [ESC] to EXIT at any moment");
            Console.WriteLine("\n");
        }

        public static void displayRandomModeUI()
        {
            Console.Clear();
            Console.WriteLine("Press [ESC] to go back to previous menu");
            //routine msg here:

        }
        public static void displayManualModeUI()
        {
            Console.Clear();
            Console.WriteLine("Press [ESC] to go back to previous menu");
            //routine msg here:
        }
    }
}