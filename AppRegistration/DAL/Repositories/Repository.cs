using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Repositories.Contracts;
using EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        public Repository(IDataContext dataContext)
        {
            EntitySet = dataContext.Set<T>();
        }

        private DbSet<T> EntitySet { get; }
        public IQueryable<T> GetQuery() => EntitySet;

        public async ValueTask<T> GetAsync(Guid id) => await EntitySet.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            EntitySet.Attach(entity);
            await EntitySet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            EntitySet.Attach(entity);
            EntitySet.Update(entity);
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            EntitySet.Attach(entity);
            EntitySet.Remove(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await GetAsync(id);
            Remove(entity);
        }
    }
}
