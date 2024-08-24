using CartService.Models.Dtos;
using MediatR;

namespace CartService.Models.Commands
{
    public class AddProductToCartCommand : IRequest<BaseResponse<long>>
    {
        public long CartId { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
