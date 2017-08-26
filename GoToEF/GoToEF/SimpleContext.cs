using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace GoToEF
{
    public class SimpleContext : DbContext
    {
        public SimpleContext(): base("name=SimpleContext")
        {}

        public DbSet<Person> People{
            get; set;}
    }
}
