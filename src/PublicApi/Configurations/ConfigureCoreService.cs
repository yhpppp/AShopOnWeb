using PublicApi.Controllers.Services;

namespace PublicApi.Configurations
{
    public static class ConfigureCoreService
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBasketService), typeof(BasketService));
            return services;
        }
    }
}
