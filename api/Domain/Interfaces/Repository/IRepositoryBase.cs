using System.Collections.Generic;

namespace Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entityObj);

        void Update(TEntity entityObj);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(string id);

        void Remove(TEntity entityObj);
    }
}