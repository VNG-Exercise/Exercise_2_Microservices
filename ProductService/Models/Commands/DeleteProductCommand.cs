using MediatR;
using ProductService.Models.Dtos;

namespace ProductService.Models.Commands
{
    public class DeleteProductCommand : IRequest<BaseResponse<bool>>
    {
        public long Id { get; set; }

        public bool IsSoftDelete { get; set; } = true;
    }
}
