using GhostDroid.Domain.Repositories;
using GhostDroid.Domain.Services;
using GhostDroid.Domain.Services.Interfaces;
using GhostDroid.Infrastructure.Repositories;

namespace GhostDroid.API.Extensions
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection AddRepositories(this IServiceCollection @this)
        {
            @this.AddScoped<INotificationRepository, NotificationRepository>();            
            return @this;
        }

        public static IServiceCollection AddServices(this IServiceCollection @this)
        {
            @this.AddScoped<INotificationService, NotificationService>();
            return @this;
        }
    }
}
