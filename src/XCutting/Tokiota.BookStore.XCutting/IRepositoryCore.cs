using System;
using System.Linq.Expressions;

namespace Tokiota.BookStore.XCutting
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities.Core;

    public interface IRepositoryCore<TEntity, TId> where TEntity : EntityCore<TId>
    {
        #region Gets

        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity> Get(TId id);

        Task<List<TEntity>> Get(IEnumerable<TId> ids);

        #endregion

        #region Commands

        Task Create(TEntity objectToCreate);

        Task Create(IEnumerable<TEntity> objectsToCreate);

        void Update(TEntity objectToUpdate);

        void Update(IEnumerable<TEntity> objectsToUpdate);

        void Remove(TEntity objectToRemove);

        void Remove(IEnumerable<TEntity> objectsToRemove);

        Task Remove(TId id);

        Task Remove(IEnumerable<TId> ids);

        #endregion

        #region Others

        Task<int> SaveChanges();

        #endregion
    }
}
