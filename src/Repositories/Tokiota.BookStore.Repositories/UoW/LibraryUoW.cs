using System;
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.Repositories.Services.Core;

namespace Tokiota.BookStore.Repositories.UoW
{
    using Context;
    using Services;

    public class LibraryUoW : ILibraryUoW
    {
        private readonly LibraryContext _context;

        public IRepositoryCore<Author, Guid> AuthorRepository { get; private set; }
        public IRepositoryCore<Book, Guid> BookRepository { get; private set; }
        public IRepositoryCore<Serie, Guid> SerieRepository { get; private set; }

        private bool CanSave = true;

        public LibraryUoW(LibraryContext context, IRepositoryCore<Author, Guid> authorRepository, IRepositoryCore<Book, Guid> bookRepository, IRepositoryCore<Serie, Guid> serieRepository)
        {
            this._context = context;
            this.AuthorRepository = authorRepository;
            this.BookRepository = bookRepository;
            this.SerieRepository = serieRepository;
        }

        public int SaveChanges()
        {
            if (CanSave) return _context.SaveChanges();
            return -1;
        }
    }
}
