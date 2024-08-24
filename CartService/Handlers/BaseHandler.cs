using CartService.DbContexts;
using CartService.Repositories;

namespace CartService.Handlers
{
    public abstract class BaseHandler<T>(
        CartDbContext dbContext,
        IProductRepository productRepository,
        IServiceProvider serviceProvider,
        ILogger<T> logger)
    {
        protected CartDbContext _dbContext = dbContext;
        protected IProductRepository _productRepository = productRepository;
        protected IServiceProvider _serviceProvider = serviceProvider;
        protected ILogger<T> _logger = logger;
    }
}
