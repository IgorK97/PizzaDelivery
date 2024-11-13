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
        public decimal GetBasePrice(int id)
        {
            var res = dbr.PizzaSizes.GetList().Where(i => i.Id == id).
                Select(i => new
                {
                    price = i.Price
                }).FirstOrDefault();
            return res.price;
        }

        public decimal GetBaseWeight(int id)
        {
            var res = dbr.PizzaSizes.GetList().Where(i => i.Id == id).
                Select(i => new
                {
                    weight = i.Weight
                }).FirstOrDefault();
            return res.weight;
        }
    }
}
