using System;

namespace afk_bot
{
    public class Message
    {
        public static void displaySplashScreen()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t*** AFK BOT MENU ***");
            Console.WriteLine("\nPress [1] to begin\nPress [ESC] to EXIT");
            Console.WriteLine("\n");
        }
        public static void displayRandom() {
            Console.Clear();
            Console.WriteLine("Running...\nPress [ESC] to EXIT");
        }
    }
}