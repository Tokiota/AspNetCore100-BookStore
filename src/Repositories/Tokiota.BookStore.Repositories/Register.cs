namespace Tokiota.BookStore.Repositories
{
    using System;
    using Entities;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Core;
    using UoW;
    using XCutting;

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
