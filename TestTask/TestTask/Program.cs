using System;
using System.Linq;
/*using System.Data.SqlClient;*/
using System.Data.Linq;
using System.Collections.Generic;
using Config = System.Configuration;

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
            int deviceCode = 3;
            string conn_str = Config.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            LinqDbDataContext dataContext = new LinqDbDataContext(conn_str);
            List<ReqProcResult> rows = dataContext.ReqProc(deviceCode).ToList();
            foreach (ReqProcResult row in rows)
                Console.WriteLine("{0} {1} {2}", row.MeasureTime, row.DeviceCode, row.P);
            //DataContext db = new DataContext(connectionString);
            ///*SqlConnection conn = new SqlConnection();*/

            //var query = (from u in db.GetTable<PowerRow>()
            //             select new
            //             {
            //                 Date = u.Time.ToShortTimeString(),
            //                 Code = u.Code.ToString(),
            //                 P = u.P.ToString()
            //             }).ToList();
            //// var query = db.GetTable<User>().Where(u => u.Age > 25).OrderBy(u => u.FirstName);
            //foreach (var row in query)
            //{
            //    Console.WriteLine("{0} {2} {1}", row.Date, row.P, row.Code);
            //}
            Console.ReadLine();

        }
    }
}
