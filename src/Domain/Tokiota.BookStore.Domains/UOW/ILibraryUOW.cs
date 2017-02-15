using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.Repositories;

namespace Tokiota.BookStore.Domains.UOW
{
    public interface ILibraryUOW
    {
        #region Gets
        Author GetAuthor(Guid id);
        List<Author> GetAuthors();
        List<Author> GetAuthorsComplete();
        List<Author> GetAuthors(List<Guid> ids);
        List<Author> GetAuthorsComplete(List<Guid> ids);
        Book GetBook(Guid id);
        List<Book> GetBooks();
        List<Book> GetBooksComplete();
        List<Book> GetBooks(List<Guid> ids);
        List<Book> GetBooksComplete(List<Guid> ids);
        Serie GetSerie(Guid id);
        List<Serie> GetSeries();
        List<Serie> GetSeries(List<Guid> ids);
        #endregion Gets

        #region Creates
        void CreateAuthor(Author author);

        void CreateSeries(List<Serie> series);
        void CreateBooks(List<Book> books);
        #endregion Creates


        #region Updates

        void UpdateAuthor(Guid id, Author authorRaw);


        void UpdateBook(Guid id, Book bookRaw);
        void UpdateSerie(Guid id, Serie serieRaw);

        #endregion Updates
        #region Remove
        void RemoveAuthor(Guid id);
        void RemoveBook(Guid id);
        void RemoveSerie(Guid id);
        #endregion Remove

    }
}
