using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class WorkerFix : Worker
    {
        public double fixRate;

        public WorkerFix(string name, double fixRate)
        {
            this.fixRate = fixRate;
            this.Name = name;
        }

        public override double CalcPayment()
        {

            return fixRate;
        }
    }
}
