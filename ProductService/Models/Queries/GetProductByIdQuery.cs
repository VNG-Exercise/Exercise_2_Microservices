using MediatR;
using ProductService.Models.Dtos;

namespace ProductService.Models.Queries
{
    public class GetProductByIdQuery : IRequest<BaseResponse<ProductResponse>>
    {
        public long Id { get; set; }
    }
}
