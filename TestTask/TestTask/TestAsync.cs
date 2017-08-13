using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class TestAsync
    {
        static void Main()
        {
            DisplayResultAsync();
            Console.WriteLine("Wait...");
            Console.ReadLine();
        }

        static async void DisplayResultAsync()
        {
            int n = 5;
            int result = await Factorial(n);
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Факториал {0} равен {1}", n, result);
        }

        static Task<int> Factorial(int n)
        {
            int result = 1;
            return Task.Run(() =>
            {
                for (int i = 1; i <= n; i++) { result *= i; }
                return result;
            });
        }
    }
}
