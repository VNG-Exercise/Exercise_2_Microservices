using MediatR;
using ProductService.Helpers;
using ProductService.Models.Commands;
using ProductService.Models.Dtos;

namespace ProductService.Handlers
{
    public partial class ProductHandler :
        IRequestHandler<DeleteProductCommand, BaseResponse<bool>>
    {
        public async Task<BaseResponse<bool>> Handle(
            DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            var productEntity = await _dbContext.Products.FindAsync(request.Id, cancellationToken);
            if (productEntity is null)
                return new BaseResponse<bool>(false, StatusCodeResponse.Success, $"Not found any product with requestId={request.Id}");

            if (request.IsSoftDelete)
            {
                productEntity.ModificationDate = DateTime.UtcNow;
                productEntity.IsDeleted = false;
                _dbContext.Products.Update(productEntity);

                _logger.LogInformation($"ProductHandler -> DeleteProductCommand: Soft delete product {request.Id} is successfully!!!");
            }
            else
            {
                _dbContext.Products.Remove(productEntity);

                _logger.LogInformation($"ProductHandler -> DeleteProductCommand: Delete product {request.Id} is successfully!!!");
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new BaseResponse<bool>(true);
        }
    }
}
