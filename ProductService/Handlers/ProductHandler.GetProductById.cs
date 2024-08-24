using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Models.Dtos;
using ProductService.Models.Queries;

namespace ProductService.Handlers
{
    public partial class ProductHandler :
        IRequestHandler<GetProductByIdQuery, BaseResponse<ProductResponse>>
    {
        public async Task<BaseResponse<ProductResponse>> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == request.Id &&
                                     p.IsDeleted == false, cancellationToken);

            if (entity is null)
                return new BaseResponse<ProductResponse>(null);

            return new BaseResponse<ProductResponse>(new ProductResponse(entity));
        }
    }
}
