using CartService.Repositories;
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
            services.AddRefitClient<IProductRepository>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7070"));

            return services;
        }
    }
}
