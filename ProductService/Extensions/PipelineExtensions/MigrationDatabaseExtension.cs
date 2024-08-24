using Microsoft.EntityFrameworkCore;
using ProductService.DbContexts;
using ProductService.Seed;

namespace ProductService.Extensions.PipelineExtensions
{
    public static class MigrationDatabaseExtension
    {
        public static void UseMigrationDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            try
            {
                var context = serviceProvider.GetRequiredService<ProductDbContext>();
                context.Database.Migrate();

                DataSeeder.Seed(serviceProvider, context);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<WebApplication>();
                logger.LogError(ex, "An error occurred seeding the DB.");
                throw new Exception(ex.Message);
            }
        }
    }
}
