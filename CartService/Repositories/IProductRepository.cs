using Refit;

namespace CartService.Repositories
{
    public interface IProductRepository
    {
        [Get("/api/v1/product/{id}")]
        Task<ProductModel> GetProduct(long id);
    }
}
