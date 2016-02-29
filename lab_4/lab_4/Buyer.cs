using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab_4
{
    public static class Globals
    {
        public static int totalBuyers = 0;
        public static Random randomGenerator = new Random();
        public static int allBuyers = 0;
    }

    class Buyer
    {
        Thread thread;
        public Buyer(Supermarket superMarket_)
        {
            superMarket = superMarket_;
            thread = new Thread(new ThreadStart(main));
            thread.Start();
        }

        private int IdBuyer = ++ Globals.totalBuyers;
        private Supermarket superMarket;
    
        public int GetIdBuyer()
        {
            return IdBuyer;
        }

        public void WakeUp()
        {
            try
            {
                thread.Resume();
            }
            catch
            {
            } 
        }

        void main()
        {
            lock (thread)
            {
                Console.WriteLine("Покупатель " + IdBuyer + " пришел в магазин");
                Thread.Sleep(Globals.randomGenerator.Next(100, 700));
                Console.WriteLine("Покупатель " + IdBuyer + " выбрал товары");
                int numSeller = Globals.randomGenerator.Next(1, 3);
                Seller seller = superMarket.ReturnSeller(numSeller);
                Console.WriteLine("Покупатель " + IdBuyer + " встает в кассу " + numSeller);
                if (seller.Enqueue(this) != 0)
                {
                    thread.Suspend();
                }
            }
        }
    }
}
