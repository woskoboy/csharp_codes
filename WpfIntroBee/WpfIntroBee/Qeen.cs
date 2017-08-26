namespace WpfIntroBee
{
    internal class Qeen : Bee
    {
        private Worker[] workers;
        private int shiftNumber = 0;

        public Qeen(Worker[] workers, double weightMg) : base(weightMg)
        {
            this.workers = workers;
        }

        public bool AssignWork(string job, int shiftCount)
        { /* Queen.AssignWork() циклически просматривает массив worker
            и пытается дать работу каждому объекту worker при помощи метода DoThisJob()*/
            foreach (Worker worker in workers)
            {   // ищем того, кто умеет 
                if (worker.DoThisJob(job, shiftCount)) return true;
            }  
            return false; // никто не умеет это делать
        }

        public string WorkTheNextShift()
        { /* метод WorkTheNextShift(), заставляющий рабочего отработать следующую смену
            и затем проверяющий его состояние, чтобы сформировать отчет.*/

            this.shiftNumber++; // добавляем смену
            string report = string.Format(" Отчет для смены # {0} \r\n", this.shiftNumber);

            double honeyConsumed = HoneyConsumptionRate(); // съела сама матка

            for (int i = 0; i < workers.Length; i++)
            { // опрашиваем рабочих
                honeyConsumed += workers[i].HoneyConsumptionRate(); // накушали рабочие
                if (workers[i].DidYouFinish())
                    report += "Рабочий # " + (i + 1) + " закончил работу\r\n";
                if (string.IsNullOrEmpty(workers[i].CurrentJob))
                    report += "Рабочий # " + (i + 1) + " не работает \r\n";
                else 
                    if (workers[i].ShiftsLeft > 0)
                        report += "Рабочий # " + (i + 1) + " выполняет работу "+ workers[i].CurrentJob +
                            " ещё "+ workers[i].ShiftsLeft+" смен \r\n";
                    else
                        report += "Рабочий # " + (i + 1) + " закончит "
                                    + workers[i].CurrentJob + " после этой смены\r\n";
            }
            report += "Total honey consumed for the shift: " + honeyConsumed + " units\r\n";
            return report;
        }
    }
}