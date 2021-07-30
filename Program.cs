using System;

namespace afk_bot
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey input;
            do
            {
                //TODO: UI default splashscreen message here:
                switch (input = Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        //1st method here:
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Exiting.");
                        break;
                    default:
                        //help message here?
                        break;
                }
            } while (!input.Equals(ConsoleKey.Escape));
        }
    }
}
