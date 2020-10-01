using Microsoft.Extensions.DependencyInjection;

namespace FlammableComponents
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFlammable(this IServiceCollection services)
        {
            services.AddScoped<IToastService, ToastService>();
            return services.AddScoped<IModalDialogService, ModalDialogService>();
        }
    }
}
