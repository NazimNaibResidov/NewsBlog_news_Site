using Microsoft.Extensions.DependencyInjection;
using NewsBlog.Interfaces.EntitySerivices;
using NewsBlog.Services.Entites;

namespace NewsBlog.Extensions
{
    public static class ServicesInjection
    {
        public static void ServicesInjectionExtenrions(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICommnetService, CommnetService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<INewsTypeService, NewsTypeService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<INewsTypeService, NewsTypeService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}