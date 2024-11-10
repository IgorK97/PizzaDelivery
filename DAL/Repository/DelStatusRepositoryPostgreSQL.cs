using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DelStatusRepositoryPostgreSQL :IRepository<DelStatus>
    {
        private PizzaDeliveryNewGenContext db;

        public DelStatusRepositoryPostgreSQL(PizzaDeliveryNewGenContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<DelStatus> GetList()
        {
            return db.DelStatuses.ToList();
        }

        public DelStatus GetItem(int id)
        {
            return db.DelStatuses.Find(id);
        }

        public void Create(DelStatus ds)
        {
            db.DelStatuses.Add(ds);
            db.SaveChanges();
        }

        public void Update(DelStatus ds)
        {
            db.Entry(ds).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            DelStatus ds = db.DelStatuses.Find(id);
            if (ds != null)
                db.DelStatuses.Remove(ds);
            db.SaveChanges();
        }
    }
}
