using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CourierRepositoryPostgreSQL :IRepository<Courier>
    {
        private PizzaDeliveryNewGenContext db;

        public CourierRepositoryPostgreSQL(PizzaDeliveryNewGenContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Courier> GetList()
        {
            return db.Couriers.ToList();
        }

        public Courier GetItem(int id)
        {
            return db.Couriers.Find(id);
        }

        public void Create(Courier courier)
        {
            db.Couriers.Add(courier);
        }

        public void Update(Courier courier)
        {
            db.Entry(courier).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Courier courier = db.Couriers.Find(id);
            if (courier != null)
                db.Couriers.Remove(courier);
        }
    }
}
