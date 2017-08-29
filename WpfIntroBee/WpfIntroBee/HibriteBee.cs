using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfIntroBee
{
    interface IStingPatrol : IWorker{
        int AlertLevel { get; }
        int StingerLength { get; set; }
        bool LookForEnemies();
        int SharpenStinger(int length);
    }

    interface INectarCollector : IWorker{
        void FindFlowers();
        void GatherNectar();
        void ReturnToHive();
    }

    interface IWorker{
        string Job { get; }
        int ShiftsLeft { get; }
        bool DoThisJob(string job, int shifts);
        void WorkOneShift();
    }

    class Robot { void ConsumeGus() { } }

    class RoboBee : Robot, IWorker
    {
        public string Job{ get; private set; }
        public int ShiftsLeft { get; }
        public bool DoThisJob(string job, int shifts){
            return false;
        }

        public void WorkOneShift()
        {
            throw new NotImplementedException();
        }
    }


}
