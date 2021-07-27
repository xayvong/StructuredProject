using CKK.Logic.Interfaces;
using CKK.Logic.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository.InMemory
{
    public class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly List<TEntity> Context;

        public InMemoryRepository(List<TEntity> context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            Context.Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return Context.Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context;
        }

        public void Remove(TEntity entity)
        {
            Context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach(var entity in entities)
            {
                Context.Remove(entity);
            }
        }
    }
}
