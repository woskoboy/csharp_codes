using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Config = System.Configuration;

namespace TestTask
{
    class Power
    {
        private LinqDbDataContext dataContext;
        private string[] codes;

        public Power (string[] codes_)
        {
            dataContext = new LinqDbDataContext(
                Config.ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
            codes = codes_;
        }

        public async void AskEveryoneAsync()
        {
            Task t = new Task(AskEveryone); t.Start();
            await t;
            Console.WriteLine("Done");
            await Task.Delay(1000); Console.Clear();
            AskEveryoneAsync();
        }
  
        public void AskEveryone()
        {
            foreach (var code in codes){ GetDevicePower(code); }
        }

        private void GetDevicePower(string code)
        { 
            try
            {
                List<ReqProcResult> rows = dataContext.ReqProc(code).ToList();
                Console.Write("{0}\n" ,rows[0].DeviceCode);
                foreach (ReqProcResult row in rows)
                {
                    Console.WriteLine("\t{0} [{1}]", ((DateTime)row.MeasureTime).ToString("HH:mm"), row.P);
                }
                Console.Write(new String('-', 20) + '\n');
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}\n{1}", ex.Message, new String('-', 50));
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
