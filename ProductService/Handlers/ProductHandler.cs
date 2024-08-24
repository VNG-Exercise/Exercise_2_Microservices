using ProductService.DbContexts;

namespace ProductService.Handlers
{
    public partial class ProductHandler(
        ProductDbContext dbContext,
        IServiceProvider serviceProvider,
        ILogger<ProductHandler> logger) :
        BaseHandler<ProductHandler>(dbContext, serviceProvider, logger)
    {
    }
}
