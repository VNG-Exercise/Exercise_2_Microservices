using CartService.DbContexts;
using CartService.Helpers;
using CartService.Infrastructure.Communications.Http.ProductService;
using CartService.Models.Dtos;

namespace CartService.Handlers
{
    public partial class CartHandler(
        CartDbContext dbContext,
        Infrastructure.Communications.Refit.ProductService.IProductService productRepository,
        IServiceProvider serviceProvider,
        ILogger<CartHandler> logger) :
        BaseHandler<CartHandler>(dbContext, productRepository, serviceProvider, logger)
    {

        private async Task<ProductModel?> GetProductFromProductService(
            long Id,
            ProtocolType protocolType = ProtocolType.HTTP)
        {
            switch (protocolType)
            {
                case ProtocolType.HTTP:
                    {
                        var productClient = _serviceProvider.GetRequiredService<ProductClient>();

                        return await productClient.GetProductAsync(Id);
                    }
                case ProtocolType.REFIT:
                    return await _productService.GetProductAsync(Id);
                case ProtocolType.GRPC:
                    {
                        var productService = _serviceProvider.GetRequiredService<Infrastructure.Communications.gRPC.Procedures.IProductService>();

                        return await productService.GetProductAsync(Id);
                    }
            }

            return null;
        }
    }
}
