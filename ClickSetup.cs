using System;
using System.Text;
using System.Threading;

namespace afk_bot
{
    public class ClickSetup
    {
        public static Random random = new Random();
        public static ConsoleKey input;
        public static int x, y, time = 200; //default 200ms
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
            } while (!Console.ReadKey(true).Key.Equals(ConsoleKey.Escape)); //while ESC is not pressed

            Message.displaySplashScreen();
        }

        public static void setupMode()
        {
            Console.Clear();
            bool valid = false;

            do
            {
                Message.displaySetup();
                string result = readLineWithCancel();
                try
                {
                    int temp = Convert.ToInt32(result);

                    if (temp >= 200 && temp <= 5000)
                    {
                        valid = true;
                        time = temp;
                    }
                    else { Message.displaySetupError(); }
                }
                catch (FormatException)
                {
                    //Exit on [ESC] or empty string
                    if (result.Equals(String.Empty)){
                        break;
                    }

                    Message.displaySetupError();
                }
            } while (!valid);

            Message.displaySplashScreen();
        }

        public static string readLineWithCancel(){ //TODO: backspace support w/ arrows
            
            string result = string.Empty;
            StringBuilder buffer = new StringBuilder();

            ConsoleKeyInfo input = Console.ReadKey(true);

            while(input.Key != ConsoleKey.Enter && input.Key != ConsoleKey.Escape) {
                Console.Write(input.KeyChar);
                buffer.Append(input.KeyChar);
                input = Console.ReadKey(true);
            }

            if(input.Key == ConsoleKey.Enter){
                result = buffer.ToString();
            }

            return result;
        }

    }

}