using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PriceBook : IPriceBook
    {
        private IDbRepos dbr;
        //private PizzaDeliveryContext db;
        public PriceBook(IDbRepos repos)
        {
            dbr = repos;
            //db = new PizzaDeliveryContext();
        }
        private decimal smallPrice;
        private decimal bigPrice;
        private decimal mediumPrice;

        private decimal smallWeight;
        private decimal bigWeight;
        private decimal mediumWeight;
        public decimal GetPrice(int id)
        {
            if(id==1)
                return smallPrice;
            if(id==2)
                return mediumPrice;
            return bigPrice;
        }
        public decimal GetWeight(int id)
        {
            if (id == 1)
                return smallWeight;
            if (id == 2)
                return mediumWeight;
            return bigWeight;
        }
        public void KnowPriceAndWeight()
        {
            var prices = dbr.PizzaSizes.GetList();

            smallPrice = prices.ToList().Where(i => i.Id == 1).Sum(i => i.Price);
            mediumPrice = prices.ToList().Where(i => i.Id == 2).Sum(i => i.Price);
            bigPrice = prices.ToList().Where(i => i.Id == 3).Sum(i => i.Price);

            smallWeight = prices.ToList().Where(i => i.Id == 1).Sum(i => i.Weight);
            mediumWeight = prices.ToList().Where(i => i.Id == 2).Sum(i => i.Weight);
            bigWeight = prices.ToList().Where(i => i.Id == 3).Sum(i => i.Weight);
        }

        //public void KnowBaseWeight()
        //{
        //    var weights = dbr.PizzaSizes.GetList();

        //    smallWeight = weights.ToList().Where(i => i.Id == 1).Sum(i => i.Weight);
        //    mediumWeight = weights.ToList().Where(i => i.Id == 2).Sum(i => i.Weight);
        //    bigWeight = weights.ToList().Where(i => i.Id == 3).Sum(i => i.Weight);
        //}
    }
}
