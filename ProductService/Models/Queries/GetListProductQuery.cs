using MediatR;
using ProductService.Models.Dtos;

namespace ProductService.Models.Queries
{
    public class GetListProductQuery : IRequest<BaseResponse<PagingResponse<ProductResponse>>>
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
