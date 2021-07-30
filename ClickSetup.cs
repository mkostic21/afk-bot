using System;

namespace afk_bot
{
    public class ClickSetup
    {
        public static ConsoleKey input;
        public static void randomMode()
        {
            
            Message.displayRandomModeUI();
            do
            {
                input = Console.ReadKey(true).Key;
                //routine here:
            } while (!input.Equals(ConsoleKey.Escape));

            //return to main menu:
            Message.displaySplashScreen();
        }
        public static void manualMode()
        {
            Message.displayManualModeUI();
             do
            {
                input = Console.ReadKey(true).Key;
                //routine here:
            } while (!input.Equals(ConsoleKey.Escape));

            //return to main menu:
            Message.displaySplashScreen();
        }


    }
}