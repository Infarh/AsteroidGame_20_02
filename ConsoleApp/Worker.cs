using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public abstract class  Worker
    {
        public string Name;
        public abstract double CalcPayment();
    }
}
