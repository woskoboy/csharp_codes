using System;
namespace CaTutorial.Thief
{
//    драгоценности
    public class Jewels{
        public string Sparkle()
        {// Блеск
            return "Sparkle, sparkle!";
        }
    }
 
    public class Safe
    {//сейф
        private Jewels contents = new Jewels();
        private string combination = "12345";

        public Jewels Open(string combo)
        {// 5 - комбинация верна, получаем драгоценности
            return combo == combination ? contents : null;
        }      
        // 2 - допускаем слесаря к сейфу (вор тоже бывший слесарь)
        public void PickLock(Locksmith lockpicker) {
            // вспоминаем комбинацию
            lockpicker.WriteDownCombination(combination);
        }
    }

    public class Owner { //хозяин
        private Jewels returnedContents;
        public void ReceiveContents(Jewels safeContents) {
            returnedContents = safeContents;
            Console.WriteLine("Thank you for returning my jewels! " + safeContents.Sparkle());
        }
    }
    
    public class Locksmith { //слесарь
        public void OpenSafe(Safe safe, Owner owner)
        {// 1 - слесарь или вор работают с сефом
            safe.PickLock(this);
            // 4 - пробуем открыть сейф
            Jewels safeContents = safe.Open(writtenDownCombination);
            ReturnContents(safeContents, owner);
        }
        private string writtenDownCombination = null;
        public void WriteDownCombination(string combination) // 3 - записали комбинацию
        {writtenDownCombination = combination;}

        public virtual void ReturnContents(Jewels safeContents, Owner owner)
        {owner.ReceiveContents(safeContents);}
    }
    
    class JewelThief : Locksmith{ // вор
        private Jewels stolenJewels = null;
        public override void ReturnContents(Jewels safeContents, Owner owner)
        {
            stolenJewels = safeContents;
            Console.WriteLine("I'm stealing the contents! " + stolenJewels.Sparkle());
        }
    }
}