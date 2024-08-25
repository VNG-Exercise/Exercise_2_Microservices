using CartService.Helpers;
using CartService.Models.Commands;
using CartService.Models.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CartService.Handlers
{
    public partial class CartHandler :
        IRequestHandler<RemoveProductFromCartCommand, BaseResponse<bool>>
    {
        public async Task<BaseResponse<bool>> Handle(
            RemoveProductFromCartCommand request,
            CancellationToken cancellationToken)
        {
            var cart = await _dbContext.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == request.CartId);

            if (cart is null)
                return new BaseResponse<bool>(false, StatusCodeResponse.Success, $"Not found any cart with Id={request.CartId}");

            var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == request.ProductId);
            if (cartItem is null)
                return new BaseResponse<bool>(false, StatusCodeResponse.Success, $"Not found any cartItem with ProductId={request.ProductId}");

            cart.Items.Remove(cartItem);
            cart.TotalPrice -= cartItem.Quantity * _productService.GetProductAsync(request.ProductId).Result.Price;

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<bool>(true);
        }
    }
}
