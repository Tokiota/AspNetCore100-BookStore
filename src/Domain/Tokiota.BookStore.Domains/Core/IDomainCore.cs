namespace Tokiota.BookStore.Domains.Core
{
    using System;
    using System.Collections.Generic;
    using Entities.Core;
    public interface IDomainCore<TEntity> where TEntity : EntityCore<Guid>
    {
        void Create(List<TEntity> objectsToCreate);
        void Create(TEntity objectToCreate);
        List<TEntity> Get();
        List<TEntity> Get(List<Guid> ids);
        TEntity Get(Guid id);
        void Remove(List<TEntity> objectsToRemove);
        void Remove(List<Guid> ids);
        void Remove(Guid id);
        void Remove(TEntity objectToRemove);
        void Update(List<TEntity> objectsToUpdate);
        void Update(TEntity objectToUpdate);
    }
}
