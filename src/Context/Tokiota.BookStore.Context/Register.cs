using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.XCutting;

namespace Tokiota.BookStore.Context
{
    public static class Register
    {
        public static void Configure(IServiceCollection services, IConfigurationRoot configuration)
        {
            //services.AddSingleton<IContext, Context>();
            services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IInitializer, Initializer>();
        }
    }
}
