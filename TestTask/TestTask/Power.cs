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
        private string codes;

        public Power (string codes_)
        {
            dataContext = new LinqDbDataContext(
                Config.ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
            codes = codes_;
        }

        public async void AskEveryoneAsync()
        {
            Task t = new Task(AskEveryone); t.Start();
            await t;
            await Task.Delay(1000); Console.Clear();
            AskEveryoneAsync();
        }
  
        public void AskEveryone()
        {
            try {
                GetDevicePower(this.codes);
            }
            catch (Exception ex)  {
                Console.WriteLine("{0}\n{1}", ex.Message, new String('-', 40));
            }           
        }

        private void GetDevicePower(string codes)
        { 
            try
            {
                string s = new String('-', 20);
                List<ParseString_and_FillTempTableResult> rows = dataContext.ParseString_and_FillTempTable(codes).ToList();
                foreach (ParseString_and_FillTempTableResult row in rows)
                {
                    Console.WriteLine(s);
                    Console.WriteLine(" минута {0} - потребление {1} кВт ", row.min_, row.accum_power, s);
                }
                Console.Write(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
