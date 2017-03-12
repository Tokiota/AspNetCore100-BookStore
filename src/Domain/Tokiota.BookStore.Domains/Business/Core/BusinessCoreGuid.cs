
namespace Tokiota.BookStore.Domains.Business.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities.Core;
    using XCutting;

    public class BusinessCoreGuid<TEntity> : BusinessCore<TEntity, Guid>, IBusinessCoreGuid<TEntity> where TEntity : EntityCore<Guid>
    {
        public BusinessCoreGuid(ILibraryUoW uow, IRepositoryCore<TEntity, Guid> repository) : base(uow, repository) { }


        public override Task Add(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            return Repository.Create(entity);
        }

        public override Task Add(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Id = Guid.NewGuid();
            }

            return Repository.Create(entities);
        }
    }
}
