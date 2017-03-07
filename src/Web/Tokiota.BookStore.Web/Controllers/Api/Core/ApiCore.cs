namespace Tokiota.BookStore.Web.Controllers.Api.Core
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domains.Business.Core;
    using Entities.Core;
    using Mapster;
    using Microsoft.AspNetCore.Mvc;

    #endregion

    public class ApiCore<TEnity, TDto> : Controller where TEnity : EntityCore<Guid>
    {
        protected readonly IBusinessCoreGuid<TEnity> Business;
        protected readonly Adapter Mapper;

        public ApiCore(IBusinessCoreGuid<TEnity> business, Adapter mapper)
        {
            Business = business;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entities = await Business.Get();
            var mappedEntities = Mapper.Adapt<IEnumerable<TDto>>(entities);

            return Ok(mappedEntities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!id.Equals(Guid.Empty))
            {
                var entity = await Business.Get(id);
                if (entity != null)
                {
                    var mappedEntity = Mapper.Adapt<TDto>(entity);
                    return Ok(mappedEntity);
                }
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(TEnity entity)
        {
            if (entity != null && ModelState.IsValid )
            {
                await Business.Add(entity);
                await Business.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid id, TEnity entity)
        {
            if (id != Guid.Empty && ModelState.IsValid && entity != null)
            {
                Business.Update(id, entity);
                await Business.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                await Business.Remove(id);
                await Business.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }
    }
}