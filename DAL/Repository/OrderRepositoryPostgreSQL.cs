using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OrderRepositoryPostgreSQL :IRepository<Order>
    {
        private PizzaDeliveryNewGenContext db;

        public OrderRepositoryPostgreSQL(PizzaDeliveryNewGenContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Order> GetList()
        {
            return db.Orders.ToList();
        }

        public Order GetItem(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}
