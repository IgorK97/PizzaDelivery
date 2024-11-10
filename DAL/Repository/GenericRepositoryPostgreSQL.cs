using DomainModel;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GenericRepositoryPostgreSQL<T> : IRepository<T> where T : DomainObject
    {
        private PizzaDeliveryNewGenContext db;

        public GenericRepositoryPostgreSQL(PizzaDeliveryNewGenContext dbcontext)
        {
            this.db = dbcontext;
        }
        public List<T> GetList()
        {
            return db.Set<T>().ToList();
        }

        public T GetItem(int id)
        {
            return db.Set<T>().FirstOrDefault(i => i.Id==id);
        }

        public void Create(T entity)
        {
            //db.Ingredients.Add(ingredient);
            EntityEntry<T> createdResult = db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            //db.Entry(ingredient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.Set<T>().Update(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            //Ingredient ingredient = db.Ingredients.Find(id);
            //if (ingredient != null)
            //    db.Ingredients.Remove(ingredient);
            T entity = db.Set<T>().FirstOrDefault(i => i.Id == id);
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }
    }
}
