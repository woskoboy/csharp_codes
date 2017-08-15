using System;
using System.Collections.Generic;
using System.Linq;
using Config = System.Configuration;

namespace TestTask
{
    class Power
    {
        public static void AskEveryone(string[] codes)
        {
            foreach (var code in codes) { GetDevicePower(code); }
        }

        private static void GetDevicePower(string code)
        {
            string conn_str = Config.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            LinqDbDataContext dataContext = new LinqDbDataContext(conn_str);
            try
            {
                List<ReqProcResult> rows = dataContext.ReqProc(code).ToList();
                foreach (ReqProcResult row in rows)
                {
                    Console.WriteLine("{0} {1} {2}", ((DateTime)row.MeasureTime).ToString("HH:mm"),
                        row.DeviceCode, row.P);
                }
                Console.Write(new String('-', 10) + '\n');
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}\n{2}\n{1}",
                    ex.Message, ex.Data, new String('-', 50));
            }
        }
    }
}
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


//namespace TestTask
//{
//    [Table(Name = "[power_accounting]")]
//    public class PowerRow
//        {
//        [Column(Name = "[MeasureTime]")]
//        public DateTime Time { get; set; }

//        [Column(Name = "[DeviceCode]")]
//        public string Code { get; set; }

//        [Column]
//        public float P { get; set; }
//    }
//}
