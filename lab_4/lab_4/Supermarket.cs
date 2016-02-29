using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    class Supermarket
    {
        Seller FstSeller = new Seller();
        Seller ScndSeller = new Seller();

        public Seller ReturnSeller(int IdSeller)
        {
            if (IdSeller == 1)
            {
                return FstSeller;
            }
            else
            {
                return ScndSeller;
            }
        }
    }
}
