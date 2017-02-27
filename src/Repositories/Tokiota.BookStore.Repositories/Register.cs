using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokiota.BookStore.Repositories
{
    public static class Register
    {
        public static void Configure(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ISerieRepository, SerieRepository>();

            Context.Register.Configure(services, configuration);
        }
    }
}
