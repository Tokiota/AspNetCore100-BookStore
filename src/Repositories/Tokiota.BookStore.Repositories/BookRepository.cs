using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Context;
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.Repositories.Core;

namespace Tokiota.BookStore.Repositories
{
    public class BookRepository : IRepositoryCore<Book, Guid>
    {
        private readonly IContext context;

        public BookRepository(IContext context)
        {
            this.context = context;
        }

        public void Create(List<Book> objectsToCreate)
        {
            objectsToCreate.ForEach(this.Create);
        }

        public void Create(Book objectToCreate)
        {
            this.context.Books.Add(objectToCreate);
        }

        public List<Book> Get()
        {
            return this.context.Books;
        }

        public List<Book> Get(List<Guid> ids)
        {
            return this.context.Books.Where(a => ids.Contains(a.Id)).ToList();
        }

        public Book Get(Guid id)
        {
            return this.context.Books.FirstOrDefault(a => a.Id.Equals(id));
        }

        public void Remove(List<Book> objectsToRemove)
        {
            objectsToRemove.ForEach(this.Remove);
        }

        public void Remove(Guid id)
        {
            var Book = this.Get(id);
            this.Remove(Book);
        }

        public void Remove(List<Guid> ids)
        {
            var Books = this.Get(ids);
            this.Remove(Books.ToList());
        }

        public void Remove(Book objectToRemove)
        {
            this.context.Books.Remove(objectToRemove);
        }

        public void Update(List<Book> objectsToUpdate)
        {
            objectsToUpdate.ForEach(this.Update);
        }

        public void Update(Book objectToUpdate)
        {
            var Book = this.context.Books.FirstOrDefault(a => a.Id.Equals(objectToUpdate.Id));
            if (Book != null)
            {
                Book.Name = objectToUpdate.Name;
                Book.Genre = objectToUpdate.Genre;
                Book.Published = objectToUpdate.Published;
                Book.AuthorId = objectToUpdate.AuthorId;
                Book.SerieId = objectToUpdate.SerieId;
            }
        }
    }
}
