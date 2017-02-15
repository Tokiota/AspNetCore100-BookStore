namespace Tokiota.BookStore.Domains.Core
{
    using System;
    using System.Collections.Generic;
    using Entities.Core;
    using Repositories.Core;
    public class DomainCore<TEntity> where TEntity : EntityCore<Guid>
    {
        private readonly IRepositoryCore<TEntity, Guid> repository;

        public DomainCore(IRepositoryCore<TEntity, Guid> repo)
        {
            this.repository = repo;
        }

        public void Create(List<TEntity> objectsToCreate)
        {
            objectsToCreate.ForEach(o => o.Id = Guid.NewGuid());
            this.repository.Create(objectsToCreate);
        }

        public void Create(TEntity objectToCreate)
        {
            objectToCreate.Id = Guid.NewGuid();
            this.repository.Create(objectToCreate);
        }

        public List<TEntity> Get()
        {
            return this.repository.Get();
        }

        public List<TEntity> Get(List<Guid> ids)
        {
            return this.repository.Get(ids);
        }

        public TEntity Get(Guid id)
        {
            return this.repository.Get(id);
        }

        public void Remove(List<TEntity> objectsToRemove)
        {
            this.repository.Remove(objectsToRemove);
        }

        public void Remove(List<Guid> ids)
        {
            this.repository.Remove(ids);
        }

        public void Remove(Guid id)
        {
            this.repository.Remove(id);
        }

        public void Remove(TEntity objectToRemove)
        {
            this.repository.Remove(objectToRemove);
        }

        public void Update(List<TEntity> objectsToUpdate)
        {
            this.repository.Update(objectsToUpdate);
        }

        public void Update(TEntity objectToUpdate)
        {
            this.repository.Update(objectToUpdate);
        }
    }
}
