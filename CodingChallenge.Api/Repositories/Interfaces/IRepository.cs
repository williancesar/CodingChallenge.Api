using System;
using System.Collections.Generic;

namespace CodingChallenge.Api.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(Guid id);

        IEnumerable<TEntity> Get();

        TEntity GetById(Guid id);

        void Insert(TEntity entity);

        void Update(TEntity entityToUpdate);
    }
}
