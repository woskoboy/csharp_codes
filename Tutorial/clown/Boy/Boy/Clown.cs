using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boy
{
    interface IClown
    {
        string FunnyThingIHave { get;}
        void Honk();
    }

    interface IScaryClown : IClown
    {
        string ScaryThingIHave { get; }
        void ScareLittleChildren();
    }

    class FunnyFunny : IClown
    {
        private string thingIHave;
        public string FunnyThingIHave {
            get { return string.Concat("Привет у меня есть", thingIHave); }
        }
        public FunnyFunny(string thing){
            this.thingIHave = thing;
        }
        public void Honk(){
            Console.Write(FunnyThingIHave);
        }
    }

    class ScaryScary : FunnyFunny, IScaryClown
    {
        private int numberOfScaryThings;
        public string ScaryThingIHave {
            get { return string.Concat("У меня ", numberOfScaryThings, " пауков! "); }
        }
        public ScaryScary(string thing, int numberOfScaryThings) : base(thing){
            this.numberOfScaryThings = numberOfScaryThings;
        }

        public void ScareLittleChildren() {
            Console.WriteLine("Ага, попался! "); }
    }
}
