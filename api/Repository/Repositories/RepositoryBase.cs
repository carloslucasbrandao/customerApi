using Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected ContextCustomerDb customerDB = new ContextCustomerDb();

        public void Add(TEntity entityObj)
        {
            customerDB.Set<TEntity>().Add(entityObj);
            customerDB.SaveChanges();
        }

        public void Update(TEntity entityObj)
        {
            customerDB.Entry(entityObj).State = EntityState.Modified;
            customerDB.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return customerDB.Set<TEntity>().ToList();
        }

        public TEntity GetById(string id)
        {
            return customerDB.Set<TEntity>().Find(id);
        }                

        public void Remove(TEntity entityObj)
        {
            customerDB.Set<TEntity>().Remove(entityObj);
            customerDB.SaveChanges();
        }
    }
}
