using CartService.Infrastructure.Communications.gRPC.Procedures;
using CartService.Infrastructure.Communications.Http.ProductService;
using Refit;

namespace CartService.Extensions.ServiceExtensions
{
    public static class InjectionServiceExtension
    {
        public static void AddInjectedServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddThirdPartyService(configuration);
        }

        private static IServiceCollection AddThirdPartyService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var productServiceUri = configuration.GetValue<string>("ProductService:BaseUri");

            productServiceUri = string.IsNullOrEmpty(productServiceUri) ? "https://localhost:7070" : productServiceUri;

            services.AddRefitClient<Infrastructure.Communications.Refit.ProductService.IProductService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(productServiceUri));

            services.AddScoped<ProductClient>();
            services.AddHttpClient<ProductClient>(
                nameof(ProductClient),
                httpClient => { httpClient.Timeout = TimeSpan.FromSeconds(30); });

            services.AddTransient<Infrastructure.Communications.gRPC.Procedures.IProductService, ProductService>();

            return services;
        }
    }
}
