using CodingChallenge.Api.Repositories.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CodingChallenge.Api.Data;

namespace CodingChallenge.Api.Repositories.Implementations
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ChallengeDbContext context;
        
        internal DbSet<TEntity> entitySet;

        public BaseRepository(ChallengeDbContext context)
        {
            this.context = context;

            this.entitySet = context.Set<TEntity>();
        }

        public void Delete(Guid id)
        {
            TEntity entityToDelete = this.entitySet.Find(id);

            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.entitySet.Attach(entityToDelete);
            }

            this.entitySet.Remove(entityToDelete);
            this.context.SaveChanges();
        }

        public IEnumerable<TEntity> Get()
        {
            return this.entitySet;
        }

        public TEntity GetById(Guid id)
        {
            return this.entitySet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            this.entitySet.Add(entity);

            this.context.SaveChanges();
        }

        public void Update(TEntity entityToUpdate)
        {
            this.entitySet.Attach(entityToUpdate);

            this.context.Entry(entityToUpdate).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
