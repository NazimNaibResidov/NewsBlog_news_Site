
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsBlog.Base.BaseDateTime;
using NewsBlog.Base.BaseRepositories;
using NewsBlog.Base.BaseServices;
using NewsBlog.Base.BaseUnitOfWork;
using NewsBlog.Persistence;
using NewsBlog.Repositories;
using NewsBlog.Services;

namespace NewsBlog.Extensions
{

    public static class InfrastructureInjection
    {
        public static IServiceCollection AddInfrastructureInjection(this IServiceCollection services,
            IConfiguration configuration)
        {
            

            

            services.AddScoped(typeof(ICrudGenericRepository<>), typeof(EFCrudGenericRepository<>));

            services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddScoped<IDateTime, DateTimeService>();

            return services;
        }
    }
}