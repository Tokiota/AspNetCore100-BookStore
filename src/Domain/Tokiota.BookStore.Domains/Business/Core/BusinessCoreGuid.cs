namespace Tokiota.BookStore.Domains.Business.Core
{
    using System;
    using System.Collections.Generic;
    using Entities.Core;
    using Repositories.Services.Core;
    using Repositories.UoW;

    public class BusinessCoreGuid<TEntity> : BusinessCore<TEntity, Guid>, IBusinessCoreGuid<TEntity> where TEntity : EntityCore<Guid>
    {
        public BusinessCoreGuid(ILibraryUoW uow, IRepositoryCore<TEntity, Guid> repository) : base(uow, repository) { }


        public override void Add(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            _repository.Create(entity);
        }

        public override void Add(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Id = Guid.NewGuid();
            }

            _repository.Create(entities);
        }
    }
}
