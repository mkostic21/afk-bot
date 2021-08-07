using System;
using System.Text;
using System.Linq;

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
                    x = random.Next(0, 1920);
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
                Message.displaySetupMessage();
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
                    if (result.Equals(String.Empty)) { break; }
                    else Message.displaySetupError();
                }
            } while (!validInput);
            Message.displaySplashScreen(); //displays main menu after the setup is complete
        }

        public static string readLineWithCancel()
        {
            string result = string.Empty;
            StringBuilder buffer = new StringBuilder();
            ConsoleKeyInfo input;
            int systemMessageLength = Message.setupMessage.Length;

            do
            {
                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Backspace && Console.CursorLeft > systemMessageLength)
                {
                    int consoleInputCounter = --Console.CursorLeft - systemMessageLength;
                    buffer.Remove(consoleInputCounter, 1); //remove 1 character from buffer
                    Console.CursorLeft = systemMessageLength; //reset cursor to 0 pos
                    Console.Write(buffer.ToString()); //re-write modified buffer
                    Console.Write(new String(' ', 1)); //replace deleted character with whitespace (for display)
                    --Console.CursorLeft; //move cursor back to end of buffer
                }
                else if (input.Key == ConsoleKey.LeftArrow && Console.CursorLeft > systemMessageLength)
                {
                    Console.CursorLeft--;
                }
                else if (input.Key == ConsoleKey.RightArrow && Console.CursorLeft < systemMessageLength + buffer.Length)
                {
                    Console.CursorLeft++;
                }
                else if (Char.IsLetterOrDigit(input.KeyChar) || Char.IsWhiteSpace(input.KeyChar)) //disregards anything that isn't a digit, letter or whitespace
                {
                    Console.Write(input.KeyChar);
                    buffer.Append(input.KeyChar);
                }
            }
            while (input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.Escape);
            if (input.Key == ConsoleKey.Enter) { result = buffer.ToString(); }
            return result;
        }

    }

}