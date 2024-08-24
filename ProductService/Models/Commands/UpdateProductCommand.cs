using MediatR;
using ProductService.Models.Dtos;

namespace ProductService.Models.Commands
{
    public class UpdateProductCommand : IRequest<BaseResponse<bool>>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
