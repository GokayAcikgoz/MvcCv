using McvCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace McvCv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities db = new DbCvEntities();

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return db.Set<T>().FirstOrDefault(filter);
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            db.SaveChanges();
        }

        public void Delete(T id)
        {
            db.Set<T>().Remove(id);
            db.SaveChanges();
        }

        
    }
}