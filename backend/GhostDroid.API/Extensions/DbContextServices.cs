using GhostDroid.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GhostDroid.API.Extensions
{
    public static class DbContextServices
    {
        public static IServiceCollection AddGhostDroidDbContext(this IServiceCollection @this,IConfiguration configuration)
        {
            @this.AddDbContext<GhostDroidDbContext>(options =>
            {
                string connectionString = configuration.GetConnectionString("MySqlConnectionString");
                ServerVersion version = ServerVersion.AutoDetect(connectionString);
                options.UseMySql(connectionString, version);
            });
            return @this;
        }
    }
}
