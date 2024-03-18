using System.Diagnostics;

namespace Reaction_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isInput = false;

            Console.WriteLine("The purpose of this game is to test your reaction speed!" +
                "\nTo participate in this game make sure to press the SPACEBAR when console returns 'Go!'." +
                "\nYou will then be told your reaction time immediately." +
                "\nThe game will continue to go for upto 10 times where an average reaction speed is calculated.");

            while (!isInput)
            {
                Console.Write("Would you like to start? (y or n): ");
                string input = Console.ReadLine();
                if (input.Equals("Y") || input.Equals("y"))
                {
                    Game();
                } 
                else if (input.Equals("N") || input.Equals("n"))
                { 
                    System.Environment.Exit(0);
                }
                else
                {
                    isInput = false;
                }
            }

        }

        public static void Game()
        {
            Random rnd = new Random();
            Stopwatch stopwatch = new Stopwatch();
            ConsoleKeyInfo keyInfo;

            string reactionTime = "";
            double avgReactionTime = 0.00;

            Console.WriteLine("3");
            Delay(2000);
            Console.WriteLine("2");
            Delay(2000);
            Console.WriteLine("1");
            Delay(2000);
            Console.WriteLine("Commence!");

            bool isConfirm = false;

            while (!isConfirm)
            {
                for (int i = 0; i < 10; i++)
                {
                    Delay(rnd.Next(1000, 10000));
                    Console.WriteLine("Go!");
                    stopwatch.Start();

                    if(Console.ReadKey(true).Key == ConsoleKey.Spacebar) 
                    {
                        stopwatch.Stop();
                        TimeSpan ts = stopwatch.Elapsed;
                        reactionTime = String.Format("{0:00}.{1:00}", ts.Seconds.ToString(), ts.Milliseconds.ToString());
                        avgReactionTime += Convert.ToDouble(reactionTime);
                        Console.WriteLine($"Reaction Time: {reactionTime}.");
                        reactionTime = string.Empty;
                    }
                }
                isConfirm = true;
            }
            Console.WriteLine($"Your average reaction time is: {avgReactionTime / 10}.");
        }

        public static void Delay(int time)
        {
            Thread.Sleep(time);
        }
    }
}
