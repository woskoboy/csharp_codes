namespace WpfIntroBee
{
    internal class Worker
    {
        private string[] jobsICanDo; // что умею

        private int shiftsToWork; // план
        private int shiftsWorked; // выполнено
       public int ShiftsLeft{ // оставшиеся смены
            get { return shiftsToWork - shiftsWorked; }}

        private string curentJob = ""; // работой не занят
        public string CurrentJob {
            get { return this.curentJob; } }

        public Worker(string[] jobs)
        { this.jobsICanDo = jobs;}

        public bool DoThisJob(string job, int shifts)
        { // назначение задания рабочим
            if (!string.IsNullOrEmpty(this.curentJob))
                // отстань, я занят другой работой
                return false;

            for (int i = 0; i < jobsICanDo.Length; i++){
                if (job == jobsICanDo[i])
                {
                    this.curentJob = job; // работу принял
                    this.shiftsToWork = shifts; // на столько смен
                    this.shiftsWorked = 0; // отработал пока 0
                    return true; // я берусь за эту работу
                }
            }
            // запрашиваемые рабты не выполняю
            return false;
        }
        public bool DidYouFinish()
        { /* Когда вызывается метод, рабочий отрабатывает смену. Метод проверяет,
        сколько смен осталось отработать. Если работа завершена, метод возвращает true
        и присваивает вместо текущого задания пустую строку, 
        давая возможность получить следующее задание. В противном случае возвращается false.*/
            if (string.IsNullOrEmpty(this.curentJob)) return false; // а я и не занят
            shiftsWorked++; // отработал ещё одну смену
            if (shiftsWorked > shiftsToWork) // это моя последняя смена
            {
                this.curentJob = ""; // готов к новому заданию
                this.shiftsWorked = 0;
                this.shiftsToWork = 0;
                return true;
            } else
            {
                return false; // не закончил я
            }
        }
    }
}