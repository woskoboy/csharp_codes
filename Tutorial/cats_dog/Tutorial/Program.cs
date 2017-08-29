using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tutorial
{
    class Program
    {
        interface IGoEater{ void Eat(); void Go();}
        interface ISecurity : IGoEater { void Guard(); }

        class Dog : IGoEater, ISecurity
        {
            public void Eat() { Console.WriteLine("Dog eat"); }
            public void Go() { Console.WriteLine("Dog go");  }
            public void Guard() { Console.WriteLine("Dog guard"); }
        }

        class Cat : IGoEater
        {
            public void Go() { Console.WriteLine("Cat go"); }
            public void Eat() { Console.WriteLine("Cat eat"); }
        }
        static void Main(string[] args)
        {
            IGoEater cat = new Cat();
            ISecurity dog_all = new Dog(); // умеет всё т.к. присутствует наследование от IGoEater
            IGoEater dog_goeat = new Dog(); // умеет только есть и ходить
            dog_all.Guard();

            Console.ReadKey();
        }
    }
}
