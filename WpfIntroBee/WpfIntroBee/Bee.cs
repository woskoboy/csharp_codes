using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfIntroBee
{
    class Bee
    {   // требуется меда на грамм веса
        public const double HoneyUnitsConsumedPerMg = .25;
        public double WeightMg { get; private set; }
        public Bee(double weightMg){ // вес пчелы
            WeightMg = weightMg; }
        virtual public double HoneyConsumptionRate()
        { // потребление меда за смену с учетом веса
            return WeightMg * HoneyUnitsConsumedPerMg;}
    }
}
