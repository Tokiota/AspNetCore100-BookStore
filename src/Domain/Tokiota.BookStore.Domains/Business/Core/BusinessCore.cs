namespace Tokiota.BookStore.Domains.Business.Core
{
    using System.Collections.Generic;
    using Entities.Core;
    using System.Threading.Tasks;
    using XCutting;

    public class BusinessCore<TEntity, TId> : IBusinessCore<TEntity, TId> where TEntity : EntityCore<TId>
    {
        protected readonly ILibraryUoW Uow;
        protected readonly IRepositoryCore<TEntity, TId> Repository;

        public BusinessCore(ILibraryUoW uow, IRepositoryCore<TEntity, TId> repository)
        {
            Uow = uow;
            Repository = repository;
        }

        public virtual Task<TEntity> Get(TId id)
        {
            return Repository.Get(id);
        }

        public virtual Task<List<TEntity>> Get()
        {
            return Repository.Get();
        }

        public virtual Task<List<TEntity>> Get(IEnumerable<TId> ids)
        {
            return Repository.Get(ids);
        }

        public virtual Task Add(TEntity entity)
        {
            return Repository.Create(entity);
        }

        public virtual Task Add(IEnumerable<TEntity> entities)
        {
            return Repository.Create(entities);
        }

        public virtual void Update(TId id, TEntity entity)
        {
            // TId id is only for overrides
            entity.Id = id;
            Repository.Update(entity);
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            Repository.Update(entities);
        }

        public virtual Task Remove(TId id)
        {
            return Repository.Remove(id);
        }

        public virtual void Remove(TEntity entity)
        {
            Repository.Remove(entity);
        }

        public virtual Task Remove(IEnumerable<TId> ids)
        {
            return Repository.Remove(ids);
        }

        public virtual void Remove(IEnumerable<TEntity> entities)
        {
            Repository.Remove(entities);
        }

        public virtual Task SaveChanges()
        {
            return Uow.SaveChanges();
        }
    }
}
