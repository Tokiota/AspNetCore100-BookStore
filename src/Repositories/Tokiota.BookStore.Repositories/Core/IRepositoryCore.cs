
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
        List<TEntity> Get();
        TEntity Get(TId id);
        List<TEntity> Get(List<TId> ids);
        #endregion

        #region Commands
        void Create(TEntity objectToCreate);
        void Create(List<TEntity> objectsToCreate);

        void Update(TEntity objectToUpdate);
        void Update(List<TEntity> objectsToUpdate);

        void Remove(TEntity objectToRemove);
        void Remove(List<TEntity> objectsToRemove);
        void Remove(TId id);
        void Remove(List<TId> ids);
        #endregion
    }
}
