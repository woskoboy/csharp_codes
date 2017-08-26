using System;

namespace TestTask
{
    class Program
    {
       static void Main(string[] args)
        {
            string codes = "1,3,4,";
            new Power(codes).AskEveryoneAsync();
            Console.ReadLine();
        }
    }
}
