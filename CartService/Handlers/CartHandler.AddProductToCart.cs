using CartService.Helpers;
using CartService.Models.Commands;
using CartService.Models.Dtos;
using CartService.Models.Entities;
using MediatR;

namespace CartService.Handlers
{
    public partial class CartHandler :
        IRequestHandler<AddProductToCartCommand, BaseResponse<long>>
    {
        public async Task<BaseResponse<long>> Handle(
            AddProductToCartCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProduct(request.ProductId);
            if (product is null || product.Quantity < request.Quantity)
                return new BaseResponse<long>(0, StatusCodeResponse.Success, "Product not available or insufficient quantity.");

            var cart = await _dbContext.Carts.FindAsync(request.CartId);
            if (cart is null)
            {
                cart = new Cart { Id = request.CartId };
                _dbContext.Carts.Add(cart);
            }

            var cartItem = new CartItem
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Cart = cart
            };

            cart.Items.Add(cartItem);
            cart.TotalPrice += product.Price * request.Quantity;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new BaseResponse<long>(cartItem.Id);
        }
    }
}
