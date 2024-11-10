using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ClientRepositoryPostgreSQL :IRepository<Client>
    {
        private PizzaDeliveryNewGenContext db;

        public ClientRepositoryPostgreSQL(PizzaDeliveryNewGenContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Client> GetList()
        {
            return db.Clients.ToList();
        }

        public Client GetItem(int id)
        {
            return db.Clients.Find(id);
        }

        public void Create(Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
        }

        public void Update(Client client)
        {
            db.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Client client = db.Clients.Find(id);
            if (client != null)
                db.Clients.Remove(client);
            db.SaveChanges();
        }
    }
}
