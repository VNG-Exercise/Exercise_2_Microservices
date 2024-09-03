using CartService.Models.Commands;
using CartService.Models.Dtos;
using CartService.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Endpoints
{
    public static class AppEndpoints
    {
        private const string prefix = "api/v1/cart";
        private const string group = "Cart";

        public static void MapAppEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet($"{prefix}" + "/{cartId}",
              async (long cartId, [FromServices] IMediator mediator)
              =>
              {
                  return await mediator.Send(new GetCartByIdQuery { CartId = cartId });
              })
              .WithTags(group)
              .Produces<BaseResponse<CartResponse>>();

            endpoints.MapPost($"{prefix}" + "/{cartId}/add",
              async (long cartId,
                     [FromBody] AddProductToCartCommand request,
                     [FromServices] IMediator mediator)
              =>
              {
                  request.CartId = cartId;
                  return await mediator.Send(request);
              })
              .WithTags(group)
              .Produces<BaseResponse<long>>();

            endpoints.MapDelete($"{prefix}" + "/{cartId}/remove/{productId}",
              async (long cartId,
                     [FromQuery] long productId,
                     [FromBody] RemoveProductFromCartCommand request,
                     [FromServices] IMediator mediator)
              =>
              {
                  request.CartId = cartId;
                  request.ProductId = productId;
                  return await mediator.Send(request);
              })
              .WithTags(group)
              .Produces<BaseResponse<bool>>();
        }
    }
}
