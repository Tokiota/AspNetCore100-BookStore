using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Context;
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.Repositories.Services;
using Tokiota.BookStore.Repositories.Services.Core;
using Tokiota.BookStore.Repositories.UoW;

namespace Tokiota.BookStore.Repositories
{
    public static class Register
    {
        public static void Configure(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddScoped<ILibraryUoW, LibraryUoW>();

            services.AddScoped<IRepositoryCore<Author, Guid>, RepositoryCore<Author, Guid>>();
            services.AddScoped<IRepositoryCore<Book, Guid>, RepositoryCore<Book, Guid>>();
            services.AddScoped<IRepositoryCore<Serie, Guid>, RepositoryCore<Serie, Guid>>();

            Context.Register.Configure(services, configuration);
        }
    }
}
