using System.Collections.Generic;
using Tokiota.BookStore.Entities.Core;

namespace Tokiota.BookStore.Domains.Business.Core
{
    public interface IBusinessCore<TEntity, TId> where TEntity : EntityCore<TId>
    {
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        List<TEntity> Get();
        TEntity Get(TId id);
        List<TEntity> Get(IEnumerable<TId> ids);
        void Remove(TId id);
        void Remove(TEntity entity);
        void Remove(IEnumerable<TId> ids);
        void Remove(IEnumerable<TEntity> entities);
        void Update(IEnumerable<TEntity> entities);
        void Update(TId id, TEntity entity);
    }
}