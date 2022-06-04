using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SuperStore.DAL;
using SuperStore.Services.Business;

namespace SuperStore.Services
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ConfigureServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();

            services.ConfigureDalDependencies();

            return services;
        }

        public static void ConfigureServiceDbContext(this IServiceCollection services, string connectionString)
        {
            services.ConfigureDalDbContexts(connectionString, asNoTracking:false);
        }
    }
}
