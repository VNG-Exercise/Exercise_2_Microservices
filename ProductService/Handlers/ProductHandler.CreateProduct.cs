using MediatR;
using ProductService.Models.Commands;
using ProductService.Models.Dtos;
using ProductService.Models.Entities;

namespace ProductService.Handlers
{
    public partial class ProductHandler :
        IRequestHandler<CreateProductCommand, BaseResponse<long>>
    {
        public async Task<BaseResponse<long>> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity
            };

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new BaseResponse<long>(product.Id);
        }
    }
}
