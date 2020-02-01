using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Db_Service
{
    public static class DbConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddDb(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
