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
              async ([FromQuery] long cartId, IMediator mediator)
              =>
              {
                  return await mediator.Send(new GetCartByIdQuery { CartId = cartId });
              })
              .WithTags(group)
              .Produces<BaseResponse<CartResponse>>();

            endpoints.MapPost($"{prefix}" + "/{cartId}/add",
              async ([FromQuery] long cartId, AddProductToCartCommand request, IMediator mediator)
              =>
              {
                  request.CartId = cartId;
                  return await mediator.Send(request);
              })
              .WithTags(group)
              .Produces<BaseResponse<long>>();

            endpoints.MapDelete($"{prefix}" + "/{cartId}/remove/{productId}",
              async ([FromQuery] long cartId, [FromQuery] long productId, RemoveProductFromCartCommand request, IMediator mediator)
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
