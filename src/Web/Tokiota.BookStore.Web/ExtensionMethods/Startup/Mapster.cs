using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokiota.BookStore.Web.ExtensionMethods.Startup
{
    public static class Mapster
    {
        public static void AddMapster(this IServiceCollection services)
        {
            var config = new TypeAdapterConfig();
            var mapperResgiter = new MapperResgiter();
            mapperResgiter.Register(config);

            var mapper = new Adapter();
            services.AddSingleton(mapper);
        }

    }
}
