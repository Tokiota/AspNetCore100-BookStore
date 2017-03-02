namespace Tokiota.BookStore.Domains.Business.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Entities.Core;
    using Repositories.Services.Core;
    using Repositories.UoW;

    public class BusinessCore<TEntity, TId> : IBusinessCore<TEntity, TId> where TEntity : EntityCore<TId>
    {
        protected readonly ILibraryUoW _uow;
        protected readonly IRepositoryCore<TEntity, TId> _repository;

        public BusinessCore(ILibraryUoW uow, IRepositoryCore<TEntity, TId> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public virtual TEntity Get(TId id)
        {
            return _repository.Get(id);
        }

        public virtual List<TEntity> Get()
        {
            return _repository.Get().ToList();
        }

        public virtual List<TEntity> Get(IEnumerable<TId> ids)
        {
            return _repository.Get(ids).ToList();
        }

        public virtual void Add(TEntity entity)
        {
            _repository.Create(entity);
            _uow.SaveChanges();
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            _repository.Create(entities);
            _uow.SaveChanges();
        }

        public virtual void Update(TId id, TEntity entity)
        {
            // TId id is only for overrides
            entity.Id = id;
            _repository.Update(entity);
            _uow.SaveChanges();
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            _repository.Update(entities);
            _uow.SaveChanges();
        }

        public virtual void Remove(TId id)
        {
            _repository.Remove(id);
            _uow.SaveChanges();
        }

        public virtual void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _uow.SaveChanges();
        }

        public virtual void Remove(IEnumerable<TId> ids)
        {
            _repository.Remove(ids);
            _uow.SaveChanges();
        }

        public virtual void Remove(IEnumerable<TEntity> entities)
        {
            _repository.Remove(entities);
            _uow.SaveChanges();
        }
    }
}
