using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NewsBlog.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<NewsDbContext>
    {
        public NewsDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var optionsBuilder = new DbContextOptionsBuilder<NewsDbContext>();

            var connectionString = configuration
                        .GetConnectionString("NewsDbContextConnectionString");

            optionsBuilder.UseSqlServer(connectionString);

            return new NewsDbContext(optionsBuilder.Options);
        }
    }
}