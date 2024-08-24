using Microsoft.EntityFrameworkCore;
using ProductService.DbContexts;

namespace ProductService.Extensions.ServiceExtensions
{
    public static class DbContextServiceExtension
    {
        public static void AddDbContextConfigurations(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var numberOfPool = 50;

            services.AddDbContextPool<ProductDbContext>(
                dbContextOptions => dbContextOptions.UseNpgsql(
                    configuration["DbConnectionString"]),
                numberOfPool);
        }
    }
}
