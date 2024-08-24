using CartService.DbContexts;
using CartService.Repositories;

namespace CartService.Handlers
{
    public partial class CartHandler(
        CartDbContext dbContext,
        IProductRepository productRepository,
        IServiceProvider serviceProvider,
        ILogger<CartHandler> logger) :
        BaseHandler<CartHandler>(dbContext, productRepository, serviceProvider, logger)
    {
    }
}
