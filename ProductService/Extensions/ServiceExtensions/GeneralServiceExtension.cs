﻿namespace ProductService.Extensions.ServiceExtensions
{
    public static class GeneralServiceExtension
    {
        public static void AddGeneralConfigurations(
            this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR((cf) =>
            {
                cf.RegisterServicesFromAssembly(typeof(GeneralServiceExtension).Assembly);
            });
        }
    }
}
