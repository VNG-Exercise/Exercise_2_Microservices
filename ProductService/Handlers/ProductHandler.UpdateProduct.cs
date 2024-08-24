using MediatR;
using ProductService.Helpers;
using ProductService.Models.Commands;
using ProductService.Models.Dtos;

namespace ProductService.Handlers
{
    public partial class ProductHandler :
        IRequestHandler<UpdateProductCommand, BaseResponse<bool>>

    {
        public async Task<BaseResponse<bool>> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var productEntity = await _dbContext.Products.FindAsync(request.Id, cancellationToken);
            if (productEntity is null)
                return new BaseResponse<bool>(false, StatusCodeResponse.Success, $"Not found any product with requestId={request.Id}");

            _dbContext.Products.Update(productEntity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new BaseResponse<bool>(true);
        }
    }
}
