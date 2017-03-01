using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokiota.BookStore.Repositories
{
    public static class Register
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IAuthorRepository, AuthorRepository>();
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<ISerieRepository, SerieRepository>();

            Context.Register.Configure(services);
        }
    }
}
