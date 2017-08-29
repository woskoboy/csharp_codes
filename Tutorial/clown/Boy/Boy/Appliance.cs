using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boy
{
    interface ICookFood
    {
        void HeatUp();
        void Reheat();
    }
    class Appliance {
        virtual public int PowerWeight { get; }
        public void ConsumePower() {
            Console.WriteLine(this.GetType());
        }
    }
    class CoffeMaker : Appliance {
        public override int PowerWeight{
            get { return 2;}
        }
        public void FillWithWater() { }
        public void MakeCoffee() { Console.WriteLine("Coffee..."); }
    }
    class Oven : Appliance, ICookFood
    {
        public override int PowerWeight{
            get { return 3; }
        }
        public void Preheat() { }
        public void HeatUp() { Console.WriteLine("Oven HeatUp..."); }
        public void Reheat() { }
    }

    class Microwave : Appliance, ICookFood
    {
        public override int PowerWeight{
            get { return 4; }
        }
        public void Preheat() { }
        public void HeatUp() { Console.WriteLine("Wave HeatUp..."); }
        public void Reheat() { }
    }



}
