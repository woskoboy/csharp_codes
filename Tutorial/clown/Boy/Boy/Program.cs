using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boy
{
    class Program
    {
        private static void DoJob(IClown man) {
            Console.WriteLine(man.FunnyThingIHave);
            man.Honk();
        }

        private static void MonitorPower(Appliance app) {
            app.ConsumePower();
        }
        static void Main(string[] args)
        {

            CoffeMaker coffee_maker = new CoffeMaker();
            Oven oven = new Oven();

            Appliance[] kitchenWare = new Appliance[3];
            kitchenWare[0] = coffee_maker;
            kitchenWare[1] = oven;
            kitchenWare[2] = new Microwave();

            foreach (Appliance consumer in kitchenWare)
            {
                Console.WriteLine("{0} {1}", consumer, consumer.PowerWeight);
                CoffeMaker cm = consumer as CoffeMaker;
                ICookFood cf = consumer as ICookFood;
                if (cm != null) cm.MakeCoffee(); else cf.HeatUp();

                /*if (consumer is CoffeMaker) {
                    //CoffeMaker cm = (CoffeMaker) consumer;
                    (consumer as CoffeMaker).MakeCoffee();
                }*/  
            }
            /*-----------------------------------------*/

            ScaryScary scaryClown = new ScaryScary(" большие ботинки\n", 14);
            FunnyFunny someFunnyClown = scaryClown;
            IScaryClown someScaryClown = someFunnyClown as ScaryScary;

            someScaryClown.Honk();
            Console.Write(someScaryClown.ScaryThingIHave+"\n");
            someScaryClown.ScareLittleChildren();

            Console.ReadKey();
        }
    }
}
