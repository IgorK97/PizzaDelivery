using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ManagerRepositoryPostgreSQL :IRepository<Manager>
    {
        private PizzaDeliveryNewGenContext db;

        public ManagerRepositoryPostgreSQL(PizzaDeliveryNewGenContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Manager> GetList()
        {
            return db.Managers.ToList();
        }

        public Manager GetItem(int id)
        {
            return db.Managers.Find(id);
        }

        public void Create(Manager manager)
        {
            db.Managers.Add(manager);
        }

        public void Update(Manager manager)
        {
            db.Entry(manager).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Manager manager = db.Managers.Find(id);
            if (manager != null)
                db.Managers.Remove(manager);
        }
    }
}
