using CartService.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CartService.Extensions.ServiceExtensions
{
    public static class DbContextServiceExtension
    {
        public static void AddDbContextConfigurations(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var numberOfPool = 50;

            services.AddDbContextPool<CartDbContext>(
                dbContextOptions => dbContextOptions.UseNpgsql(
                    configuration["DbConnectionString"]),
                numberOfPool);
        }
    }
}
