using Tokiota.BookStore.Domains.Business.Core;
using Tokiota.BookStore.Entities;

namespace Tokiota.BookStore.Domains
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    public static class Register
    {
        public static void Configure(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddScoped<IBusinessCoreGuid<Author>, BusinessCoreGuid<Author>>();
            services.AddScoped<IBusinessCoreGuid<Book>, BusinessCoreGuid<Book>>();
            services.AddScoped<IBusinessCoreGuid<Serie>, BusinessCoreGuid<Serie>>();

            Repositories.Register.Configure(services, configuration);
        }
    }
}
