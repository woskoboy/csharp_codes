using System;

namespace TestTask
{
    class Program
    {
       static void Main(string[] args)
        {
            string[] codes = { "E3", "E2" };
            new Power(codes).AskEveryoneAsync();
            Console.WriteLine("Main");
            Console.ReadLine();
        }
    }
}
