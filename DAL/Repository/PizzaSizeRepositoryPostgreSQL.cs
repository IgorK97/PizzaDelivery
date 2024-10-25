using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PizzaSizeRepositoryPostgreSQL :IRepository<PizzaSize>
    {
        private PizzaDeliveryNewGenContext db;

        public PizzaSizeRepositoryPostgreSQL(PizzaDeliveryNewGenContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<PizzaSize> GetList()
        {
            return db.PizzaSizes.ToList();
        }

        public PizzaSize GetItem(int id)
        {
            return db.PizzaSizes.Find(id);
        }

        public void Create(PizzaSize pizzasize)
        {
            db.PizzaSizes.Add(pizzasize);
        }

        public void Update(PizzaSize pizzasize)
        {
            db.Entry(pizzasize).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            PizzaSize pizzasize = db.PizzaSizes.Find(id);
            if (pizzasize != null)
                db.PizzaSizes.Remove(pizzasize);
        }
    }
}
