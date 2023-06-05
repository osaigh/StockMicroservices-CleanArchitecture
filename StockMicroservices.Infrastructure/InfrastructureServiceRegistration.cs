using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockMicroservices.Domain.Repository;
using StockMicroservices.Infrastructure.Persistence;
using StockMicroservices.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMicroservices.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddMongodbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSetting>(configuration.GetSection("Database"));
            services.AddScoped<IStockDbContext, MongoDbContext>();
            return services;
        }

        public static IServiceCollection AddEntityFrameworkContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EntityFrameworkDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStockRepository, StockRepository>();

            return services;
        }
    }
}
