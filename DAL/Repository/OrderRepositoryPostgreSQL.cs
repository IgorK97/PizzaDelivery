using DomainModel;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
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
            return db.Orders.Include(o => o.OrderLines).ToList();

            //return db.Orders.ToList();
        }

        public Order GetItem(int id)
        {
            return db.Orders.Include(o => o.OrderLines)
                .FirstOrDefault(u => u.Id == id);
            //return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void Update(Order order)
        {
            db.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
            db.SaveChanges();
        }
    }
}
