using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Repository;
using DomainModel;
using DTO;
using DAL;

namespace DAL.Repository
{
    public class PizzaRepositoryPostgreSQL :IRepository<Pizza>
    {
        private PizzaDeliveryNewGenContext db;

        public PizzaRepositoryPostgreSQL(PizzaDeliveryNewGenContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Pizza> GetList()
        {
            return db.Pizzas.ToList();
        }

        public Pizza GetItem(int id)
        {
            return db.Pizzas.Find(id);
        }

        public void Create(Pizza pizza)
        {
            db.Pizzas.Add(pizza);
            db.SaveChanges();
        }

        public void Update(Pizza pizza)
        {
            db.Entry(pizza).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza != null)
                db.Pizzas.Remove(pizza);
            db.SaveChanges();
        }
    }
}
