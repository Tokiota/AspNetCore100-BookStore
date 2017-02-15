using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokiota.BookStore.Context
{
    public static class Register
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IContext, Context>();
        }
    }
}
