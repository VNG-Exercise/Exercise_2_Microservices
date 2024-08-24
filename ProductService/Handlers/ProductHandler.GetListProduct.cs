using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Models.Dtos;
using ProductService.Models.Queries;

namespace ProductService.Handlers
{
    public partial class ProductHandler :
        IRequestHandler<GetListProductQuery, BaseResponse<PagingResponse<ProductResponse>>>
    {
        public async Task<BaseResponse<PagingResponse<ProductResponse>>> Handle(
            GetListProductQuery request,
            CancellationToken cancellationToken)
        {
            var query = _dbContext.Products.AsNoTracking();

            var count = await query.CountAsync(cancellationToken);

            var data = query
               .OrderBy(u => u.Id)
               .Skip((request.PageNumber - 1) * request.PageSize)
               .Take(request.PageSize)
               .ToList();

            var pagingDataResponse = new PagingResponse<ProductResponse>
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                Data = data.Select(x => new ProductResponse(x)).ToList(),
                HasMore = count - (request.PageNumber * request.PageSize) > 0,
                Total = count
            };

            return new BaseResponse<PagingResponse<ProductResponse>>(pagingDataResponse);
        }
    }
}
