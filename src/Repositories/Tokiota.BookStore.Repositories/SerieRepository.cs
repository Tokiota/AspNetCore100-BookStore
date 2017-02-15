using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Context;
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.Repositories.Core;

namespace Tokiota.SerieStore.Repositories
{
    public class SerieRepository : IRepositoryCore<Serie, Guid>
    {
        private readonly IContext context;

        public SerieRepository(IContext context)
        {
            this.context = context;
        }

        public void Create(List<Serie> objectsToCreate)
        {
            objectsToCreate.ForEach(this.Create);
        }

        public void Create(Serie objectToCreate)
        {
            this.context.Series.Add(objectToCreate);
        }

        public List<Serie> Get()
        {
            return this.context.Series;
        }

        public List<Serie> Get(List<Guid> ids)
        {
            return this.context.Series.Where(a => ids.Contains(a.Id)).ToList();
        }

        public Serie Get(Guid id)
        {
            return this.context.Series.FirstOrDefault(a => a.Id.Equals(id));
        }

        public void Remove(List<Serie> objectsToRemove)
        {
            objectsToRemove.ForEach(this.Remove);
        }

        public void Remove(Guid id)
        {
            var Serie = this.Get(id);
            this.Remove(Serie);
        }

        public void Remove(List<Guid> ids)
        {
            var Series = this.Get(ids);
            this.Remove(Series.ToList());
        }

        public void Remove(Serie objectToRemove)
        {
            this.context.Series.Remove(objectToRemove);
        }

        public void Update(List<Serie> objectsToUpdate)
        {
            objectsToUpdate.ForEach(this.Update);
        }

        public void Update(Serie objectToUpdate)
        {
            var Serie = this.context.Series.FirstOrDefault(a => a.Id.Equals(objectToUpdate.Id));
            if (Serie != null)
            {
                Serie.Name = objectToUpdate.Name;
                Serie.AuthorId = objectToUpdate.AuthorId;
            }
        }
    }
}
