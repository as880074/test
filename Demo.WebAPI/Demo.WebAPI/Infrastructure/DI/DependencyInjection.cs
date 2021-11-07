using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Lib.Repository;
using Demo.Lib.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.WebAPI.Infrastructure.DI
{
    public class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //Service
            AddService(services);
            //Repository
            AddRepository(services);
        }

        public static void AddService(IServiceCollection services)
        {
            //Service
            services.AddTransient<UserService>();
        }
        public static void AddRepository(IServiceCollection services)
        {

            //Repository
            services.AddTransient<UserRepo>();
        }
    }
}
