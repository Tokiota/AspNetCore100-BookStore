
namespace Tokiota.BookStore.Domains.UOW
{
    using Entities;
    using Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class LibraryUOW : ILibraryUOW
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IBookRepository bookRepository;
        private readonly ISerieRepository serieRepository;

        public LibraryUOW(IAuthorRepository authorRepository, IBookRepository bookRepository, ISerieRepository serieRepository)
        {
            this.authorRepository = authorRepository;
            this.bookRepository = bookRepository;
            this.serieRepository = serieRepository;
        }

        #region Gets
        public Author GetAuthor(Guid id)
        {
            return this.authorRepository.Get(id);
        }

        public List<Author> GetAuthors()
        {
            return this.authorRepository.Get().ToList();
        }

        public List<Author> GetAuthorsComplete()
        {
            var authors = this.GetAuthors();
            if (authors.Any())
            {
                var books = this.GetBooksComplete(authors.Select(a => a.Id).ToList());
                if (books.Any())
                {
                    authors.ForEach(a => a.Books = books.Where(b => b.AuthorId == a.Id).ToList());
                }
            }

            return authors;
        }

        public List<Author> GetAuthors(List<Guid> ids)
        {
            return this.authorRepository.Get(ids).ToList();
        }

        public List<Author> GetAuthorsComplete(List<Guid> ids)
        {
            var authors = this.GetAuthors(ids);
            if (authors.Any())
            {
                var books = this.GetBooksComplete(authors.Select(a => a.Id).ToList());
                if (books.Any())
                {
                    authors.ForEach(a => a.Books = books.Where(b => b.AuthorId == a.Id).ToList());
                }
            }

            return authors;
        }

        public Book GetBook(Guid id)
        {
            return this.bookRepository.Get(id);
        }

        public List<Book> GetBooks()
        {
            return this.bookRepository.Get().ToList();
        }

        public List<Book> GetBooksComplete()
        {
            var books = this.GetBooks();
            var series = this.serieRepository.Get(books.Select(b => b.Id).ToList());
            books.ForEach(b => b.Serie = series.FirstOrDefault(s => s.Id == b.SerieId));
            return books;
        }

        public List<Book> GetBooks(List<Guid> ids)
        {
            return this.bookRepository.Get().ToList();
        }

        public List<Book> GetBooksComplete(List<Guid> ids)
        {
            var books = this.GetBooks(ids);
            var series = this.serieRepository.Get(books.Select(b => b.Id).ToList());
            books.ForEach(b => b.Serie = series.FirstOrDefault(s => s.Id == b.SerieId));
            return books;
        }

        public Serie GetSerie(Guid id)
        {
            return this.serieRepository.Get(id);
        }


        public List<Serie> GetSeries()
        {
            return this.serieRepository.Get().ToList();
        }

        public List<Serie> GetSeries(List<Guid> ids)
        {
            return this.serieRepository.Get(ids).ToList();
        }
        #endregion Gets

        #region Creates
        public void CreateAuthor(Author author)
        {
            if (author != null)
            {
                var authorId = Guid.NewGuid();
                author.Id = authorId;

                if (author.Books != null && author.Books.Any())
                {
                    this.CreateBooks(authorId, author.Books);
                }
                this.authorRepository.Create(author);
            }

        }

        public void CreateSeries(List<Serie> series)
        {
            series.ForEach(s => s.Id = Guid.NewGuid());
            this.serieRepository.Create(series);
        }

        public void CreateSerie(Serie serie)
        {
            serie.Id = Guid.NewGuid();
            this.serieRepository.Create(serie);
        }

        public void CreateBooks(List<Book> books)
        {
            var series = books.Select(b => b.Serie).ToList();
            this.CreateSeries(series);
            books.ForEach(b =>
            {
                b.Id = Guid.NewGuid();
                if (b.Serie != null && series != null && series.Any())
                {
                    b.SerieId = series.FirstOrDefault(s => s.Name == b.Serie.Name).Id;
                }
            });
        }
        public void CreateBook(Book book)
        {
            book.Id = Guid.NewGuid();
            if (book.Serie != null)
            {
                this.CreateSerie(book.Serie);
                book.SerieId = book.Serie.Id;
            }
            this.bookRepository.Create(book);
        }

        private void CreateBooks(Guid authorId, List<Book> books)
        {
            books.ForEach(b =>
            {
                b.AuthorId = authorId;
                if (b.Serie != null) b.Serie.AuthorId = authorId;
            });

            this.CreateBooks(books);
        }

        #endregion Creates


        #region Updates

        public void UpdateAuthor(Guid id, Author authorRaw)
        {
            if (authorRaw != null && id != null && id != Guid.Empty)
            {
                var author = this.GetAuthor(id);
                if (author != null)
                {
                    author.Name = authorRaw.Name;
                    author.LastName = authorRaw.LastName;
                    author.Born = authorRaw.Born;
                }
            }
        }

        public void UpdateBook(Guid id, Book bookRaw)
        {
            if (bookRaw != null && id != null && id != Guid.Empty)
            {
                var book = this.GetBook(id);
                if (book != null)
                {
                    book.Name = bookRaw.Name;
                    book.Published = bookRaw.Published;
                    book.Genre = bookRaw.Genre;
                }
            }
        }

        public void UpdateSerie(Guid id, Serie serieRaw)
        {
            if (serieRaw != null && id != null && id != Guid.Empty)
            {
                var serie = this.GetSerie(id);
                if (serie != null)
                {
                    serie.Name = serieRaw.Name;
                }
            }
        }

        #endregion Updates
        #region Remove
        public void RemoveAuthor(Guid id)
        {
            this.authorRepository.Remove(id);
        }
        public void RemoveBook(Guid id)
        {
            this.bookRepository.Remove(id);
        }
        public void RemoveSerie(Guid id)
        {
            this.serieRepository.Remove(id);
        }
        #endregion Remove


    }
}
