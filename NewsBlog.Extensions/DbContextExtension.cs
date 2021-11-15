using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsBlog.Persistence;

namespace NewsBlog.Extensions
{
    public static class DbContextExtension
    {
        public static void DbContextLoad(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("NewsDbContextConnectionString");
            services.AddDbContext<NewsDbContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("NewsBlog.Persistence"))
                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        }
    }
}
