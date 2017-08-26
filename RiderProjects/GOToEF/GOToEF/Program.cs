using System;

namespace GoToEF
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            using (var context = new SimpleContext()){
                var person = new Person() { Name = "Maggy", Age = 28 };
				
                context.People.Add(person);
                context.SaveChanges();               
            }
			
            Console.WriteLine("Hello World!");
        }
    }
}