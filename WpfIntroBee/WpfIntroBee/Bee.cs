using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfIntroBee
{
    class Bee
    {  
        public double WeightMg { get; private set; }
        public Bee(double weightMg){ // вес пчелы
            WeightMg = weightMg; }
        virtual public double HoneyConsumptionRate()
        { // требуется меда на грамм веса
            return WeightMg * .25;} 
    }
}
