
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Entities.Core;

namespace Tokiota.BookStore.Repositories.Core
{
    public interface IRepositoryCore<TEntity, TId> where TEntity : EntityCore<TId>
    {
        #region Gets
        IEnumerable<TEntity> Get();
        TEntity Get(TId id);
        IEnumerable<TEntity> Get(IEnumerable<TId> ids);
        #endregion

        #region Commands
        void Create(TEntity objectToCreate);
        void Create(IEnumerable<TEntity> objectsToCreate);

        void Update(TEntity objectToUpdate);
        void Update(IEnumerable<TEntity> objectsToUpdate);

        void Remove(TEntity objectToRemove);
        void Remove(IEnumerable<TEntity> objectsToRemove);
        void Remove(TId id);
        void Remove(IEnumerable<TId> ids);
        #endregion
        #region Others
        void SaveChanges();
        #endregion
    }
}
