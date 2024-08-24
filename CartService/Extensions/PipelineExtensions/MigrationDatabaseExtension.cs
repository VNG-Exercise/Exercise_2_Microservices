using CartService.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CartService.Extensions.PipelineExtensions
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
                var context = serviceProvider.GetRequiredService<CartDbContext>();
                context.Database.Migrate();
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
