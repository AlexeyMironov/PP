using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Supermarket superMarket = new Supermarket();
            for (int i = 0; i < 25; i++)
            {
                lock (Thread.CurrentThread)
                {
                    Buyer buyer = new Buyer(superMarket);
                    Thread.Sleep(Globals.randomGenerator.Next(100, 700));
                }
            }
        }
    }
}
