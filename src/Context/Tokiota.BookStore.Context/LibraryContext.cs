
namespace Tokiota.BookStore.Context
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class LibraryContext : DbContext, ILibraryContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            //LibraryContextInitializer.Initialize(this);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Serie> Series { get; set; }
        //public DbSet<Permision> Permisions { get; set; }
        //public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                        .ToTable("Author");

            modelBuilder.Entity<Book>()
                        .ToTable("Book")
                        .HasOne(b => b.Serie)
                        .WithMany(s => s.Books).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
                        .ToTable("Serie");
            //modelBuilder.Entity<User>().ToTable("User");

            //modelBuilder.Entity<UserPermision>()
            //            .ToTable("UserPermision")
            //            .HasKey(u => new { u.PermisionId, u.UserId });

            //modelBuilder.Entity<UserPermision>()
            //            .HasOne(up => up.User)
            //            .WithMany(up => up.UserPermisions)
            //            .HasForeignKey(up => up.UserId);

            //modelBuilder.Entity<UserPermision>()
            //            .HasOne(up => up.Permision)
            //            .WithMany(up => up.UserPermisions)
            //            .HasForeignKey(up => up.PermisionId);


            //modelBuilder.Entity<Permision>().ToTable("Permision");
            //modelBuilder.Entity<CourseAssignment>()
            //    .HasKey(c => new { c.CourseID, c.InstructorID });


        }
    }
}
