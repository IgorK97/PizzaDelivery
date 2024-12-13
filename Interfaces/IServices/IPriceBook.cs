using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IPriceBook
    {
        void KnowPriceAndWeight();
        //void KnowBaseWeight();

        decimal GetPrice(int size);
        decimal GetWeight(int size);
    }
}
