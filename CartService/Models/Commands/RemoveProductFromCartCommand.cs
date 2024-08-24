using CartService.Models.Dtos;
using MediatR;

namespace CartService.Models.Commands
{
    public class RemoveProductFromCartCommand : IRequest<BaseResponse<bool>>
    {
        public long CartId { get; set; }

        public long ProductId { get; set; }
    }
}
