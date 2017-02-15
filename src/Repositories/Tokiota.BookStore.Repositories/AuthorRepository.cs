using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Context;
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.Repositories.Core;

namespace Tokiota.BookStore.Repositories
{
    public class AuthorRepository : IRepositoryCore<Author, Guid>
    {
        private readonly IContext context;

        public AuthorRepository(IContext context)
        {
            this.context = context;
        }

        public void Create(List<Author> objectsToCreate)
        {
            objectsToCreate.ForEach(this.Create);
        }

        public void Create(Author objectToCreate)
        {
            this.context.Authors.Add(objectToCreate);
        }

        public List<Author> Get()
        {
            return this.context.Authors;
        }

        public List<Author> Get(List<Guid> ids)
        {
            return this.context.Authors.Where(a => ids.Contains(a.Id)).ToList();
        }

        public Author Get(Guid id)
        {
            return this.context.Authors.FirstOrDefault(a => a.Id.Equals(id));
        }

        public void Remove(List<Author> objectsToRemove)
        {
            objectsToRemove.ForEach(this.Remove);
        }

        public void Remove(Guid id)
        {
            var author = this.Get(id);
            this.Remove(author);
        }

        public void Remove(List<Guid> ids)
        {
            var authors = this.Get(ids);
            this.Remove(authors.ToList());
        }

        public void Remove(Author objectToRemove)
        {
            this.context.Authors.Remove(objectToRemove);
        }

        public void Update(List<Author> objectsToUpdate)
        {
            objectsToUpdate.ForEach(this.Update);
        }

        public void Update(Author objectToUpdate)
        {
            var author = this.context.Authors.FirstOrDefault(a => a.Id.Equals(objectToUpdate.Id));
            if (author != null)
            {
                author.Name = objectToUpdate.Name;
                author.LastName = objectToUpdate.LastName;
                author.Born = objectToUpdate.Born;
            }
        }
    }
}
