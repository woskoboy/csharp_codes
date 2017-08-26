using System;

namespace GoToEF
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            using (var context = new SimpleContext()){
				var person = new Person() { Name = "John", Age = 28 };
				
                context.People.Add(person);
				context.SaveChanges();               
            }
			
            Console.WriteLine("Hello World!");
		}
    }
}
