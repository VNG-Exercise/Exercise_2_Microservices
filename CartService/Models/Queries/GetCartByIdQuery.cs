using CartService.Models.Dtos;
using MediatR;

namespace CartService.Models.Queries
{
    public class GetCartByIdQuery : IRequest<BaseResponse<CartResponse>>
    {
        public long CartId { get; set; }
    }
}
