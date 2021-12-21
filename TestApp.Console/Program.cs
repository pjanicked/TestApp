namespace TestApp.Console
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Divisibility divisibility = new();

            var quitFlag = false;

            while(!quitFlag)
            {
                Console.WriteLine("Press Any Key to continue OR q to Quit");
                var userOption = Console.ReadLine();
                if(userOption == "q")
                {
                    quitFlag = true;
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                    var userInput = Console.ReadLine();

                    Console.WriteLine(divisibility.CheckDivisibility(userInput));
                }
            }
                      
        }
    }
}
