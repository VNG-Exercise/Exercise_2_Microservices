using ProductService.DbContexts;

namespace ProductService.Handlers
{
    public abstract class BaseHandler<T>(
        ProductDbContext dbContext,
        IServiceProvider serviceProvider,
        ILogger<T> logger)
    {
        protected ProductDbContext _dbContext = dbContext;
        protected IServiceProvider _serviceProvider = serviceProvider;
        protected ILogger<T> _logger = logger;
    }
}
