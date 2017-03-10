using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tokiota.BookStore.Context;
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.Repositories.UoW;
using Tokiota.BookStore.XCutting;

namespace Tokiota.BookStore.Tests.UseCases.Common
{
    public class ContextFactory
    {
        public ILibraryUoW Uow;

        public ContextFactory()
        {
            DbContextOptionsBuilder<LibraryContext> builder = new DbContextOptionsBuilder<LibraryContext>();
            var context = new LibraryContext(builder.UseInMemoryDatabase().Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Uow = new LibraryUoW(context);
            Initialize().Wait();
        }

        public async Task Initialize()
        {
            var authors = await Uow.AuthorRepository.Get();
            if (!authors.Any())
            {
                SetAuthor();
                await Uow.SaveChanges();
            }
        }

        private void SetAuthor()
        {

            Uow.AuthorRepository.Create(new Author()
            {
                Id = Guid.Parse("fac93f1e-ff28-49db-b234-13c9a5df2334"),
                Photo = "url",
                Name = "Simon",
                LastName = "Scarrow",
                Born = 1900
            });

            Uow.AuthorRepository.Create(new Author()
            {
                Id = Guid.Parse("feb46c6a-7baa-43c0-b287-77e2708410d1"),
                Photo = "url",
                Name = "Epi",
                LastName = "asdkljaksd",
                Born = 1900
            });

            Uow.AuthorRepository.Create(new Author()
            {
                Id = Guid.Parse("f6dfa921-efb4-43c8-8d31-1b9f877f8594"),
                Photo = "url",
                Name = "Blas",
                LastName = "asdkljaksd",
                Born = 1900
            });
        }
    }
}
