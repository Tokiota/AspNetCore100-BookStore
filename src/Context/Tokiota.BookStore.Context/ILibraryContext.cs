using Microsoft.EntityFrameworkCore;
using Tokiota.BookStore.Entities;

namespace Tokiota.BookStore.Context
{
    public interface ILibraryContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Serie> Series { get; set; }
        int SaveChanges();
    }
}