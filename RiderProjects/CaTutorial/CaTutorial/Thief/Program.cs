using System;

namespace CaTutorial.Thief
{
    internal class Program
    {
                static void Main(string[] args) {
                    
                    var owner = new Owner();
                    
                    var safe = new Safe();
                    
                    var jewelThief = new JewelThief();
                    jewelThief.OpenSafe(safe, owner);
                    
                    Console.ReadKey();
        }
    }
}