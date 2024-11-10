using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OrderLineRepositoryPostgreSQL :IRepository<OrderLine>
    {
        private PizzaDeliveryNewGenContext db;

        public OrderLineRepositoryPostgreSQL(PizzaDeliveryNewGenContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<OrderLine> GetList()
        {
            return db.OrderLines.ToList();
        }

        public OrderLine GetItem(int id)
        {
            return db.OrderLines.Find(id);
        }

        public void Create(OrderLine orderline)
        {
            db.OrderLines.Add(orderline);
            db.SaveChanges();
        }

        public void Update(OrderLine orderline)
        {
            db.Entry(orderline).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            OrderLine orderline = db.OrderLines.Find(id);
            if (orderline != null)
                db.OrderLines.Remove(orderline);
            db.SaveChanges();
        }
    }
}
