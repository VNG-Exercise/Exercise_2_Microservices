using CartService.Infrastructure.Communications.gRPC.Protos.ProductClient;
using Grpc.Core;
using Grpc.Net.Client;

namespace CartService.Infrastructure.Communications.gRPC.Procedures
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly ProductProtoService.ProductProtoServiceClient _client;
        public ProductService(ILogger<ProductService> logger, IConfiguration configuration)
        {
            _logger = logger;
            var channel = GrpcChannel.ForAddress(configuration.GetValue<string>("ProductService:BaseUri"));
            _client = new ProductProtoService.ProductProtoServiceClient(channel);
        }

        public async Task<Models.Dtos.ProductModel> GetProductAsync(long Id)
        {
            try
            {
                var product = await _client.GetProductAsync(new GetProductRequest { ProductId = Id.ToString() });

                _ = long.TryParse(product.Id, out long id);
                _ = int.TryParse(product.Quantity, out int quantity);
                _ = decimal.TryParse(product.Quantity, out decimal price);

                return new Models.Dtos.ProductModel
                {
                    Id = id,
                    Name = product.Name,
                    Quantity = quantity,
                    Price = price
                };

            }
            catch (RpcException ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
