using System;
using System.ComponentModel.DataAnnotations;
namespace GoToEF
{
    public class Person
    {
        [Key]
        public string Name { get; set;}
        public int Age { get; set; }

    }
}
