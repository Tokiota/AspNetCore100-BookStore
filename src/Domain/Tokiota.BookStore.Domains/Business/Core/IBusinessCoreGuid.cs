namespace Tokiota.BookStore.Domains.Business.Core
{
    using System;
    using Entities.Core;

    public interface IBusinessCoreGuid<TEntity> : IBusinessCore<TEntity, Guid> where TEntity : EntityCore<Guid>
    {
    }
}
