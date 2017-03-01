using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Domains.UOW;

namespace Tokiota.BookStore.Domains
{
    public static class Register
    {
        public static void Configure(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddScoped<ILibraryUOW, LibraryUOW>();

            Repositories.Register.Configure(services, configuration);
        }
    }
}
