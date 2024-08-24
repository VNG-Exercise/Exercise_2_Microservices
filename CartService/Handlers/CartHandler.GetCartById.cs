using CartService.Models.Dtos;
using CartService.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CartService.Handlers
{
    public partial class CartHandler :
        IRequestHandler<GetCartByIdQuery, BaseResponse<CartResponse>>
    {
        public async Task<BaseResponse<CartResponse>> Handle(
            GetCartByIdQuery request,
            CancellationToken cancellationToken)
        {
            var cartEntity = await _dbContext.Carts
                .AsNoTracking()
                .Include(c => c.Items)
                .FirstOrDefaultAsync(cancellationToken);

            if (cartEntity is null || cartEntity.Items.Count == 0)
                return new BaseResponse<CartResponse>(null);

            return new BaseResponse<CartResponse>(new CartResponse(cartEntity));
        }
    }
}
