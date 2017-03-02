namespace Tokiota.BookStore.Domains.Business.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities.Core;

    public interface IBusinessCore<TEntity, TId> where TEntity : EntityCore<TId>
    {
        Task<TEntity> Get(TId id);

        Task<List<TEntity>> Get();

        Task<List<TEntity>> Get(IEnumerable<TId> ids);

        Task Add(TEntity entity);

        Task Add(IEnumerable<TEntity> entities);

        void Update(TId id, TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        Task Remove(TId id);

        void Remove(TEntity entity);

        Task Remove(IEnumerable<TId> ids);

        void Remove(IEnumerable<TEntity> entities);

        Task SaveChanges();
    }
}