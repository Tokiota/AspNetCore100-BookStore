using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Newtonsoft.Json;

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
        protected readonly IDistributedCache Cache;
        protected readonly string MyApiKey;

        public ApiCore(string myApiKey, IBusinessCoreGuid<TEnity> business, Adapter mapper, IDistributedCache cache)
        {
            Business = business;
            Mapper = mapper;
            Cache = cache;
            MyApiKey = myApiKey;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entitiesCached = await Cache.GetStringAsync($"get_{MyApiKey}");
            IEnumerable<TDto> mappedEntities = null;
            if (entitiesCached == null)
            {
                var entities = await Business.Get();
                mappedEntities = Mapper.Adapt<IEnumerable<TDto>>(entities);
                var cacheEntryOptions = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(30));
                var str = JsonConvert.SerializeObject(mappedEntities);


                await Cache.SetStringAsync($"get_{MyApiKey}", str, cacheEntryOptions);
            }
            else
            {
                mappedEntities = JsonConvert.DeserializeObject<IEnumerable<TDto>>(entitiesCached);
            }

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
        public async Task<IActionResult> Post([FromBody]TEnity entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                await Business.Add(entity);
                await Business.SaveChanges();
                await Cache.RemoveAsync($"get_{MyApiKey}");
                return Ok(new { });
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]TEnity entity)
        {
            if (id != Guid.Empty && ModelState.IsValid && entity != null)
            {
                Business.Update(id, entity);
                await Business.SaveChanges();
                await Cache.RemoveAsync($"get_{MyApiKey}");
                return Ok(new { });
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                await Business.Remove(id);
                await Business.SaveChanges();
                await Cache.RemoveAsync($"get_{MyApiKey}");
                return Ok(new { });
            }

            return BadRequest();
        }
    }
}