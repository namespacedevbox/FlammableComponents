using FlammableComponents.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlammableComponents
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFlammable(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDataTableService<,>), typeof(DataTableService<,>));
            services.AddScoped<IToastService, ToastService>();
            return services.AddScoped<IModalDialogService, ModalDialogService>();
        }
    }
}
