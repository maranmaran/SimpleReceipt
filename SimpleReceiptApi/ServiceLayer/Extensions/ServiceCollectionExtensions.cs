using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Data;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Operations;

namespace ServiceLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddTransient<IApplicationUserOperations, ApplicationUserOperations>();
            services.AddTransient<IAccountOperations, AccountOperations>();
            services.AddTransient<IReceiptOperations, ReceiptOperations>();
            services.AddTransient<ICafeOperations, CafeOperations>();
            services.AddTransient<ITableOperations, TableOperations>();

            return services;
        }
    }
}
