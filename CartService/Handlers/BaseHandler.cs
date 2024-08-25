using CartService.DbContexts;
using CartService.Infrastructure.Communications.Refit.ProductService;

namespace CartService.Handlers
{
    public abstract class BaseHandler<T>(
        CartDbContext dbContext,
        IProductService productService,
        IServiceProvider serviceProvider,
        ILogger<T> logger)
    {
        protected CartDbContext _dbContext = dbContext;
        protected IProductService _productService = productService;
        protected IServiceProvider _serviceProvider = serviceProvider;
        protected ILogger<T> _logger = logger;
    }
}
