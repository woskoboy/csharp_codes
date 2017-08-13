using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;


namespace TestTask
{
    [Table(Name = "[power_accounting]")]
    public class PowerRow
        {
        [Column(Name = "[MeasureTime]")]
        public DateTime Time { get; set; }

        [Column(Name = "[DeviceCode]")]
        public string Code { get; set; }

        [Column]
        public float P { get; set; }
    }
}
