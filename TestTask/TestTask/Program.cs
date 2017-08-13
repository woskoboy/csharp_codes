using System;
using System.Linq;
/*using System.Data.SqlClient;*/
using System.Data.Linq;

namespace TestTask
{
    class Program
    {
    static void Main(string[] args)
        {
            DBWork();
        }

        static void DBWork()
        {
            string connectionString = @"
                Integrated Security=True;
                Data Source=WOBOY-DEV_HOME\SQLEXPRESS;
                Initial Catalog=Power;
                User id=woboy-dev_home\woboy;
                Password=tros;";
            DataContext db = new DataContext(connectionString);
            /*SqlConnection conn = new SqlConnection();*/

            var query = (from u in db.GetTable<PowerRow>()
                         select new {
                             Date = u.Time.ToShortTimeString(),
                             Code = u.Code.ToString(),
                             P = u.P.ToString()
                         }).ToList();
            // var query = db.GetTable<User>().Where(u => u.Age > 25).OrderBy(u => u.FirstName);
            foreach (var row in query)
            {
                Console.WriteLine("{0} {2} {1}", row.Date, row.P, row.Code);
            }
            Console.ReadLine();

        }
    }
}
