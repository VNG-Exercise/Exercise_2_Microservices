namespace CartService.Extensions.ServiceExtensions
{
    public static class GeneralServiceExtension
    {
        public static void AddGeneralConfigurations(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.Configure<AppSettings>(configuration);
        }
    }
}
