using CartService.Infrastructure.Communications.Http.ProductService;
using CartService.Infrastructure.Communications.Refit.ProductService;
using Refit;

namespace CartService.Extensions.ServiceExtensions
{
    public static class InjectionServiceExtension
    {
        public static void AddInjectedServices(
            this IServiceCollection services)
        {
            services.AddThirdPartyService();
        }

        private static IServiceCollection AddThirdPartyService(this IServiceCollection services)
        {
            services.AddRefitClient<IProductService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7070"));

            services.AddScoped<ProductClient>();
            services.AddHttpClient<ProductClient>(
                nameof(ProductClient),
                httpClient => { httpClient.Timeout = TimeSpan.FromSeconds(30); });

            return services;
        }
    }
}
