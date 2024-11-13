using DomainModel;
using DTO;
using Interfaces.Repository;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepositoryPostgreSQL : IRepository<User>/*, IAccountService*/
    {
        private PizzaDeliveryNewGenContext db;

        public UserRepositoryPostgreSQL(PizzaDeliveryNewGenContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<User> GetList()
        {
            return db.Users.Include(u => u.Client).Include(u => u.Courier).Include(u => u.Manager).ToList();
            //return db.Users.Include(u => u.Client).ToList();
        }

        public User GetItem(int id)
        {
            //db.Users.Include(u => u.Client).Find(id);
            return db.Users.Include(u => u.Client).Include(u => u.Courier).Include(u => u.Manager)
                .FirstOrDefault(u => u.Id == id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Update(User user)
        {
            db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
            db.SaveChanges();
        }
        
    }
}
