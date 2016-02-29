using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab_4
{
    class Seller
    {
        Thread thread;
        public Seller()
        {
            thread = new Thread(new ThreadStart(main));
            thread.Start();
        }
        private Queue<Buyer> BuyerQueue = new  Queue<Buyer>();

        public void WakeUp()
        {
            thread.Resume();
        }

        public void Sleep()
        {
            thread.Suspend();
        }

        public int Enqueue(Buyer buyer_)
        {
            if (BuyerQueue.Count == 0)
            {
                WakeUp();
            }
            else
            {
                //WakeUpBuyer();
                buyer_.WakeUp();
            }
            BuyerQueue.Enqueue(buyer_);
            return (BuyerQueue.Count - 1);
        }

        public void Leavequeue()
        {
            BuyerQueue.Dequeue();
        }

        private void main()
        {
            while (true)
            {
                lock (thread)
                {
                    if (BuyerQueue.Count == 0)
                    {
                        Sleep();
                    }
                    else
                    {
                        while (BuyerQueue.Count != 0)
                        {
                            Buyer buyer_c = BuyerQueue.Dequeue();
                            buyer_c.WakeUp();
                            Console.WriteLine("Покупатель " + buyer_c.GetIdBuyer() + " ушел из магазина");
                            Globals.allBuyers += 1;
                        }
                        Console.WriteLine("Всего ушло " + Globals.allBuyers + " покупателей");
                    }     
                }         
            }
        }
    }
}
