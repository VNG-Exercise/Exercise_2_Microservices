using CartService.Models.Dtos;

namespace CartService.Infrastructure.Communications.gRPC.Procedures
{
    public interface IProductService
    {
        Task<ProductModel> GetProductAsync(long Id);
    }
}
