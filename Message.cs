using System;

namespace afk_bot
{
    public class Message
    {
        public static string title = "*** AFK BOT ***";
        public static string setupMessage;
        public static void displaySplashScreen()
        {
            Console.Clear();

            
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop); //Centers title in console window
            Console.WriteLine(title);

            Console.WriteLine("\nPress [1] to START\tCurrent time is: {0}ms", ClickSetup.time);
            Console.WriteLine("Press [2] for SETUP");
            Console.WriteLine("\nPress [ESC] to EXIT");
            Console.WriteLine("\n");
        }
        public static void displayRandom()
        {
            Console.Clear();
            Console.WriteLine("Running...");
            Console.WriteLine("\nPress [ESC] to STOP");
        }

        public static void displaySetupMessage()
        {
            setupMessage = "Input the time in [ms]: ";
            Console.Write("\n" + setupMessage);
        }

        public static void displaySetupError()
        {
            Console.WriteLine("\nInput must be in INTEGER format and must be inside interval: [200, 5000]");
        }
    }
}