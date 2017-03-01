using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokiota.BookStore.Web
{
    public static class Register
    {
        public static void Configure(IServiceCollection services)
        {

            Domains.Register.Configure(services);
        }
    }
}
