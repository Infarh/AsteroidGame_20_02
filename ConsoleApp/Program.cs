using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = new Worker[5];

            workers[0] = new WorkerHaurly("Вася", 50);
            workers[1] = new WorkerHaurly("Петя", 55);
            workers[2] = new WorkerHaurly("Игорь", 60);

            workers[3] = new WorkerFix("Саша", 60000);
            workers[4] = new WorkerFix("Таня", 50000);


        }
    }
}
