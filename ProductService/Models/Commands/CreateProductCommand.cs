using MediatR;
using ProductService.Models.Dtos;

namespace ProductService.Models.Commands
{
    public class CreateProductCommand : IRequest<BaseResponse<long>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
