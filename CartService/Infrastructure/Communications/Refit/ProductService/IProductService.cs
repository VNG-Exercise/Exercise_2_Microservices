using CartService.Models.Dtos;
using Refit;

namespace CartService.Infrastructure.Communications.Refit.ProductService
{
    public interface IProductService
    {
        [Get("/api/v1/product/{id}")]
        Task<ProductModel> GetProductAsync(long id);
    }
}
