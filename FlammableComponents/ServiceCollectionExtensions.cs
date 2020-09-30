using Microsoft.Extensions.DependencyInjection;

namespace FlammableComponents
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFlammable(this IServiceCollection services)
        {
            return services.AddScoped<IToastService, ToastService>();
        }
    }
}
