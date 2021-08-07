using System;
using System.Text;
using System.Threading;

namespace afk_bot
{
    public class ClickSetup
    {
        public static Random random = new Random();
        public static int x, y, time = 200; //default 200ms
        public static void randomMode()
        {
            Message.displayRandom();
            do
            {
                while (!Console.KeyAvailable)
                {
                    x = random.Next(0,1920);
                    y = random.Next(0, 1080);
                    MouseOperations.SetCursorPosition(x, y);
                    System.Threading.Thread.Sleep(time);
                }
            } while (!Console.ReadKey(true).Key.Equals(ConsoleKey.Escape)); //loops until [ESC] is pressed

            Message.displaySplashScreen();
        }

        public static void setupMode()
        {
            Console.Clear();
            bool validInput = false;
            do
            {
                Message.displaySetup();
                string result = readLineWithCancel(); //custom Console.ReadLine()
                try
                {
                    int temp = Convert.ToInt32(result);
                    if (temp >= 200 && temp <= 5000) //must be from [200, 5000]ms
                    {
                        validInput = true;
                        time = temp;
                    }
                    else { Message.displaySetupError(); }
                }
                catch (FormatException)
                {
                    //Exit if [ESC] or empty string is passed, else display standard error message
                    if (result.Equals(String.Empty)) break;
                    else Message.displaySetupError();
                }
            } while (!validInput);
            Message.displaySplashScreen(); //displays main menu after the setup is complete
        }

        public static string readLineWithCancel()
        { //TODO: backspace support w/ arrows
            string result = string.Empty;
            StringBuilder buffer = new StringBuilder();

            ConsoleKeyInfo input = Console.ReadKey(true);
            while (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.Escape)
            {
                Console.Write(input.KeyChar);
                buffer.Append(input.KeyChar);
                input = Console.ReadKey(true);
            }
            if (input.Key == ConsoleKey.Enter) result = buffer.ToString();
            return result;
        }

    }

}