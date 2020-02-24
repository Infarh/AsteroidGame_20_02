using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class WorkerHaurly : Worker
    {
        private double haurlyRate;

        public WorkerHaurly(string name ,double haurlyRate)
        {
            this.haurlyRate = haurlyRate;
            this.Name = name;
        }

        public override double CalcPayment()
        {
            return 20.8 * 8 * haurlyRate;
        }
    }
}
