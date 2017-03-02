using System.Threading.Tasks;

namespace Tokiota.BookStore.Repositories.Services.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Context;
    using Entities.Core;
    using Microsoft.EntityFrameworkCore;

    public class RepositoryCore<TEntity, TId> : IRepositoryCore<TEntity, TId> where TEntity : EntityCore<TId>
    {
        #region Atributte
        protected readonly LibraryContext Context;
        protected readonly DbSet<TEntity> DbSet;
        #endregion

        #region Contructor
        public RepositoryCore(LibraryContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }
        #endregion

        #region Gets
        public Task<List<TEntity>> Get()
        {
            return this.DbSet.ToListAsync();
        }
        public Task<TEntity> Get(TId id)
        {
            return this.DbSet.FirstOrDefaultAsync(o => o.Id.Equals(id));
        }
        public Task<List<TEntity>> Get(IEnumerable<TId> ids)
        {
            return this.DbSet.Where(o => ids.Contains(o.Id)).ToListAsync();
        }
        #endregion

        #region Commands
        public Task Create(TEntity objectToCreate)
        {
            return this.DbSet.AddAsync(objectToCreate);
        }
        public Task Create(IEnumerable<TEntity> objectsToCreate)
        {
            return this.DbSet.AddRangeAsync(objectsToCreate);
        }

        public void Update(TEntity objectToUpdate)
        {
            this.DbSet.Update(objectToUpdate);
        }
        public void Update(IEnumerable<TEntity> objectsToUpdate)
        {
            this.DbSet.UpdateRange(objectsToUpdate);
        }

        public void Remove(TEntity objectToRemove)
        {
            this.DbSet.Remove(objectToRemove);
        }
        public void Remove(IEnumerable<TEntity> objectsToRemove)
        {
            this.DbSet.RemoveRange(objectsToRemove);
        }

        public async Task Remove(TId id)
        {
            var objectToRemove = await this.Get(id);
            this.DbSet.Remove(objectToRemove);
        }

        public async Task Remove(IEnumerable<TId> ids)
        {
            var objectsToRemove = await this.Get(ids);
            foreach (var objectToRemove in objectsToRemove)
            {
                this.Remove(objectToRemove);
            }
        }

        #endregion

        #region Others

        public Task<int> SaveChanges()
        {
            return this.Context.SaveChangesAsync();
        }

        #endregion
    }
}
