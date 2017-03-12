namespace Tokiota.BookStore.XCutting
{
    using System;
    using Entities;

    public interface ILibraryUoW : IUoW
    {
        IRepositoryCore<Author, Guid> AuthorRepository { get; }
        IRepositoryCore<Book, Guid> BookRepository { get; }
        IRepositoryCore<Serie, Guid> SerieRepository { get; }
    }
}
