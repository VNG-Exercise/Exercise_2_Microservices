using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models.Commands;
using ProductService.Models.Dtos;
using ProductService.Models.Queries;

namespace ProductService.Endpoints
{
    public static class AppEndpoints
    {
        private const string prefix = "api/v1/product";
        private const string group = "Product";

        public static void MapAppEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet($"{prefix}",
               async (IMediator mediator)
               =>
               {
                   return await mediator.Send(new GetListProductQuery());
               })
               .WithTags(group)
               .Produces<BaseResponse<PagingResponse<ProductResponse>>>();

            endpoints.MapGet($"{prefix}" + "/{id}",
               async ([FromQuery] long id, IMediator mediator)
               =>
               {
                   return await mediator.Send(new GetProductByIdQuery() { Id = id });
               })
               .WithTags(group)
               .Produces<BaseResponse<ProductResponse>>();

            endpoints.MapPost($"{prefix}",
               async (CreateProductCommand request, IMediator mediator)
               =>
               {
                   return await mediator.Send(request);
               })
               .WithTags(group)
               .Produces<BaseResponse<long>>();

            endpoints.MapPut($"{prefix}" + "/{id}",
               async ([FromQuery] long id, UpdateProductCommand request, IMediator mediator)
               =>
               {
                   request.Id = id;
                   return await mediator.Send(request);
               })
               .WithTags(group)
               .Produces<BaseResponse<bool>>();

            endpoints.MapDelete($"{prefix}" + "/{id}",
               async ([FromQuery] long id, DeleteProductCommand request, IMediator mediator)
               =>
               {
                   request.Id = id;
                   return await mediator.Send(request);
               })
               .WithTags(group)
               .Produces<BaseResponse<bool>>();
        }
    }
}
