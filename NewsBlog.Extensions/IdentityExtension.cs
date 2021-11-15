using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NewsBlog.Entities.UserEntity;
using NewsBlog.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlog.Extensions
{
    public static class IdentityExtension
    {
        public static void IdentityLoad(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(o => {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 3;
            }).AddEntityFrameworkStores<NewsDbContext>()
              .AddDefaultTokenProviders();
        }
    }
}
