using Tokiota.BookStore.Repositories.Services.Core;

namespace Tokiota.BookStore.Repositories.UoW
{
    using System;
    using System.Threading.Tasks;
    using Context;
    using Entities;
    using XCutting;

    public class LibraryUoW : ILibraryUoW
    {
        private readonly LibraryContext _context;

        public IRepositoryCore<Author, Guid> AuthorRepository => new RepositoryCore<Author, Guid>(_context);
        public IRepositoryCore<Book, Guid> BookRepository => new RepositoryCore<Book, Guid>(_context);
        public IRepositoryCore<Serie, Guid> SerieRepository => new RepositoryCore<Serie, Guid>(_context);

        private bool CanSave = true;

        public LibraryUoW(LibraryContext context)
        {
            this._context = context;
        }

        public Task<int> SaveChanges()
        {
            if (CanSave) return _context.SaveChangesAsync();
            return Task.Run(() => -1);
        }
    }
}
