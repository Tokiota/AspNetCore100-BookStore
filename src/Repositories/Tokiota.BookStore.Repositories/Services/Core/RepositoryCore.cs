namespace Tokiota.BookStore.Repositories.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Tokiota.BookStore.Context;
    using Tokiota.BookStore.Entities.Core;

    public class RepositoryCore<TEntity, TId> : IRepositoryCore<TEntity, TId> where TEntity : EntityCore<TId>
    {
        #region Atributte
        private readonly LibraryContext context;
        private readonly DbSet<TEntity> dbSet;
        #endregion

        #region Contructor
        public RepositoryCore(LibraryContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }
        #endregion

        #region Gets
        public IEnumerable<TEntity> Get()
        {
            return this.dbSet.ToList();
        }
        public TEntity Get(TId id)
        {
            return this.dbSet.FirstOrDefault(o => o.Id.Equals(id));
        }
        public IEnumerable<TEntity> Get(IEnumerable<TId> ids)
        {
            return this.dbSet.Where(o => ids.Contains(o.Id));
        }
        #endregion

        #region Commands
        public void Create(TEntity objectToCreate)
        {
            this.dbSet.Add(objectToCreate);
        }
        public void Create(IEnumerable<TEntity> objectsToCreate)
        {
            this.dbSet.AddRange(objectsToCreate);
        }
        public void Update(TEntity objectToUpdate)
        {
            this.dbSet.Update(objectToUpdate);
        }
        public void Update(IEnumerable<TEntity> objectsToUpdate)
        {
            this.dbSet.UpdateRange(objectsToUpdate);
        }

        public void Remove(TEntity objectToRemove)
        {
            this.dbSet.Remove(objectToRemove);
        }
        public void Remove(IEnumerable<TEntity> objectsToRemove)
        {
            this.dbSet.RemoveRange(objectsToRemove);
        }

        public void Remove(TId id)
        {
            var objectToRemove = this.Get(id);
            this.Remove(objectToRemove);
        }
        public void Remove(IEnumerable<TId> ids)
        {
            var objectsToRemove = this.Get(ids);
            this.Remove(objectsToRemove);
        }
        #endregion

        #region Others

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
        
        #endregion
    }
}
