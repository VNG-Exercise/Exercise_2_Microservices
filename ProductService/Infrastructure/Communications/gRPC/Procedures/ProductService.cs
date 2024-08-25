using Grpc.Core;
using MediatR;
using ProductService.Infrastructure.Communications.gRPC.Protos.ProductServer;
using ProductService.Models.Queries;
namespace ProductService.Infrastructure.Communications.gRPC.Procedures
{
    public class ProductService(ISender sender) : ProductProtoService.ProductProtoServiceBase
    {
        private readonly ISender _sender = sender;

        public override async Task<ProductModel?> GetProduct(GetProductRequest request, ServerCallContext context)
        {
            _ = long.TryParse(request.ProductId, out var productId);

            var productResponse = await _sender.Send(new GetProductByIdQuery { Id = productId });

            var productResponseData = productResponse.Data;

            if (productResponseData is null)
                return null;

            return new ProductModel
            {
                Id = productResponseData.Id.ToString(),
                Name = productResponseData.Name,
                Quantity = productResponseData.Quantity.ToString()
            };
        }
    }
}
