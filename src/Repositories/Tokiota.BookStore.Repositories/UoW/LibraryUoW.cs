using System.Threading.Tasks;

namespace Tokiota.BookStore.Repositories.UoW
{
    using System;
    using Context;
    using Entities;
    using Services.Core;

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

        public Task<int> SaveChanges()
        {
            if (CanSave) return _context.SaveChangesAsync();
            return Task.Run(() => -1);
        }
    }
}
